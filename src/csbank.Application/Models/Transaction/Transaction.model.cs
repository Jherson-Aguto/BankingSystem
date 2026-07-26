using CSBank.Application.Models;

namespace CSbank.Application.Models;

public record TransactionDto(
    Guid Id,
    Guid AccountId,
    TransactionTypes TransactionType,
    decimal Amount,
    decimal BalanceBefore,
    decimal BalanceAfter,
    string ReferenceNumber,
    string? Description,
    DateTime CreatedAt
);