using CSbank.Domain.Request;

namespace CSbank.Domain.Services;

public class RegisterServiceDomain
{
    public async Task<CustomerRequest> RegisterCustomerDetails(CustomerRequest customerDetails)
        => customerDetails;

    public async Task<PrivateInfoRequest> RegisterCustomerPrivateInfo(PrivateInfoRequest privateInfo)
    {
        if (privateInfo.Age < 18)
            throw new InvalidOperationException
            ("You must be at least 18 years old to register");

        return privateInfo;
    }
}