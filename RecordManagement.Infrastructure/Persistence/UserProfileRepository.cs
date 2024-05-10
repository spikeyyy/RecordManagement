using RecordManagement.Application.Common.Interfaces.Persistence;
using RecordManagement.Domain.Entities;


namespace RecordManagement.Infrastructure.Persistence;
public class UserProfileRepository : IUserProfileRepository
{

    private static readonly List<User> _users = new();
    void IUserProfileRepository.Add(User user)
    {
       _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
       return _users.SingleOrDefault(u=> u.Email == email);
    }
}
