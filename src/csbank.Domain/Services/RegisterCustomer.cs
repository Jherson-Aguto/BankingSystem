using CSbank.Domain.Request;

namespace CSbank.Domain.Services;

public class RegisterServiceDomain
{
    public async Task RegisterCustomerDetails(CustomerRequest customerDetails)
        => Console.WriteLine("Registering Customer Information...");

    public async Task RegisterCustomerPrivateInfo(PrivateInfoRequest privateInfo)
    {
        if (privateInfo.Age < 18)
            throw new InvalidOperationException
            ("You must be at least 18 years old to register");

        Console.WriteLine("Private Info Registered!");
    }
}