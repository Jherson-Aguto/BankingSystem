namespace CSbank.Application.Models;

public record RequestTransferDto(
    string AccountNumber,
    decimal TransferFundValue,
    string RecipientAccountNumber,
    string? Description
);

public record RequestParameterDto(
    string AccountNumber,
    decimal TransferFundValue,
    string RecipientAccountNumber,
    string ReferenceNumber,
    string? Description
);