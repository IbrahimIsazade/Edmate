namespace WebUI.Models.DTOs.Account
{
    public class SignUpRequestDto
    {
        public string Name { get; set; }
        public string Surename { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsMentor { get; set; }
        public bool SubscribeForNews { get; set; }
    }
}
