namespace WebApplicationProject.Services;

public interface IEmailService
{
    void SendLoginEmail(string username);
    void SendSignupEmail(string email);
}