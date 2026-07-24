namespace CSbank.Infrastructure.Database.Queries;

public sealed class SaveUser
{
    public const string DetailsAndPrivateInformation =
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
    ),
    recorded_logs AS (
        INSERT INTO 
            audit.audit_logs(
                entity_name,
                action,
                performed_by
        )
        SELECT
            'Customer',
            'Created',
            c.id
        FROM customer AS c
    )
    SELECT * FROM customer;
    """;
}