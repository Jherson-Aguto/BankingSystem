using CSBank.Application.Models;

namespace CSbank.Application.Interfaces.Services;

public interface IDepositService
{
    Task<TransactionDto?> DepositAmountAsync(RequestDepositUpperDto requestDepositDto);
}