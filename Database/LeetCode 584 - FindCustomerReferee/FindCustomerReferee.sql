SELECT c1.name
FROM customer c1 
WHERE c1.referee_id <> '2' OR c1.referee_id IS NULL;