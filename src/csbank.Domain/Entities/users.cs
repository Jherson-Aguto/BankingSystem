
namespace CSBank.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string? Suffix { get; private set; } = string.Empty;
    public DateTime RegistrationDate { get; private set; }
    public char? MiddleInitial { get; private set; }
    public PrivateInformation PrivateInformation { get; private set; } = null!;
    public List<AccountDetails> AccountDetails { get; private set; } = null!;

    private Customer() { }
    public Customer(
        string firstName,
        string lastName,
        string? suffix,
        char? middleInitial
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Suffix = suffix;
        MiddleInitial = middleInitial;
    }


    public bool RemoveSuffix()
    {
        if (string.IsNullOrWhiteSpace(Suffix))
            return false;

        Suffix = null;
        return true;
    }

    public bool RemoveMiddleInitial()
    {
        if (MiddleInitial is null)
            return false;

        MiddleInitial = null;
        return true;
    }

    public bool UpdateFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return false;

        FirstName = firstName;
        return true;
    }

    public bool UpdateLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            return false;

        LastName = lastName;
        return true;
    }

    public bool UpdateSuffix(string suffix)
    {
        if (string.IsNullOrWhiteSpace(suffix))
            return false;

        Suffix = suffix;
        return true;
    }

    public bool UpdateMiddleInitial(char middleInitial)
    {
        if (Char.IsWhiteSpace(middleInitial))
            return false;

        MiddleInitial = middleInitial;
        return true;
    }
}

public class PrivateInformation
{
    public Guid CustomerId { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Province { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;
    public string Nationality { get; private set; } = string.Empty;
    public DateTime BirthDate { get; private set; }

    private PrivateInformation() { }
    public PrivateInformation(
        Guid customerId,
        string email,
        string phoneNumber,
        string city,
        string province,
        string country,
        string nationality,
        DateTime birthDate
    )
    {
        CustomerId = customerId;
        Email = email;
        PhoneNumber = phoneNumber;
        City = city;
        Province = province;
        Country = country;
        Nationality = nationality;
        BirthDate = birthDate;
    }

    public Customer Customer { get; private set; } = null!;
}