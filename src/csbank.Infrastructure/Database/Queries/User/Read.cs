namespace CSbank.Infrastructure.Database.PostgreSQL;

public class ReadUser
{
    public const string ById =
    """
    SELECT * FROM users.customer_details c
    LEFT JOIN users.private_information p
    ON c.id = p.customer_id
    WHERE c.id = @id;
    """;
}