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
            middle_initial
        )
        VALUES (
            @FirstName,
            @LastName,
            @Suffix,
            @MiddleInitial
        )
        RETURNING *
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
            c.id,
            @Email,
            @PhoneNumber,
            @City,
            @Province,
            @Country,
            @Nationality,
            @BirthDate
        FROM customer AS c
        WHERE c.id IS NOT NULL
        RETURNING *
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
        WHERE c.id IS NOT NULL
    )
    SELECT
        cd.Id,
        cd.first_name AS FirstName,
        cd.last_name AS LastName,
        cd.suffix,
        cd.registration_date AS RegistrationDate,
        cd.middle_initial AS MiddleInitial,
        pi.customer_id AS CustomerId,
        pi.email,
        pi.phone_number AS PhoneNumber,
        pi.city,
        pi.province,
        pi.country,
        pi.nationality,
        pi.birth_date::timestamp AS BirthDate
    FROM customer AS cd
    CROSS JOIN private_info AS pi
    """;
}