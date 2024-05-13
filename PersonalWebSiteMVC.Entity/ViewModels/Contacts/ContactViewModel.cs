﻿namespace PersonalWebSiteMVC.Entity.ViewModels.Contacts
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
