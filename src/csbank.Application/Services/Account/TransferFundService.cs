using CSbank.Application.Models;
using CSbank.Domain.Services.Account;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;

namespace CSBank.Application.Services;

public class TransferFundService(
    ITransferFundRepository fundRepository,
    AccountDomainService domainService) : ITransferFundService
{
    public async Task<TransactionsDto>
    TransferFund(RequestTransferDto requestTransferDto)
    {
        string referenceNumber = domainService.GenerateReferenceNumber();

        return await fundRepository.TransferFund(requestTransferDto, referenceNumber);
    }
}