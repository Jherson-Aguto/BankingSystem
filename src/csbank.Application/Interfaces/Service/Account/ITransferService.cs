using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface ITransferFundService
{
    Task<TransactionsDto?>
    TransferFund(RequestTransferDto requestTransferDto);
}