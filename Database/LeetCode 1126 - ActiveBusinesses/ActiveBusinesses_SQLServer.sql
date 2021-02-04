WITH main AS (
SELECT business_id, occurences, AVG(occurences) OVER(PARTITION BY event_type ORDER BY occurences RANGE BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) as avg_occur
FROM Events),
second AS (
SELECT business_id, SUM(CASE WHEN occurences > avg_occur THEN 1 ELSE 0 END) as balance
FROM main
GROUP BY business_id)
SELECT business_id
FROM second
WHERE balance > 1