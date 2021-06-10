SELECT user_id, MAX(time_stamp) AS last_stamp FROM (
SELECT * FROM Logins WHERE time_stamp BETWEEN '2020-01-01' AND '2021-01-01') AS t
GROUP BY user_id