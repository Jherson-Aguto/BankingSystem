SELECT * FROM users.customer_details c
LEFT JOIN users.private_information p
ON c.id = p.customer_id
LEFT JOIN accounts.account_details a
ON a.customer_id = c.id
LEFT JOIN accounts.checking_account ca
ON ca.account_id = a.id
LEFT JOIN accounts.savings_account sa
ON sa.account_id = a.id;


--For learning [SELECT *] isfine.
--For production later, i'll replace it with explicit columns.
--No issue for now.