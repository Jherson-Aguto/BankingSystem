CREATE TABLE IF NOT EXISTS Users.Customer_Details(
    id UUID PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    suffix VARCHAR(10),
    registration_date TIMESTAMPTZ,
    middle_initial CHAR(1)
);

CREATE TABLE IF NOT EXISTS Users.Private_Information(
    id UUID PRIMARY KEY REFERENCES Users.Customer_Details(id),
    email VARCHAR(50) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    city VARCHAR(20) NOT NULL,
    province VARCHAR(50) NOT NULL,
    country VARCHAR(50) NOT NULL,
    nationality VARCHAR(20) NOT NULL,
    birth_date DATE NOT NULL CHECK(birth_date <= CURRENT_DATE)
);