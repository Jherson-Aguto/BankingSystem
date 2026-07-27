using CSbank.Application.Interfaces.IRepositories;
using CSbank.Application.Interfaces.Services;
using CSbank.Application.Mapper;
using CSbank.Application.Models;
using CSbank.Domain.Services.Account;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class DepositService(
    IDepositRepository deposit,
    AccountDomainService domainService
) : IDepositService
{
    public async Task<TransactionDto?> DepositAmountAsync(RequestDepositUpperDto requestDepositDto, AccountTypes accountType)
    {
        string referenceNumber = domainService.GenerateReferenceNumber();

        RequestDepositDto dto = MapAccount.ToParameters(requestDepositDto, referenceNumber);

        return await deposit.DepositAmount(dto, accountType);
    }
}