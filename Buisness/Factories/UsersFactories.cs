using Business.Interfaces;
using Business.Models;

namespace Business.Factories;

public class UsersFactories
{
    public static Users Create()
    {
        return new Users();
    }
}
