using System.ComponentModel.DataAnnotations;

namespace CSBank.Application.Models;

public class CustomerDto
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be in between 2 to 100 characters!")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be in between 2 to 100 characters!")]
    public string LastName { get; set; } = string.Empty;

    [StringLength(100, MinimumLength = 2, ErrorMessage = "Suffix must be in between 2 to 100 characters!")]
    public string? Suffix { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }

    public char? MiddleInitial { get; set; } = null;
};

public class UserDetailsDto
{
    public Guid Id;
    public string FirstName = string.Empty;
    public string LastName = string.Empty;
    public DateTime RegistrationDate;
    public Guid Customer_Id;
    public string Email = string.Empty;
    public string PhoneNumber = string.Empty;
    public string City = string.Empty;
    public string Province = string.Empty;
    public string Country = string.Empty;
    public string Nationality = string.Empty;
    public DateOnly BirthDate;
    public char? MiddleInitial = null;
    public string? Suffix = null;
}