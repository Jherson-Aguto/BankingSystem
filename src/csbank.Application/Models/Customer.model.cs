namespace CSBank.Application.Models;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Suffix { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public char? MiddleInitial { get; set; } = null;
};