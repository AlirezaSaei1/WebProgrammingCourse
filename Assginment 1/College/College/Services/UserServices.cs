using College.Interfaces;
using College.Models;
using College.Models.Enums;

namespace College.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User> { new User("ADMIN", Role.ADMIN, Status.ACTIVE) };
        }

        public string RegisterUser(string username, string role)
        {
            if (FindUserByUsername(username) != null)
            {
                return "INVALID USERNAME";
            }

            if (!Enum.TryParse(role, out Role parsedRole))
            {
                return "INVALID ROLE";
            }

            _users.Add(new User(username, parsedRole, Status.INACTIVE));
            return "WAITING FOR ACCEPT";
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

            _users.Remove(user);
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

            var waitingUsers = _users
                .Where(u => u.UserStatus == Status.INACTIVE)
                .OrderBy(u => u.Username)
                .Select(u => u.Username)
                .ToList();

            return waitingUsers.Count == 0 ? "NO USER" : string.Join(" ", waitingUsers);
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

            if (adminUser.UserRole < user.UserRole || adminUser.UserRole == user.UserRole)
            {
                return "NOT ENOUGH ACCESS";
            }

            if (adminUser.UserRole < role)
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

        public User? FindUserByUsername(string username)
        {
            return _users.Find(u => u.Username == username);
        }
    }
}