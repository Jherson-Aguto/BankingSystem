namespace CSBank.Application.Models;

public record UpdateUserRequest(
    Guid? Id,
    string? FirstName,
    string? LastName,
    string? Suffix,
    char? MiddleInitial,
    string? Email,
    string? PhoneNumber,
    string? City,
    string? Province,
    string? Country,
    string? Nationality,
    DateTime? BirthDate
);