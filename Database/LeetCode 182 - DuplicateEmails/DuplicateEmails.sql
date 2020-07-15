SELECT Email
FROM (
	SELECT Email, COUNT(*) AS num
	FROM Person
	GROUP BY Email
) AS Statistic
WHERE num > 1;