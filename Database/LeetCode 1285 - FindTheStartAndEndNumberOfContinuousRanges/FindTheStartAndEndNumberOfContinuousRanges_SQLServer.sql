WITH cte AS (SELECT log_id, log_id + ROW_NUMBER() OVER(ORDER BY log_id DESC) AS sum FROM logs)
SELECT MIN(log_id) AS start_id, MAX(log_id) AS end_id FROM cte GROUP BY sum