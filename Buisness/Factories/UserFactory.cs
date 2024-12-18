using Business.Interfaces;
using Business.Models;

namespace Business.Factories;

public class UserFactory
{
    public static User Create()
    {
        return new User();
    }
}
