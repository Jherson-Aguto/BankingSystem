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
}