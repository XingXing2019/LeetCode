WITH cte AS (SELECT *, ROW_NUMBER() OVER(PARTITION BY continent ORDER BY name) as row_id FROM student)
SELECT MAX(CASE WHEN continent = 'America' THEN name END) AS 'America',
MAX(CASE WHEN continent = 'Asia' THEN name END) AS 'Asia',
MAX(CASE WHEN continent = 'Europe' THEN name END) AS 'Europe'
FROM cte
GROUP BY row_id