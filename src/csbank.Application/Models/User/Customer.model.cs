using System.ComponentModel.DataAnnotations;

namespace CSBank.Application.Models;

public class CustomerDto
{
    public Guid? Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be in between 2 to 100 characters!")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be in between 2 to 100 characters!")]
    public string LastName { get; set; } = string.Empty;

    public string? Suffix { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }

    public char? MiddleInitial { get; set; } = null;
};

public class PrivateInfoDto
{
    public Guid CustomerId { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;

    [Required]
    public string Province { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = string.Empty;

    [Required]
    public string Nationality { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }
};

public record UserDetailsDto(
    CustomerDto CustomerDto,
    PrivateInfoDto PrivateInfoDto
);

public record RequestUserDetailsDto(
    string FirstName,
    string LastName,
    string? Suffix,
    char? MiddleInitial,
    string Password,
    string Email,
    string PhoneNumber,
    string City,
    string Province,
    string Country,
    string Nationality,
    DateTime BirthDate
);
