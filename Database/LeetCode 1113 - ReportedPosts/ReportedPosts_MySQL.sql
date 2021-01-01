SELECT a.extra report_reason, COUNT(DISTINCT a.post_id) report_count 
FROM actions a
WHERE DATEDIFF('2019-07-05', a.action_date) = 1 AND a.`action` = 'report'
GROUP BY a.extra;