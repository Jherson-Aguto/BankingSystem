using CSbank.Application.Models;
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

    public static DepositOutputDto ToParameters(
        DepositDto depositDto,
        DepositRepositoryOutputDto repoDto,
        string? ReferenceNumberInput)
            => new DepositOutputDto
            (
                AccountId: repoDto!.AccountId,
                TransactionId: repoDto.TransactionId,
                BeforeBalance: repoDto.BeforeBalance,
                AfterBalance: repoDto.AfterBalance,
                DepositValue: depositDto.DepositValue,
                Description: depositDto.Description,
                ReferenceNumber: ReferenceNumberInput,
                TransactionType: TransactionTypes.Deposit,
                TransactionDate: repoDto.TransactionDate
            );
}