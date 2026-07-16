# Customer Details and Private Information 

```mermaid
erDiagram
    USERS.CUSTOMER_DETAILS ||--|| USERS.PRIVATE_INFORMATION : has
    USERS.CUSTOMER_DETAILS ||--|{ ACCOUNTS.ACCOUNT_DETAILS : owns
    ACCOUNTS.ACCOUNT_DETAILS ||--o| ACCOUNTS.CHECKING_ACCOUNT : checking
    ACCOUNTS.ACCOUNT_DETAILS ||--o| ACCOUNTS.SAVINGS_ACCOUNT : savings
    
    USERS.CUSTOMER_DETAILS {
        Guid id PK
        string first_name
        string last_name
        string suffix "optional"
        date registration_date
        char middle_initial "optional"
    }
    
    USERS.PRIVATE_INFORMATION {
        Guid customer_id PK,FK
        string email UK
        string phone_number
        string city
        string province
        string country
        string nationality
        string birth_date
    }

    ACCOUNTS.ACCOUNT_DETAILS{
        Guid id PK
        Guid customer_id FK
        string account_number UK
        string currency
        date created_at
        enum account_status "enum: (Active, Frozen, Closed)"
    }

    ACCOUNTS.CHECKING_ACCOUNT{
        Guid account_id PK,FK
        numeric balance
        numeric overdraft_limit
        enum modes_of_payment "enum: (Debit, Online, Check)"
        numeric interest_rate
        numeric fees
    }

    ACCOUNTS.SAVINGS_ACCOUNT{
        Guid account_id PK,FK
        numeric balance
        numeric withdrawal_usage
        numeric interest_rate
        numeric fees
    }

```