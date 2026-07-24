using CSBank.Application.Models;

namespace CSbank.Application.Models;

//this bank
public record DepositDto(
    Guid AccountId,
    string AccountNumber,
    decimal DepositValue,
    string? Description,
    bool? IsChecking = false);

public record DepositOutputDto(
    Guid AccountId,
    Guid TransactionId,
    decimal BeforeBalance,
    decimal AfterBalance,
    decimal DepositValue,
    string? Description,
    string? ReferenceNumber,
    TransactionTypes? TransactionType,
    DateTime? TransactionDate
);

public record DepositRepositoryOutputDto(
    Guid AccountId,
    Guid TransactionId,
    decimal BeforeBalance,
    decimal AfterBalance,
    DateTime? TransactionDate
);