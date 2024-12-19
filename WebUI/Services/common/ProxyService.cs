using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;
using WebUI.Models.common;

namespace WebUI.Services.common
{
    public abstract class ProxyService
    {
        private readonly IHttpClientFactory httpClientFactory;
        protected HttpClient client;

        public ProxyService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.client = httpClientFactory.CreateClient("httpClient");
            this.client.BaseAddress = new Uri(configuration["API_URL"]!);
        }

        public async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellation = default)
            where T : ApiResponse
        {
            var response = await client.GetAsync(endpoint, cancellation);

            var content = await response.Content.ReadAsStringAsync(cancellation);
            var apiResponse = JsonConvert.DeserializeObject<T>(content)!;

            return apiResponse;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellation = default)
    where TResponse : ApiResponse
    where TRequest : class
        {
            var multipartContent = new MultipartFormDataContent();

            foreach (var property in typeof(TRequest).GetProperties())
            {
                var value = property.GetValue(request);

                if (value != null)
                {
                    if (value is IFormFile file)
                    {
                        var fileContent = new StreamContent(file.OpenReadStream());
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        multipartContent.Add(fileContent, property.Name, file.FileName);
                    }
                    else
                    {
                        multipartContent.Add(new StringContent(value.ToString()!), property.Name);
                    }
                }
            }

            var response = await client.PostAsync(endpoint, multipartContent, cancellation);
            var contentJsonContent = await response.Content.ReadAsStringAsync(cancellation);
            var apiResponse = JsonConvert.DeserializeObject<TResponse>(contentJsonContent)!;

            return apiResponse;
        }




        public async Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellation = default)
            where TResponse : ApiResponse
            where TRequest : class
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await client.PutAsync(endpoint, content, cancellation);

            var contentJsonContent = await response.Content.ReadAsStringAsync(cancellation);
            var apiResponse = JsonConvert.DeserializeObject<TResponse>(contentJsonContent)!;

            return apiResponse;
        }

        public async Task DeleteAsync(string endpoint, CancellationToken cancellation = default)
        {
            await client.DeleteAsync(endpoint, cancellation);
        }
    }
}
