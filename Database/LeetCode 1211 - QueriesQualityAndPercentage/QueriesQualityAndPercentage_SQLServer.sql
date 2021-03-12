SELECT query_name, ROUND(AVG(CONVERT(FLOAT, rating) / position), 2) AS quality,
ROUND(CONVERT(FLOAT, SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END)) / COUNT(*) * 100, 2) AS poor_query_percentage 
FROM queries GROUP BY query_name
