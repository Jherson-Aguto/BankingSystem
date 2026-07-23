using CSBank.Application.Models;

namespace CSbank.Application.Models;

public record DepositDto(
    Guid AccountId,
    string AccountNumber,
    decimal DepositValue,
    bool? IsChecking = false);

public record DepositOutputDto(
    Guid AccountId,
    decimal BeforeBalance,
    decimal AfterBalance
// string? TransactionNumber = null,
// TransactionTypes? TransactionType = null,
// decimal? Fee = null,
// DateTime? TransactionDate = null,
// string? Location = null
);