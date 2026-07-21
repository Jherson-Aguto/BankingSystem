BEGIN;

ALTER TABLE accounts.checking_account
ALTER COLUMN balance SET DEFAULT 0,
ALTER COLUMN overdraft_limit SET DEFAULT 0;


ALTER TABLE accounts.savings_account
ALTER COLUMN balance SET DEFAULT 0,
ALTER COLUMN withdrawal_usage SET DEFAULT 0;

ROLLBACK;
