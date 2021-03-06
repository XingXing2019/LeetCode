WITH totalRides AS (SELECT user_id, SUM(distance) AS travelled_distance FROM rides GROUP BY user_id)
SELECT name, ISNULL(travelled_distance, 0) AS travelled_distance FROM users u LEFT JOIN totalRides t ON u.id = t.user_id 
ORDER BY travelled_distance DESC, name