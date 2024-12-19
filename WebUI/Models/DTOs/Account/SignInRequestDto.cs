namespace WebUI.Models.DTOs.Account
{
    public class SignInRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
    public class SignInResponsetDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
