SELECT c.first_name, p.email, 
p.phone_number, p.city, 
p.province, p.country
FROM users.customer_details c
LEFT JOIN users.private_information p
ON c.id = p.customer_id
WHERE c.id = 'ab16a0b7-837f-47c4-b17b-92d8a5b073c9'
OR p.email = 'agutojherson@gmail.com';

--However, architecturally, I'd eventually separate these into two business queries:
--GetCustomerProfileById
--GetCustomerProfileByEmail