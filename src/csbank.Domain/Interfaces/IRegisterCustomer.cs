using CSbank.Domain.Request;

namespace CSbank.Domain.Interfaces;

public interface IRegisterCustomer
{
    Task RegisterCustomerDetails(CustomerRequest customerDetails);
    Task RegisterCustomerPrivateInfo(PrivateInfoRequest privateInfo);
}