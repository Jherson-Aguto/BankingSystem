using CSbank.Application.Models;

namespace CSbank.Application.Interfaces.IRepositories;

public interface IDepositRepository
{
    Task<DepositRepositoryOutputDto?> DepositBalanceAsync(
        DepositDto depositDto,
        string? referenceNumber);
}