namespace CSbank.Domain.Services.Account;

public class AccountDomainService
{
    public string GenerateAccountNumber(string currency)
    {
        string uniqueId = Guid.NewGuid().ToString("N");
        string cut = uniqueId[..18];
        string code = currency[..2];

        return string.Concat(code, cut).ToUpperInvariant();
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