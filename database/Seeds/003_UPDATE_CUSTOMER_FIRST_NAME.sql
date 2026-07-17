BEGIN;

UPDATE users.customer_details
SET first_name = 'Gerry'
WHERE first_name = 'Jerry'
AND id = '7003b76e-525f-4ed0-8282-cf79a113f6aa';

ROLLBACK;