﻿namespace WebUI.Models.DTOs.Mentor
{
    public class MentorResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string CategoryName { get; set; }
        public string ProfilePath { get; set; }
        public string CoverPath { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public int Likes { get; set; }
        public bool IsVerified { get; set; }
    }
}
