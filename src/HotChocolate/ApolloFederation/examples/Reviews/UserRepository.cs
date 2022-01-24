namespace Reviews;

public class UserRepository
{
    private readonly Dictionary<string, User> _users;

    public UserRepository()
    {
        _users = CreateUsers().ToDictionary(t => t.Id);
    }

    public User GetUserById(string id) => _users[id];

    private static IEnumerable<User> CreateUsers()
    {
        yield return new User
        {
            Id = "1",
            Username = "@ada",
        };

        yield return new User
        {
            Id = "2",
            Username = "@complete",
        };
    }
}