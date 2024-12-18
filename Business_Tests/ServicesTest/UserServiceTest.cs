using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace Business_Tests.ServicesTest;

public class UserServiceTest
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly UserService _userService;

    public UserServiceTest()
    {
        _fileServiceMock = new Mock<IFileService>();
        _userService = new UserService(_fileServiceMock.Object);
    }

    [Fact]
    public void AddUser_ShouldAddUserToListAndToFile()
    {
        // Arrange
        var user = new User { FirstName = "John Doe" };
        var usersList = new List<User> { user };
        var json = System.Text.Json.JsonSerializer.Serialize(usersList);

        _fileServiceMock.Setup(fs => fs.SaveContentToFile(json));

        // Act
        _userService.AddUser(user);

        // Assert
        _fileServiceMock.Verify(fs => fs.SaveContentToFile(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void ShowUsers_ShouldShowListOfUsers()
    {
        // Arrange
        var user = new User { FirstName = "John Doe" };
        var usersList = new List<User> { user };
        var json = System.Text.Json.JsonSerializer.Serialize(usersList);

        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(json);

        // Act
        bool hasError;
        var result = _userService.ShowUsers(out hasError);

        // Assert
        Assert.False(hasError);
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("John Doe", result.First().FirstName);
    }

    [Fact]
    public void ShowUsers_ShouldShowHasErrorWhenJsonInvalid()
    {
        // Arrange
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns("invalid json");

        // Act
        bool hasError;
        var result = _userService.ShowUsers(out hasError);

        // Assert
        Assert.True(hasError);
        Assert.Empty(result);
    }
}
