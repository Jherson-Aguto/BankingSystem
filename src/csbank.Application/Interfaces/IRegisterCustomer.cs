using CSBank.Application.Models;

namespace CSBank.Application.Interfaces;

public interface IRegister
{
    Task Register(CustomerDto customerDto, PrivateInfoDto privateInfo);
}