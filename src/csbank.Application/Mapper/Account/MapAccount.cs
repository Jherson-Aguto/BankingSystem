using CSBank.Application.Models;

namespace CSBank.Application.Mapper;

public static class MapAccount
{
    public static RequestAccountDto ToParameters(RequestAccountDto requestAccountDto, string? accountNumber)
        => new RequestAccountDto(
            CustomerId: requestAccountDto.CustomerId,
            AccountNumber: accountNumber,
            Currency: requestAccountDto.Currency
        );

    public static RequestAccountDto ToParameters(Guid customerId, string currency, string accountNumber)
        => new RequestAccountDto(
            CustomerId: customerId,
            Currency: currency,
            AccountNumber: accountNumber
        );

    public static RequestDepositDto ToParameters(RequestDepositUpperDto requestDepositDto, string referenceNumber)
        => new RequestDepositDto(
            AccountNumber: requestDepositDto.AccountNumber,
            DepositValue: requestDepositDto.DepositValue,
            Description: requestDepositDto.Description,
            ReferenceNumber: referenceNumber
        );

    public static RequestParameterDto ToParameters(RequestTransferDto requestTransferDto, string referenceNumber)
        => new RequestParameterDto(
            AccountNumber: requestTransferDto.AccountNumber,
            TransferFundValue: requestTransferDto.TransferFundValue,
            RecipientAccountNumber: requestTransferDto.RecipientAccountNumber,
            ReferenceNumber: referenceNumber,
            Description: requestTransferDto.Description
        );
}