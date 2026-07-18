using System.ComponentModel.DataAnnotations;

namespace CSBank.Application.Models;

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

    public DateOnly BirthDate { get; set; }
};

