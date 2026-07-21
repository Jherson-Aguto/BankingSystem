using CSBank.Application.Models;

namespace CSbank.Application.Mapper;

public static class MapAccount
{
    public static Object ToParameters(AccountDto dto)
    {
        return new
        {
            CustomerId = dto.CustomerId,
            AccountNumber = dto.AccountNumber,
            Currency = dto.Currency,
            CreatedAt = dto.CreatedAt,
            AccountStatus = dto.AccountStatus.ToString()
        };
    }
}