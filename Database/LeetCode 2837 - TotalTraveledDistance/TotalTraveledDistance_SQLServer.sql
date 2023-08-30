SELECT u.user_id, u.name, ISNULL(SUM(r.distance), 0) AS [traveled distance]
FROM Users u
LEFT JOIN Rides r ON u.user_id = r.user_id
GROUP BY u.user_id, u.name
ORDER BY u.user_id