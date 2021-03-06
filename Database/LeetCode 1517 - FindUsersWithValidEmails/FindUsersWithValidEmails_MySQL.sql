SELECT *
FROM users
WHERE mail REGEXP "^[a-zA-Z]+[a-zA-Z0-9_\.\/\-]*(@leetcode\.com)$";