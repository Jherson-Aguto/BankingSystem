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
        p.birth_date AS BirthDate    
    FROM users.customer_details c
    LEFT JOIN users.private_information p
    ON c.id = p.customer_id
    WHERE c.id = @id;
    """;
}