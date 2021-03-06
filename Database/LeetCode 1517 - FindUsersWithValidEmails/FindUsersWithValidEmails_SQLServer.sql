SELECT * FROM users 
WHERE mail LIKE '[a-zA-Z]%@leetcode.com'
AND mail NOT LIKE '%[^_0-9a-zA-Z.-]%@leetcode.com'