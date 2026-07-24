namespace CSBank.Application.Models;

public record TransferOutDto //doesn't support other banks hehe
(
    //going to replace CustomerId with auth (JWT)
    Guid CustomerId,
    Guid AccountId,
    string AccountNumber,
    string FirstName,
    string LastName,
    decimal TransferAmountValue,
    string RecipientFirstName,
    string RecipientLastName,
    string RecipientAccountNumber,
    string? Purpose,
    bool? IsChecking = false
);