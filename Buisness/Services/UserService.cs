using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Text.Json;

namespace Business.Services;

public class UserService : IUserService
{
    private readonly FileService _fileService = new();
    private List<Users> _Users = [];

    public void AddUser(Users users)
    {
        IIdGenerator idGenerator = new IdGenerator();
        users.Id = idGenerator.GenerateId();
        _Users.Add(users);

        var json = JsonSerializer.Serialize(_Users);
        _fileService.SaveContentToFile(json);
    }

    public IEnumerable<Users> ShowUsers(out bool hasError)
    {
        hasError = false;
        var json = _fileService.GetContentFromFile();
        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                _Users = JsonSerializer.Deserialize<List<Users>>(json) ?? [];
            }
            catch
            {
                hasError = true;
            }
        }
        return _Users;
    }
}
