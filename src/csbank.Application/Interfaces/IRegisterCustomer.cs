using CSBank.Application.Models;

namespace CSBank.Application.Interfaces;

public interface IRegisterCustomer
{
    Task Register(CustomerDto customerDto, PrivateInfoDto privateInfo);
}