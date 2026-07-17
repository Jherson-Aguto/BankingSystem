using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface ISaveUserRepository
{
    Task DetailsAsync(CustomerDto customerDetails, PrivateInfoDto privateInformation);
}