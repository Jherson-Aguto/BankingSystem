BEGIN;

CREATE TYPE transactions.transaction_types AS ENUM (
    'Deposit', 
    'Withdraw', 
    'TransferIn', 
    'TransferOut', 
    'Interest', 
    'Fee');

CREATE TABLE IF NOT EXISTS transactions.transaction_history(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    account_id UUID NOT NULL REFERENCES accounts.account_details(id) ON DELETE CASCADE,
    transaction_type transactions.transaction_types NOT NULL,
    amount NUMERIC(12, 4) NOT NULL,
    balance_before NUMERIC(12, 4) NOT NULL,
    balance_after NUMERIC(12, 4) NOT NULL,
    reference_number VARCHAR(254) UNIQUE NOT NULL,
    description TEXT,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

ROLLBACK;