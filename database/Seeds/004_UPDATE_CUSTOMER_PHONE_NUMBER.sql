BEGIN;

UPDATE users.private_information
SET phone_number = '+639686450567'
WHERE customer_id = '7003b76e-525f-4ed0-8282-cf79a113f6aa';

ROLLBACK;