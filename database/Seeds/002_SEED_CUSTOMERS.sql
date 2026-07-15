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


ROLLBACK;