using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface ITransferRepository
{
    Task TransferOut(TransferOutDto transferOutDto);
}