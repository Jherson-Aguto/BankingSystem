namespace CSbank.Application.Models;

public record RequestDepositDto(
    string AccountNumber,
    decimal DepositValue,
    string? Description,
    string? ReferenceNumber
);