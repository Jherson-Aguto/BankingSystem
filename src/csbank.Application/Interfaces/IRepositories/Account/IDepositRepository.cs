using CSbank.Application.Models;

namespace CSbank.Application.Interfaces.IRepositories;

public interface IDepositRepository
{
    Task<decimal> DepositBalance(DepositDto depositDto);
}