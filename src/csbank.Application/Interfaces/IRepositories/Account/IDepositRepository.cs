using CSbank.Application.Models;

namespace CSbank.Application.Interfaces.IRepositories;

public interface IDepositRepository
{
    Task<DepositOutputDto> DepositBalanceAsync(DepositDto depositDto);
}