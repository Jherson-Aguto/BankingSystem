namespace CSbank.Domain.Services.Account;

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

        string uniqueId = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
        string code = currency[..2];
        string cleanCut = new string(uniqueId.Where(char.IsDigit).ToArray());

        return string.Concat(code, cleanCut[..14]).ToUpperInvariant();
    }

    public string GenerateReferenceNumber()
    {
        string uniqueId = Guid.NewGuid().ToString("N");
        string cleanId = new string(uniqueId.Where(char.IsDigit).ToArray()!);
        string date = DateTime.UtcNow.ToString();
        string cleanDate = new string(date.Where(char.IsDigit).ToArray());

        return string.Concat(cleanDate, cleanId);
    }
}