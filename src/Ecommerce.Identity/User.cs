namespace Ecommerce.Identity;
public class User
{
    public User(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; private init; }
}
