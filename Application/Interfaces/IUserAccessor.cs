namespace Application.Interfaces;

public interface IUserAccessor
{
    UserCredentials GetUser();
    string GetUsername();
}

public class UserCredentials
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}