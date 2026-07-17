namespace CSbank.Infrastructure.Database.PostgreSQL;

public class SaveUserDetails
{
    public const string SaveCustomerDetailsAndPrivateInformation = 
    """
    WITH customer AS (
        INSERT INTO users.customer_details (
            first_name,
            last_name,
            suffix,
            registration_date,
            middle_initial
        )
        VALUES (
            @firstName,
            @lastName,
            @suffix,
            @registrationDate,
            @middleInitial
        )
        RETURNING id
    ),
    private_info AS (
        INSERT INTO users.private_information (
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
            @email,
            @phoneNumber,
            @city,
            @province,
            @country,
            @nationality,
            @birthDate
        FROM customer
    )
    SELECT * FROM customer;
    """;
}