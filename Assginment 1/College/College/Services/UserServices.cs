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

        public string RegisterUser(string username, string role)
        {
            var user = FindUserByUsername(username);

            if (user == null)
            {
                if (!Enum.TryParse(role, out Role parsedRole))
                {
                    return "INVALID ROLE";
                }
                
                users.Add(new User(username, parsedRole, Status.INACTIVE));
                return "WAITING FOR ACCEPT";
            }
            else
            {
                return "INVALID USERNAME";
            }
        }

        public string ApproveMembership(string adminUsername, string username)
        {
            var adminUser = FindUserByUsername(adminUsername);
            var user = FindUserByUsername(username);

            if (adminUser == null)
            {
                return "INVALID USERNAME";
            }

            if (adminUser.UserStatus != Status.ACTIVE)
            {
                return "WAITING FOR ADMIN";
            }

            if (adminUser.UserRole != Role.ADMIN)
            {
                return $"{adminUsername} IS NOT ADMIN";
            }

            if (user == null)
            {
                return "INVALID USERNAME";
            }

            if (user.UserStatus == Status.ACTIVE)
            {
                return $"{username} IS ACTIVE";
            }

            user.UserStatus = Status.ACTIVE;
            return $"{username} ACTIVATED";
        }

        public string RejectMembership(string adminUsername, string username)
        {
            var adminUser = FindUserByUsername(adminUsername);
            var user = FindUserByUsername(username);

            if (adminUser == null)
            {
                return "INVALID USERNAME";
            }

            if (adminUser.UserStatus != Status.ACTIVE)
            {
                return "WAITING FOR ADMIN";
            }

            if (adminUser.UserRole != Role.ADMIN)
            {
                return $"{adminUsername} IS NOT ADMIN";
            }

            if (user == null)
            {
                return "INVALID USERNAME";
            }

            if (user.UserStatus == Status.ACTIVE)
            {
                return $"{username} IS ACTIVE";
            }

            users.Remove(user);
            return $"{username} REJECTED";
        }

        public string GetWaitingList(string username)
        {
            var user = FindUserByUsername(username);

            if (user == null)
            {
                return "INVALID USERNAME";
            }

            if (user.UserStatus == Status.INACTIVE)
            {
                return "WAITING FOR ADMIN";
            }

            if (user.UserRole == Role.MEMBER)
            {
                return "NOT ENOUGH ACCESS";
            }

            var waitingUsers = users
                .Where(u => u.UserStatus == Status.INACTIVE)
                .OrderBy(u => u.Username)
                .Select(u => u.Username)
                .ToList();

            if (waitingUsers.Count == 0)
            {
                return "NO USER";
            }

            return string.Join(" ", waitingUsers);
        }

        public string ChangeRole(string adminUsername, string username, string newRole)
        {
            var adminUser = FindUserByUsername(adminUsername);
            var user = FindUserByUsername(username);

            if (adminUser == null || user == null)
            {
                return "INVALID USERNAME";
            }

            if (adminUser.UserStatus == Status.INACTIVE || user.UserStatus == Status.INACTIVE)
            {
                return "WAITING FOR ADMIN";
            }

            if (!Enum.TryParse(newRole.ToUpper(), out Role role) || !Enum.IsDefined(typeof(Role), role))
            {
                return "INVALID ROLE";
            }

            if (adminUser.UserRole < role || adminUser.UserRole == role)
            {
                return "NOT ENOUGH ACCESS";
            }

            if (adminUser.UserRole < user.UserRole || adminUser.UserRole == user.UserRole)
            {
                return "INVALID CHANGEROLE";
            }

            if (user.UserRole == role)
            {
                return "ALREADY HAS THIS ROLE";
            }

            user.UserRole = role;
            return "ROLE CHANGED SUCCESSFULLY";
        }

        public string GetUserStatus(string username)
        {
            var user = FindUserByUsername(username);
            if (user != null)
            {
                return user.UserStatus == Status.ACTIVE
                    ? $"username: {username} role: {user.UserRole} active"
                    : $"username: {username} role: {user.UserRole} not active";
            }
            else
            {
                return "INVALID USERNAME";
            }
            
        }

        private User FindUserByUsername(string username)
        {
            return users.Find(u => u.Username == username);
        }
    }
}