BEGIN;

WITH customer AS(
    INSERT INTO users.customer_details(
        first_name,
        last_name,
        suffix,
        registration_date,
        middle_initial
    )
    VALUES(
        'Jherson',
        'Aguto',
        NULL,
        CURRENT_TIMESTAMP,
        'M'
    )
    RETURNING id
),
private_info AS (
    INSERT INTO users.private_information(
        customer_id,
        email,
        phone_number,
        city,
        province,
        country,
        nationality,
        birth_date
    )
    SELECT
        customer.id,
        'agutojherson@gmail.com',
        '+639686450568',
        'Echague',
        'Isabela',
        'Philippines',
        'Filipino',
        '2004-05-16'::DATE
    FROM customer
),
account AS (
    INSERT INTO accounts.account_details(
        customer_id,
        account_number,
        currency,
        created_at,
        account_status
    )
    SELECT
        customer.id,
        'PH31BNOR00000012345678',
        'PHP',
        CURRENT_TIMESTAMP,
        'Active'
    FROM customer
    RETURNING id
),
checking AS (
    INSERT INTO accounts.checking_account(
        account_id,
        balance,
        overdraft_limit,
        modes_of_payment,
        interest_rate,
        fees
    )
    SELECT
        account.id,
        105000,
        0,
        'Online',
        6,
        0
    FROM account
),
savings AS (
    INSERT INTO accounts.savings_account(
        account_id,
        balance,
        withdrawal_usage,
        interest_rate,
        fees
    )
    SELECT
        account.id,
        253,
        300,
        6,
        0
    FROM account
)
SELECT * FROM customer;

ROLLBACK;