using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IRegisterCustomerService
{
    Task<UserDetailsDto?> CustomerAsync
    (CustomerDto customerDto, PrivateInfoDto privateInfo);
}