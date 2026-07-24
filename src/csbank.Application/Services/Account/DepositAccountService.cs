using CSbank.Application.Interfaces.IRepositories;
using CSbank.Application.Interfaces.Services;
using CSbank.Application.Mapper;
using CSbank.Application.Models;
using CSbank.Domain.Services.Account;

namespace CSBank.Application.Services;

public class DepositService(
    IDepositRepository deposit,
    AccountDomainService domainService
) : IDepositService
{
    public async Task<DepositOutputDto?> DepositBalanceAsync(DepositDto depositDto)
    {
        string referenceNumber = domainService.GenerateReferenceNumber();

        DepositRepositoryOutputDto? repositoryOutput = await deposit.DepositBalanceAsync(depositDto, referenceNumber);

        if (repositoryOutput is null)
            throw new ArgumentNullException("Account not found, please create the selected account type.");

        return MapAccount.ToParameters(depositDto, repositoryOutput!, referenceNumber);
    }
}