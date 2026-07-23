SELECT * FROM  accounts.account_details a
LEFT JOIN accounts.savings_account sa
ON sa.account_id = a.id;


--For learning [SELECT *] isfine.
--For production later, i'll replace it with explicit columns.
--No issue for now.