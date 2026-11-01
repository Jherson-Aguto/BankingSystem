using CSBank.Application.Mapper;
using CSBank.Application.Models;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using CSBank.Application.Interfaces.IRepositories;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class TransferFundRepository(HelperFactory db) : ITransferFundRepository
{
    public async Task<TransactionsDto?> TransferFund(
        RequestTransferDto requestTransferDto,
        string ReferenceNumber,
        Guid customerId,
        CancellationToken cancellationToken)
    {
        return await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {
                var command = new CommandDefinition(
                    commandText: TransferQuery.Transfer,
                    parameters: (MapAccount.ToParameters(requestTransferDto, ReferenceNumber), customerId),
                    transaction: transaction,
                    commandTimeout: 60,
                    cancellationToken: cancellationToken
                );

                var results = (await connection.QueryAsync<TransactionDto, TransactionDto, TransactionsDto>(
                    command,
                    (TransactionDto transactionDtoOut, TransactionDto transactionDtoIn) =>
                         new TransactionsDto(transactionDtoOut, transactionDtoIn),
                    splitOn: "id")).SingleOrDefault();

                return results;
            }
        );
    }
}