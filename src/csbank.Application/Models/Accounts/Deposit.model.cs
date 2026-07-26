namespace CSbank.Application.Models;

public record RequestDepositDto(
    string AccountNumber,
    decimal DepositValue,
    string ReferenceNumber
);