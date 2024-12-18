using Business.Factories;
using Business.Models;

namespace Business_Tests.FactoriesTest
{
    public class UserFactoryTest
    {
        [Fact]
        public void Create_ShouldReturnInstanceOfUser()
        {
            // Act
            User user = UserFactory.Create();

            // Assert
            Assert.NotNull(user);
            Assert.IsType<User>(user);
        }
    }
}
