BEGIN;

DELETE FROM users.customer_details
WHERE 'agutojherson@gmail.com' IN 
(SELECT email FROM users.private_information);

SELECT first_name FROM users.customer_details
WHERE id = '7003b76e-525f-4ed0-8282-cf79a113f6aa';

ROLLBACK;