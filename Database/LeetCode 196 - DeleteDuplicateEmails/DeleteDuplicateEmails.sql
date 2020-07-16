DELETE FROM Person
WHERE id NOT IN (
	SELECT * 
	FROM (
		SELECT MIN(Id) FROM Person GROUP BY Email
	) AS p	
);
