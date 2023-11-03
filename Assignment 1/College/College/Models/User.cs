using College.Models.Enums;

namespace College.Models
{
    public class User
    {
        public string Username { get; set; }
        public Role UserRole { get; set; }
        public Status UserStatus { get; set; }
        
        // Constructor
        public User(string username, Role userRole, Status userStatus)
        {
            Username = username;
            UserRole = userRole;
            UserStatus = userStatus;
        }
    }   
}