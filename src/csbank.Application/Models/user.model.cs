namespace CSBank.Application.Models;

public record AccountDto(
    int Id,
    string AccountNumber,
    decimal Balance,
    string Currency,
    DateTime CreatedAt,
    CustomerDto Customer,
    AccountStatus AccountStatus = AccountStatus.Active
);
