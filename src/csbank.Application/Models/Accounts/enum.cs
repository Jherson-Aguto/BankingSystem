namespace CSBank.Application.Models;

//accounts
public enum AccountStatus { Active, Frozen, Closed }
public enum ModesOfPayment { Debit, Check, Online }


//transaction
public enum TransactionTypes
{
    Deposit,
    Withdraw,
    TransferIn,
    TransferOut,
    Interest,
    Fee
}