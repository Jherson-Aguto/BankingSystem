using CSBank.Application.Mapper;
using CSBank.Application.Models;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using CSBank.Application.Interfaces.IRepositories;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class TransferFundRepository(HelperFactory db) : ITransferFundRepository
{
    public async Task<TransactionsDto?>
    TransferFund(RequestTransferDto requestTransferDto, string ReferenceNumber)
    {
        return await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {
                var results = (await connection.QueryAsync<TransactionDto, TransactionDto, TransactionsDto>(
                    TransferQuery.Transfer,
                    (TransactionDto transactionDtoOut, TransactionDto transactionDtoIn) =>
                         new TransactionsDto(transactionDtoOut, transactionDtoIn),
                    MapAccount.ToParameters(requestTransferDto, ReferenceNumber),
                    transaction,
                    splitOn: "id")).SingleOrDefault();

                return results;
            }
        );
    }
}