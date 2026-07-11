CREATE TABLE IF NOT EXISTS Customer_Details(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    first_name VARCHAR(20) NOT NULL,
    last_name VARCHAR(20) NOT NULL,
    suffix VARCHAR(10),
    registration_date TIMESTAMPTZ,
    middle_initial CHAR(1)
);

CREATE TABLE IF NOT EXISTS Private_Information(
    customer_id UUID PRIMARY KEY REFERENCES Customer_Details(id) ON DELETE CASCADE,
    email VARCHAR(50) UNIQUE NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    city VARCHAR(50) NOT NULL,
    province VARCHAR(50) NOT NULL,
    country VARCHAR(50) NOT NULL,
    nationality VARCHAR(50) NOT NULL,
    birth_date DATE NOT NULL CHECK (birth_date <= CURRENT_DATE)
);

