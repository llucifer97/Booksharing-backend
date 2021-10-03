using System.Collections.Generic;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; } // unique
        public string UserName { get; set; } // unique
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
         public string Email { get; set; }
         public string City { get; set; }
        

    }
}