BEGIN;

ALTER TABLE accounts.account_details 
ALTER COLUMN created_at SET NOT NULL;  

COMMIT;   