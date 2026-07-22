# CSBANK Relational Model

## Legend

- PK = Primary Key
- FK = Foreign Key
- UK = Unique Key
- TIMESTAMPTZ = Timestamp with Time Zone

```mermaid
erDiagram
    USERS.CUSTOMER_DETAILS ||--|| USERS.PRIVATE_INFORMATION : has
    USERS.CUSTOMER_DETAILS ||--o{ ACCOUNTS.ACCOUNT_DETAILS : owns
    ACCOUNTS.ACCOUNT_DETAILS ||--o| ACCOUNTS.CHECKING_ACCOUNT : extends
    ACCOUNTS.ACCOUNT_DETAILS ||--o| ACCOUNTS.SAVINGS_ACCOUNT : extends
    ACCOUNTS.ACCOUNT_DETAILS ||--o{ TRANSACTIONS.TRANSACTION_HISTORY : has

    USERS.CUSTOMER_DETAILS {
        UUID id PK
        VARCHAR first_name
        VARCHAR last_name
        VARCHAR suffix "optional"
        TIMESTAMPTZ registration_date
        CHAR middle_initial "optional"
    }
    
    USERS.PRIVATE_INFORMATION {
        UUID customer_id PK,FK
        VARCHAR email UK
        VARCHAR phone_number
        VARCHAR city
        VARCHAR province
        VARCHAR country
        VARCHAR nationality
        DATE birth_date
    }

    ACCOUNTS.ACCOUNT_DETAILS{
        UUID id PK
        UUID customer_id FK
        VARCHAR account_number UK
        VARCHAR currency
        TIMESTAMPTZ created_at
        enum account_status "enum: (Active, Frozen, Closed)"
    }

    ACCOUNTS.CHECKING_ACCOUNT{
        UUID account_id PK,FK
        NUMERIC balance
        NUMERIC overdraft_limit
        enum modes_of_payment "enum: (Debit, Online, Check)"
        NUMERIC interest_rate
        NUMERIC fees
    }

    ACCOUNTS.SAVINGS_ACCOUNT{
        UUID account_id PK,FK
        NUMERIC balance
        NUMERIC withdrawal_usage
        NUMERIC interest_rate
        NUMERIC fees
    }

    AUDITS.AUDIT_LOGS{
        UUID id PK
        enum entity_name "enum: ( Customer, Account, CheckingAccount, SavingsAccount, Transaction)"
        UUID entity_id
        enum action "enum: (Created, Updated, Deleted, Login, Logout)"
        UUID performed_by
        TIMESTAMPTZ performed_at
        JSONB old_values
        JSONB new_values
        INET ip_address
        VARCHAR user_agent
    }

    TRANSACTIONS.TRANSACTION_HISTORY{
        UUID id PK
        UUID account_id FK
        enum transaction_type "enum: (Deposit, Withdraw, TransferIn, TransferOut, Interest, Fee)"
        NUMERIC amount
        NUMERIC balance_before
        NUMERIC balance_after
        VARCHAR reference_number UK
        TEXT description
        TIMESTAMPTZ created_at 
    }
```