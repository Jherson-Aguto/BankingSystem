BEGIN;

WITH customer AS (
    INSERT INTO users.customer_details(
        first_name,
        last_name,
        suffix,
        registration_date,
        middle_initial
    )
    VALUES(
        'Jerry',
        'Aguto',
        NULL,
        CURRENT_TIMESTAMP,
        NULL
    )
    RETURNING id
),
private_info AS(
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
        'jerry@gmail.com',
        '+639759085623',
        'Echague',
        'Isabela',
        'Philippines',
        'Filipino',
        '1982-07-14'
    FROM customer
),
account AS(
    INSERT INTO accounts.account_details(
        customer_id,
        account_number,
        currency,
        created_at,
        account_status
    )
    SELECT
        customer.id,
        'PH31BNOR00000012345679',
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
        200,
        10,
        'Debit',
        2,
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
        500,
        1000,
        3,
        0
    FROM account
)
SELECT * from customer;


ROLLBACK;