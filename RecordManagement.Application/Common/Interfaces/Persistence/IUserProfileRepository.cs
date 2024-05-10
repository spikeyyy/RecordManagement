
using RecordManagement.Domain.Entities;

namespace RecordManagement.Application.Common.Interfaces.Persistence;


public interface IUserProfileRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}