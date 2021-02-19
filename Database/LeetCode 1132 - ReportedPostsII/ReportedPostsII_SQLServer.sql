WITH spam AS (SELECT * FROM actions WHERE extra = 'spam'),
removeRate AS (SELECT CONVERT(float, COUNT(DISTINCT r.post_id)) / COUNT(DISTINCT s.post_id) AS rate 
FROM spam s LEFT JOIN removals r on s.post_id = r.post_id AND s.action_date < r.remove_date
GROUP BY action_date)
SELECT ROUND(AVG(rate) * 100, 2) AS average_daily_percent FROM removeRate
