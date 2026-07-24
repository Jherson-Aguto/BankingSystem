using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface ITransferService
{
    Task TransferOut(TransferOutDto transferOutDto);
}