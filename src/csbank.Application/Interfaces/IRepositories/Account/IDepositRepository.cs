using CSbank.Application.Models;
using CSBank.Application.Models;

namespace CSbank.Application.Interfaces.IRepositories;

public interface IDepositRepository
{
    Task<TransactionDto> DepositAmount(
        RequestDepositDto requestDepositDto,
        AccountTypes accountType);
}