using System;

namespace WebForUsers.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        internal static object FindFirst(string nameIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
