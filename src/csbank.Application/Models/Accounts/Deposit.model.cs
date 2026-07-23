namespace CSbank.Application.Models;

public record DepositDto(
    Guid AccountId,
    string AccountNumber,
    decimal DepositValue,
    bool? isChecking = false);