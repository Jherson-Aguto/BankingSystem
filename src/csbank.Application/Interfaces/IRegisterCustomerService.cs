using CSBank.Application.Models;

namespace CSBank.Application.Interfaces;

public interface IRegister
{
    Task<(CustomerDto customerData, PrivateInfoDto privateInfoData)> CustomerAsync
    (CustomerDto customerDto, PrivateInfoDto privateInfo);
}