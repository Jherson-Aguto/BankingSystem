BEGIN;

ALTER TABLE users.private_information
ALTER COLUMN customer_id DROP DEFAULT;

ROLLBACK;