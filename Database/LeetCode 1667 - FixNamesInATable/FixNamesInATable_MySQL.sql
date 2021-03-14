SELECT user_id, CONCAT(UPPER(left(NAME, 1)), LOWER(SUBSTR(NAME, 2))) AS name
FROM users
ORDER BY user_id;