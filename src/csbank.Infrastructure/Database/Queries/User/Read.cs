namespace CSbank.Infrastructure.Database.PostgreSQL;

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

    public const string Profile =
    """
    WITH customer AS (
        SELECT
            id,
            first_name AS FirstName,
            last_name AS LastName,
            suffix,
            registration_date AS RegistrationDate,
            middle_initial AS MiddleInitial
        FROM users.customer_details
        WHERE id = '4b6b27f5-f8a8-4764-a0ad-ab6afd939b9f'
    ),
    private_info AS (
        SELECT
            customer_id AS CustomerId,
            email,
            phone_number AS PhoneNumber,
            city,
            province,
            country,
            nationality,
            birth_date AS BirthDate  
        FROM users.private_information
        WHERE customer_id = '4b6b27f5-f8a8-4764-a0ad-ab6afd939b9f'
    ),
    accounts AS (
        SELECT
            id,
            customer_id AS CustomerId,
            account_number AS AccountNumber,
            currency,
            created_at AS CreatedAt,
            account_status AS AccountStatus
        FROM accounts.account_details
        WHERE customer_id = '4b6b27f5-f8a8-4764-a0ad-ab6afd939b9f'
    ),
    checking AS (
        SELECT
            ca.account_id AS AccountId,
            balance,
            overdraft_limit AS OverdraftLimit,
            modes_of_payment AS ModesOfPayment,
            interest_rate AS InterestRate,
            fees
        FROM accounts.checking_account ca
        LEFT JOIN accounts.account_details ad
            ON ca.account_id = ad.id
        WHERE ad.customer_id = '4b6b27f5-f8a8-4764-a0ad-ab6afd939b9f'
    ),
    savings AS (
        SELECT
            sa.account_id AS AccountId,
            balance,
            withdrawal_usage AS WithdrawalUsage,
            interest_rate AS InterestRate,
            fees
        FROM accounts.savings_account sa
        LEFT JOIN accounts.account_details ad
            ON sa.account_id = ad.id
        WHERE ad.customer_id = '4b6b27f5-f8a8-4764-a0ad-ab6afd939b9f'
    )
    SELECT *
    FROM 
    customer, 
    private_info, 
    accounts, 
    checking, 
    savings;
    """;
}