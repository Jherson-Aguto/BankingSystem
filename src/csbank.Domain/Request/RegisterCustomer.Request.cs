namespace CSbank.Domain.Request;

public record CustomerRequest(
    Guid Id,
    string FirstName,
    string LastName,
    string Suffix,
    DateTime RegistrationDate,
    char? MiddleInitial = null
);

public record PrivateInfoRequest(
    Guid Id,
    string Email,
    string PhoneNumber,
    string City,
    string Province,
    string Country,
    string Nationality,
    int Age,
    string BirthDate
);
