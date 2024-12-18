using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Text.Json;

namespace Business.Services;

public class UserService : IUserService
{
    // Detta är första koden som kan köra appen!!
    //private readonly FileService _fileService = new();
    //private List<User> _Users = [];

    // ai lösningen:
    private readonly IFileService _fileService;
    private List<User> _Users = [];

    public UserService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void AddUser(User users)
    {
        try
        {
            IIdGenerator idGenerator = new IdGenerator();
            users.Id = idGenerator.GenerateId();
            _Users.Add(users);

            var json = JsonSerializer.Serialize(_Users);
            _fileService.SaveContentToFile(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding a user: {ex.Message}");
        }
        
    }

    public IEnumerable<User> ShowUsers(out bool hasError)
    {
        hasError = false;
        var json = _fileService.GetContentFromFile();
        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                _Users = JsonSerializer.Deserialize<List<User>>(json) ?? [];
            }
            catch
            {
                hasError = true;
            }
        }
        return _Users;
    }
}
