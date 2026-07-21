using CSbank.Domain.Request;

namespace CSbank.Domain.Services;

public class UserDomainService
{
    public async Task<CustomerRequest> RegisterCustomerDetails(CustomerRequest customerDetails)
        => customerDetails;

    public async Task<PrivateInfoRequest> RegisterCustomerPrivateInfo(PrivateInfoRequest privateInfo)
    {
        int age = CalculateAge(privateInfo.BirthDate);
        if (age < 18)
            throw new InvalidOperationException
            ("You must be at least 18 years old to register");

        return privateInfo;
    }

    //The Format of the DateOnly is MM/DD/YYYY inside this.
    //Input must be YYYY-MM-DD
    protected int CalculateAge(DateOnly birthDate)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        int age = today.Year - birthDate.Year;

        if (today < birthDate.AddYears(age))
            age--;

        return age;
    }
}