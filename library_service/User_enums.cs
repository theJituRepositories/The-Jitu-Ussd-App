﻿namespace library_service
{
    public class User_enums
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User
    }

  
}