SELECT a.id, a.name FROM
(SELECT DISTINCT l1.id FROM
logins l1 LEFT JOIN logins l2 ON l1.id = l2.id
LEFT JOIN logins l3 ON l1.id = l3.id
LEFT JOIN logins l4 ON l1.id = l4.id
LEFT JOIN logins l5 ON l1.id = l5.id
WHERE DATEDIFF(day, l1.login_date, l2.login_date) = 1
AND DATEDIFF(day, l2.login_date, l3.login_date) = 1
AND DATEDIFF(day, l3.login_date, l4.login_date) = 1
AND DATEDIFF(day, l4.login_date, l5.login_date) = 1) AS t
LEFT JOIN accounts a ON t.id = a.id
ORDER BY a.id