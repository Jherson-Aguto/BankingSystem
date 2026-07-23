using CSbank.Application.Interfaces.IRepositories;
using CSbank.Application.Interfaces.Services;
using CSbank.Application.Models;

namespace CSBank.Application.Services;

public class DepositService(
    IDepositRepository deposit
) : IDepositService
{
    public async Task<DepositOutputDto> DepositBalanceAsync(DepositDto depositDto)
    {
        return await deposit.DepositBalanceAsync(depositDto);
    }
}