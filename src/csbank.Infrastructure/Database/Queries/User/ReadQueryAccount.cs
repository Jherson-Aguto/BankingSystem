namespace CSBank.Infrastructure.Database.Queries;

public sealed class ReadUser
{
    public const string ById =
    """
    SELECT 
        id,
        c.first_name AS FirstName,
        c.last_name AS LastName,
        suffix,
        c.registration_date AS RegistrationDate,
        c.middle_initial AS MiddleInitial,

        p.customer_id AS CustomerId,
        email,
        p.phone_number AS PhoneNumber,
        p.city,
        p.province,
        p.country,
        p.nationality,
        p.birth_date::timestamp AS BirthDate    
    FROM users.customer_details c
    LEFT JOIN users.private_information p
    ON c.id = p.customer_id
    WHERE c.id = @id;
    """;

    public const string ByEmail =
    """
    WITH customer AS (
        SELECT 
            customer_id
        FROM users.private_information
        WHERE email = @email    
    ),
    password AS (
        SELECT
            id,
            user_id,
            password_hash,
            refresh_token_hash,
            created_at,
            role
        FROM users.user_credentials
        CROSS JOIN customer c
        WHERE c.customer_id = user_id
    )
    SELECT 
        p.id AS Id,
        p.user_id AS UserId,
        p.password_hash AS PasswordHash,
        p.refresh_token_hash AS RefreshTokenHash,
        p.created_at AS CreatedAt,
        p.role::text AS Role
     FROM password AS p
    """;
}