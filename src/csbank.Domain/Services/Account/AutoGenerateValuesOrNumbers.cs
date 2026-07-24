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

    public string GenerateReferenceNumber(DateTime? transactionDate)
    {
        string uniqueId = Guid.NewGuid().ToString("n");
        string numbers = string.Concat(uniqueId.Where(char.IsDigit));
        string cut = numbers[..12];
        string stringDate = transactionDate.ToString()!;
        string noSpaces = stringDate.Replace(" ", string.Empty);

        return string.Concat(noSpaces, cut);
    }
}