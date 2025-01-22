using Application;
using Domain.Configurations;
using Domain.Entities.Membership;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Persistence.Contexts;
using System.Reflection;
using System.Text;
using WebAPI.Middleware;


namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoadPolicies();

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new IoCFactory());

            builder.Services.AddDataContext(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"), opt =>
                {
                    opt.MigrationsHistoryTable("MigrationsHistory");
                });
            });

            builder.Services.AddControllers(cfg => 
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplicationReference>());

            builder.Services.Configure<IdentityOptions>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+!";

                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                if (builder.Environment.IsDevelopment())
                {
                    cfg.Password.RequiredUniqueChars = 0;
                    cfg.Password.RequiredLength = 3;
                    cfg.Password.RequireNonAlphanumeric = false;
                    cfg.Password.RequireUppercase = false;
                    cfg.Password.RequireLowercase = false; 
                    cfg.Password.RequireDigit = false;
                }
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddCors(cfg => cfg.AddPolicy("allowAll", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));


            builder.Services.AddAuthentication(cfg =>
            {
                cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Environment.GetEnvironmentVariable("JWT__ISSUER")!,
                    ValidAudience = Environment.GetEnvironmentVariable("JWT__AUDIENCE")!,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT__KEY")!)),
                    ClockSkew = TimeSpan.Zero,
                    LifetimeValidator = (notBefore, expires, tokenToValidate, @param) => expires != null && expires > DateTime.UtcNow
                };
            });

            builder.Services.Configure<EmailConfiguration>(cfg => builder.Configuration.GetSection(cfg.GetType().Name).Bind(cfg));

            builder.Services.AddAuthorization(cfg =>
            {
                foreach (var policy in ClaimsTransformation.policies)
                {
                    cfg.AddPolicy(policy, opt => opt.RequireAssertion(handler => handler.User.IsInRole("SUPERADMIN") || handler.User.HasClaim(m => m.Type.Equals(policy) && m.Value.Equals("1"))));
                }
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 104857600;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    policy => policy.WithOrigins("https://localhost:7074")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {   
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseDbTransaction();
            app.UseCors("AllowLocalhost");

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 400 && context.Request.Method == "POST")
                {
                    var endpoint = context.GetEndpoint();
                    Console.WriteLine($"Request failed before reaching endpoint: {endpoint?.DisplayName}");

                    var modelState = context.Features.Get<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>();
                    if (modelState != null && !modelState.IsValid)
                    {
                        foreach (var state in modelState)
                        {
                            Console.WriteLine($"Key: {state.Key}, Errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
                        }
                    }
                }
            });



            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/files",
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "Uploads"))
            });

            app.MapControllers();

            app.Run();
        }

        private static void LoadPolicies()
        {
            var types = typeof(Program).Assembly.GetTypes();

            ClaimsTransformation.policies = types
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && t.IsDefined(typeof(AuthorizeAttribute), true))
                .SelectMany(t => t.GetCustomAttributes<AuthorizeAttribute>())
                .Union(
                types
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t))
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic
                 && !method.IsDefined(typeof(NonActionAttribute), true)
                 && method.IsDefined(typeof(AuthorizeAttribute), true))
                 .SelectMany(t => t.GetCustomAttributes<AuthorizeAttribute>())
                )
                .Where(a => !string.IsNullOrWhiteSpace(a.Policy))
                .SelectMany(a => a.Policy.Split(new[] { "," }, System.StringSplitOptions.RemoveEmptyEntries))
                .Distinct()
                .ToArray();
        }
    }
}
