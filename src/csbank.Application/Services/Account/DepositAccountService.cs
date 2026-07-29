using CSbank.Application.Interfaces.IRepositories;
using CSbank.Application.Interfaces.Services;
using CSBank.Application.Mapper;
using CSBank.Application.Models;
using CSBank.Domain.Services.Account;

namespace CSBank.Application.Services;

public class DepositService(
    IDepositRepository deposit,
    AccountDomainService domainService
) : IDepositService
{
    public async Task<TransactionDto?> DepositAmountAsync(RequestDepositUpperDto requestDepositDto)
    {
        string referenceNumber = domainService.GenerateReferenceNumber();

        RequestDepositDto dto = MapAccount.ToParameters(requestDepositDto, referenceNumber);

        return await deposit.DepositAmount(dto);
    }
}