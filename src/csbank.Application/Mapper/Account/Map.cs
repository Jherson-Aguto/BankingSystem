using CSBank.Application.Models;

namespace CSbank.Application.Mapper;

public static class MapAccount
{
    public static RequestAccountDto ToParameters(RequestAccountDto requestAccountDto, string accountNumber)
        => new RequestAccountDto(
            CustomerId: requestAccountDto.CustomerId,
            AccountNumber: accountNumber,
            Currency: requestAccountDto.AccountNumber
        );

}