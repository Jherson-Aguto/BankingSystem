namespace CSBank.Application.Models;

public record RequestAccountDto(
    Guid CustomerId,
    string AccountNumber,
    string Currency
);