using System.Security.Cryptography;

namespace CSBank.Domain.Services.Account;

public class AccountDomainService
{
    public string GenerateAccountNumber(string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException(
                "Currency code is required.",
                nameof(currency));

        if (currency.Length < 2)
            throw new ArgumentException(
                "Currency code must contain at least two characters.",
                nameof(currency));

        string uniqueId = Guid.NewGuid().ToString("N") + DateTime.UtcNow.ToString();
        string code = currency[..2];
        string cleanCut = new string(uniqueId.Where(char.IsDigit).ToArray());

        return string.Concat(code, cleanCut[..14]).ToUpperInvariant();
    }

    public string GenerateReferenceNumber()
    {
        string uniqueId = Guid.NewGuid().ToString("N") + RandomNumberGenerator.GetInt32(1, 9999).ToString();
        string cleanNumber = new string(uniqueId.Where(char.IsDigit).ToArray());
        string date = DateTime.UtcNow.ToString();
        string cleanDate = new string(date.Where(char.IsDigit).ToArray());

        return string.Concat(cleanNumber, cleanDate)[..20];
    }
}