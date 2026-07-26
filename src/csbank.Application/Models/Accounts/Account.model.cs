namespace CSBank.Application.Models;

public record AccountDto
(
    Guid? Id,
    Guid CustomerId,
    string? AccountNumber,
    AccountTypes AccountType,
    string Currency,
    decimal Balance,
    DateTime? CreatedAt,
    AccountStatus AccountStatus
);

public record CheckingAccount
(
     Guid? Id,
     decimal OverdraftLimit,
     ModesOfPayment ModesOfPayment,
     decimal? InterestRate,
     decimal? Fees
);

public record SavingsAccount
(
    Guid? Id,
    int WithdrawalUsage,
    decimal InterestRate,
    decimal? Fees
);