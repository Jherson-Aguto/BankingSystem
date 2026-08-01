using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IDepositService
{
    Task<TransactionDto?> DepositAmountAsync(RequestDepositUpperDto requestDepositDto);
}