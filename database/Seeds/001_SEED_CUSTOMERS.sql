BEGIN;

WITH id AS(
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
)
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
    id,
    'agutojherson@gmail.com',
    '+63 968 645 0568',
    'Echague',
    'Isabela',
    'Philippines',
    'Filipino',
    '2004-05-16'
FROM id;



ROLLBACK;