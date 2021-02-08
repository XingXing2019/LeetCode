WITH cte AS (SELECT activity, COUNT(activity) AS count FROM friends GROUP BY activity)
SELECT activity FROM cte WHERE count <> (SELECT MAX(count) FROM cte) AND count <> (SELECT MIN(count) FROM cte)