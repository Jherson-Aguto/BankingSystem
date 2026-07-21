BEGIN;

CREATE TYPE accounts.account_status AS ENUM ('Active', 'Frozen', 'Closed');

CREATE TABLE IF NOT EXISTS accounts.account_details(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    customer_id UUID REFERENCES users.Customer_Details(id) ON DELETE CASCADE,
    account_number VARCHAR(100) NOT NULL UNIQUE,
    currency VARCHAR(100) NOT NULL,
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    account_status accounts.account_status NOT NULL     
);

CREATE TYPE accounts.modes_of_payment AS ENUM ('Debit', 'Check', 'Online');

CREATE TABLE IF NOT EXISTS accounts.checking_account(
    account_id UUID PRIMARY KEY REFERENCES accounts.account_details(id) ON DELETE CASCADE,
    balance NUMERIC(12, 4) NOT NULL CHECK(balance >= 0),
    overdraft_limit NUMERIC(12, 4) NOT NULL CHECK(overdraft_limit >= 0),
    modes_of_payment accounts.modes_of_payment NOT NULL,
    interest_rate NUMERIC(12, 4) CHECK(interest_rate BETWEEN 0 AND 100),
    fees NUMERIC(12, 4) CHECK(fees >= 0)
);

CREATE TABLE IF NOT EXISTS accounts.savings_account(
    account_id UUID PRIMARY KEY REFERENCES accounts.account_details(id) ON DELETE CASCADE,
    balance NUMERIC(12, 4) NOT NULL CHECK(balance >= 0),
    withdrawal_usage NUMERIC(12, 4) NOT NULL CHECK (withdrawal_usage >= 0),
    interest_rate NUMERIC CHECK(interest_rate BETWEEN 0 AND 100),
    fees NUMERIC(12, 4) CHECK(fees >= 0)
);

ROLLBACK;
