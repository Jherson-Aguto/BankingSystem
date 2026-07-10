namespace CSBank.Application.Models;

public record PrivateInfoDto(
    int Id,
    string Email,
    string PhoneNumber,
    string City,
    string Province,
    string Country,
    string Nationality,
    int Age,
    string BirthDate
);
