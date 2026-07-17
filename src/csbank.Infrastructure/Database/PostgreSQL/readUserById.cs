namespace CSbank.Infrastructure.Database.PostgreSQL;

public class ReadUserById
{
    public const string readUserQueryById = 
    """
    SELECT * FROM users.customer_details c
    LEFT JOIN users.private_information p
    ON c.id = p.customer_id
    WHERE c.id = @id;
    """;
}