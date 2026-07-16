BEGIN;

CREATE TABLE IF NOT EXISTS Users.Customer_Details(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    suffix VARCHAR(100),
    registration_date TIMESTAMPTZ,
    middle_initial CHAR(1)
);

CREATE TABLE IF NOT EXISTS Users.Private_Information(
    customer_id UUID PRIMARY KEY DEFAULT gen_random_uuid() REFERENCES Users.Customer_Details(id) ON DELETE CASCADE,
    email VARCHAR(254) NOT NULL UNIQUE,
    phone_number VARCHAR(100) NOT NULL,
    city VARCHAR(100) NOT NULL,
    province VARCHAR(100) NOT NULL,
    country VARCHAR(100) NOT NULL,
    nationality VARCHAR(100) NOT NULL,
    birth_date DATE NOT NULL CHECK(birth_date <= CURRENT_DATE)
);

ROLLBACK; --change it to COMMIT if you want to run and save it into your database