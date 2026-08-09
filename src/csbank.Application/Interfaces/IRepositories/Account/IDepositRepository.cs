using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface IDepositRepository
{
    Task<TransactionDto?> DepositAmount(
        RequestDepositDto requestDepositDto,
        Guid customerId,
        CancellationToken cancellationToken);
}