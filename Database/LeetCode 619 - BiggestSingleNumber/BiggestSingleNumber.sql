SELECT MAX(num) AS num
FROM (
	SELECT n.num, COUNT(*) AS 'Count'
	FROM my_numbers n
	GROUP BY n.num
) AS s
WHERE COUNT = 1;
