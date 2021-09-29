SELECT COUNT(DISTINCT s1.account_id) AS accounts_count
FROM Subscriptions s1 JOIN Streams s2
ON s1.account_id = s2.account_id
WHERE (s1.start_date BETWEEN '2021-01-01' AND '2021-12-31'
OR s1.end_date BETWEEN '2021-01-01' AND '2021-12-31')
AND s2.stream_date NOT BETWEEN '2021-01-01' AND '2021-12-31'