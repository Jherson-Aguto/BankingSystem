namespace CSbank.Domain.Services;

public class UserDomainService
{
    public void RegisterCustomerPrivateInfo(DateTime BirthDate)
    {
        int age = CalculateAge(BirthDate);
        if (age < 18)
            throw new InvalidOperationException
            ("You must be at least 18 years old to register");
    }

    //The Format of the DateOnly is MM/DD/YYYY inside this.
    //Input must be YYYY-MM-DD
    private int CalculateAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        if (today < birthDate.AddYears(age))
            age--;

        return age;
    }
}