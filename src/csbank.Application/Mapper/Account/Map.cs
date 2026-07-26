using CSbank.Application.Models;
using CSBank.Application.Models;

namespace CSbank.Application.Mapper;

public static class MapAccount
{
    public static RequestAccountDto ToParameters(RequestAccountDto requestAccountDto, string accountNumber)
        => new RequestAccountDto(
            CustomerId: requestAccountDto.CustomerId,
            AccountNumber: accountNumber,
            Currency: requestAccountDto.Currency
        );

    public static RequestDepositDto ToParameters(RequestDepositDto requestDepositDto, string referenceNumber)
        => new RequestDepositDto(
            AccountNumber: requestDepositDto.AccountNumber,
            DepositValue: requestDepositDto.DepositValue,
            Description: requestDepositDto.Description,
            ReferenceNumber: referenceNumber
        );

}