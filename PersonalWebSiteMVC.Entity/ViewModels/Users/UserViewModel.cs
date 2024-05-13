﻿using Microsoft.AspNetCore.Http;
using PersonalWebSiteMVC.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Entity.ViewModels.Users
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } 
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Website { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Degree { get; set; }
        public string? Description { get; set; }
        public Image Image { get; set; }
        public string? Title { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
