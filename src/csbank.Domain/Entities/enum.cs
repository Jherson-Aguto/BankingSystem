namespace CSbank.Domain.Entities;

//Account
public enum AccountTypes { Savings, Checking }
public enum AccountStatus { Active, Frozen, Closed }

//account type
public enum ModesOfPayment { Debit, Check, Online }

//audit
public enum EntityNames { Customer, Account, CheckingAccount, SavingsAccount, Transaction }
public enum Actions { Created, Updated, Deleted, Login, Logout, TransferFunds }

//transaction history
public enum TransactionTypes { Deposit, Withdraw, TransferIn, TransferOut, Fee }