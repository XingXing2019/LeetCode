SELECT i1.account_id FROM
loginfo i1 JOIN loginfo i2
ON i1.login >= i2.login AND i1.login <= i2.logout 
AND i1.account_id = i2.account_id AND i1.ip_address <> i2.ip_address
GROUP BY i1.account_id