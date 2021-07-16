SELECT s.user_id, ISNULL(rate, 0) AS confirmation_rate 
FROM Signups s LEFT JOIN (
SELECT user_id, 
ROUND(CONVERT(float, SUM(IIF(action = 'confirmed', 1, 0))) / COUNT(*), 2) AS rate
FROM Confirmations
GROUP BY user_id) t
ON s.user_id = t.user_id
ORDER BY confirmation_rate