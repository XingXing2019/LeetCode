WITH joined AS (SELECT Status, Request_at FROM Trips t 
LEFT JOIN Users u1 ON t.Client_Id = u1.Users_Id 
LEFT JOIN Users u2 ON t.Driver_Id = u2.Users_Id
WHERE u1.Banned = 'No' AND u2.Banned = 'NO' AND Request_at BETWEEN '2013-10-01' AND '2013-10-03'),
total AS (SELECT Request_at, COUNT(*) AS total FROM joined GROUP BY Request_at),
cancelled AS (SELECT Request_at, COUNT(*) AS cancelled FROM joined WHERE Status <> 'Completed' GROUP BY Request_at)
SELECT t.Request_at AS Day,  ROUND(ISNULL(CONVERT(FLOAT, cancelled) / total, 0.00), 2) AS 'Cancellation Rate'
FROM total t LEFT JOIN cancelled c ON t.Request_at = c.Request_at