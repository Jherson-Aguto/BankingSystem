BEGIN;

CREATE TABLE IF NOT EXISTS users.user_credentials(
    id UUID PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
    user_id UUID NOT NULL,
    password_hash VARCHAR(254) NOT NULL,
    refresh_token_hash VARCHAR(254),
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    role VARCHAR(100) NOT NULL DEFAULT 'Customer'
);

ROLLBACK;