using College.Models;
using College.Models.Enums;

namespace College.Services
{
    public class UserService
    {
        private List<User> users;

        public UserService()
        {
            users = new List<User>();
            users.Add(new User("ADMIN", Role.ADMIN, Status.ACTIVE));
        }

        public void RegisterUser(string username, string role)
        {
            var user = FindUserByUsername(username);

            if (user == null)
            {
                if (!Enum.TryParse(role, out Role parsedRole))
                {
                    Console.WriteLine("INVALID ROLE");
                    return;
                }
                
                users.Add(new User(username, parsedRole, Status.INACTIVE));
                Console.WriteLine("WAITING FOR ACCEPT");
            }
            else
            {
                Console.WriteLine("INVALID USERNAME");
            }
        }

        public void ApproveMembership(string adminUsername, string username)
        {
            var adminUser = FindUserByUsername(adminUsername);
            var user = FindUserByUsername(username);

            if (adminUser == null)
            {
                Console.WriteLine("INVALID USERNAME");
                return;
            }

            if (adminUser.UserStatus != Status.ACTIVE)
            {
                Console.WriteLine("WAITING FOR ADMIN");
                return;
            }

            if (adminUser.UserRole != Role.ADMIN)
            {
                Console.WriteLine($"{adminUsername} IS NOT ADMIN");
                return;
            }

            if (user == null)
            {
                Console.WriteLine("INVALID USERNAME");
                return;
            }

            if (user.UserStatus == Status.ACTIVE)
            {
                Console.WriteLine($"{username} IS ACTIVE");
                return;
            }

            user.UserStatus = Status.ACTIVE;
            Console.WriteLine($"{username} ACTIVATED");
        }

        public void RejectMembership(User adminUser, User user) {}

        public List<User> GetWaitingList() { return null; }

        public void ChangeRole(User adminUser, User user, Role newRole) {}

        public void GetUserStatus(string username)
        {
            var user = FindUserByUsername(username);
            if (user != null)
            {
                Console.WriteLine(user.UserStatus == Status.ACTIVE
                    ? $"username: {username} role: {user.UserRole} active"
                    : $"username: {username} role: {user.UserRole} not active");
            }
            else
            {
                Console.WriteLine("INVALID USERNAME");
            }
            
        }

        private User FindUserByUsername(string username)
        {
            return users.Find(u => u.Username == username);
        }
    }
}