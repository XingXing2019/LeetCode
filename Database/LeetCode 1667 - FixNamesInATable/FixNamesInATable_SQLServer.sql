SELECT user_id , UPPER(SUBSTRING(name, 1, 1)) + LOWER(SUBSTRING(name, 2, LEN(name))) AS name
FROM users ORDER BY user_id