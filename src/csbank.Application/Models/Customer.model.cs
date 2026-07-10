namespace CSBank.Application.Models;

public record CustomerDto(
    int Id,
    string FirstName,
    string LastName,
    string Suffix,
    DateTime RegistrationDate,
    char? MiddleInitial = null
);