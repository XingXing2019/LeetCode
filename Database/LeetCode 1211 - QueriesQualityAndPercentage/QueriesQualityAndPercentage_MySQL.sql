SELECT query_name, ROUND(AVG(rating / POSITION), 2) quality, ROUND(SUM(case when rating < 3 then 1 ELSE 0 END) / COUNT(*) * 100, 2) poor_query_percentage 
FROM queries
GROUP BY query_name;
