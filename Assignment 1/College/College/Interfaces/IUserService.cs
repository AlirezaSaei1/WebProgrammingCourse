using College.Models;

namespace College.Interfaces;

public interface IUserService
{
    string RegisterUser(string username, string role);
    string ApproveMembership(string adminUsername, string username);
    string RejectMembership(string adminUsername, string username);
    string GetWaitingList(string username);
    string ChangeRole(string adminUsername, string username, string newRole);
    string GetUserStatus(string username);
    User? FindUserByUsername(string username);
}