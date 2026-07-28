namespace CSBank.Application.Models;

public record AccountDto
(
    Guid? Id,
    Guid CustomerId,
    string? AccountNumber,
    string AccountType,
    string Currency,
    decimal Balance,
    DateTime? CreatedAt,
    string AccountStatus
);

public record CheckingAccount
(
     Guid? Id,
     decimal OverdraftLimit,
     string ModesOfPayment,
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