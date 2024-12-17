using Business.Interfaces;

namespace Business.Helpers;

public class IdGenerator : IIdGenerator
{
    public string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }
}
