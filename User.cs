using System;

namespace DocumentosOrtobio
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime LastLogin { get; set; } // Adicionado campo LastLogin
    }

    public class UserLoginDetail
    {
        public string Username { get; set; }
        public string IPAddress { get; set; }
        public string LoginTime { get; set; } // Formato: dd-MM-yyyy HH:mm:ss
        public string OnlineTime { get; set; } // Formato: HH:mm:ss
    }
}