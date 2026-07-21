BEGIN;

ALTER TABLE accounts.account_details 
ALTER COLUMN created_at DROP NOT NULL;

COMMIT;   