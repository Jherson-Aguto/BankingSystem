BEGIN;

CREATE TYPE audit.entity_names AS ENUM (
    'Customer',
    'Account',
    'CheckingAccount',
    'SavingsAccount',
    'Transaction'
);

CREATE TYPE audit.actions AS ENUM ('Created', 'Updated', 'Deleted', 'Login', 'Logout');

CREATE TABLE IF NOT EXISTS audit.audit_logs(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    entity_name audit.entity_names NOT NULL,
    entity_id UUID,
    action audit.actions NOT NULL,
    performed_by UUID NOT NULL,
    performed_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    old_values JSONB,
    new_values JSONB,
    ip_address INET,
    user_agent VARCHAR(254)
);

ROLLBACK;