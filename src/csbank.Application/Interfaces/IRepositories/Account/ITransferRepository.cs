using CSbank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface ITransferFundRepository
{
    Task<TransactionsDto>
    TransferFund(RequestTransferDto requestTransferDto, string ReferenceNumber);
}