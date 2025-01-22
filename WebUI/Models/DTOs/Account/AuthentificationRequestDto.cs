namespace WebUI.Models.DTOs.Account
{
    public class AuthentificationRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
    public class AuthentificationResponsetDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
