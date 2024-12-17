using Business.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Users : IUsers
{
    public string Id { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Ogiltig e-postadress.")]
    public string Email { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Ogiltigt postnummer. Det ska vara 5 siffror eller 5+4 format.")]
    public string ZipCode { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;
}