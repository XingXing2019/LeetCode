SELECT first_name, type, CONVERT(VARCHAR, DATEADD(SECOND, duration, CONVERT(DATETIME, 0.0)), 108) AS duration_formatted
FROM (
	SELECT *, RANK() OVER(PARTITION BY type ORDER BY duration DESC) AS rank
	FROM Calls
) AS t
JOIN Contacts ON id = contact_id
WHERE rank <= 3
ORDER BY type, duration DESC