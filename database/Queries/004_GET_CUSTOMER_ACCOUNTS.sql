SELECT * FROM accounts.account_details a
LEFT JOIN accounts.checking_account ca
ON a.id = ca.account_id
LEFT JOIN accounts.savings_account sa
ON a.id = sa.account_id
WHERE a.customer_id = 'ab16a0b7-837f-47c4-b17b-92d8a5b073c9';