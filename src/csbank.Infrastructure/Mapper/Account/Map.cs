using System.Data;
using CSBank.Application.Models;
using Dapper;

namespace CSbank.Infrastructure.Mapper;

internal static class MapAccount
{
    internal static Object ToParameters(AccountDto dto)
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