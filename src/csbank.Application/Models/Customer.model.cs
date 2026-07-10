namespace CSBank.Application.Models;

public record CustomerDto(
    int Id,
    string FirstName,
    string LastName,
    string Suffix,
    PrivateInfoDto? PrivateInfo,
    char? MiddleInitial = null
);