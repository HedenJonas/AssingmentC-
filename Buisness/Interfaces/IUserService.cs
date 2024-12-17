using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    void AddUser(Users users);
    IEnumerable<Users> ShowUsers(out bool hasError);
}
