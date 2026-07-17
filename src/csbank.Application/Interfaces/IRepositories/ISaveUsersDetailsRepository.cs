using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface ISaveUserDetailsRepository
{
    Task SaveCustomerDetailsAsync(CustomerDto customerDetails, PrivateInfoDto privateInformation);
}