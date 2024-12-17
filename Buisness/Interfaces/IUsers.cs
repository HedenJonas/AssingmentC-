namespace Business.Interfaces
{
    public interface IUsers
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string ZipCode { get; set; }
        string City { get; set; }
    }
}
