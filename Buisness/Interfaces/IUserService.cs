using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    void AddUser(User users);
    IEnumerable<User> ShowUsers(out bool hasError);
}
