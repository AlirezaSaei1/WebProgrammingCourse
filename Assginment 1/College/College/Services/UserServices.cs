using College.Models;
using College.Models.Enums;

namespace College.Services
{
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public void RegisterUser(string username, Role role, Status status) {}

        public void ApproveMembership(User adminUser, User user) {}

        public void RejectMembership(User adminUser, User user) {}

        public List<User> GetWaitingList() { return null; }

        public void ChangeRole(User adminUser, User user, Role newRole) {}

        public Status GetUserStatus(string username)
        { return Status.Active;}

        private User FindUserByUsername(string username)
        {
            return _users.Find(u => u.Username == username);
        }
    }
}