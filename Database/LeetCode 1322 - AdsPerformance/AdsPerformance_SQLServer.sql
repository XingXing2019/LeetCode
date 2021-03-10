WITH calc AS (SELECT ad_id, SUM(CASE WHEN action = 'Viewed' THEN 1 ELSE 0 END) AS viewed, SUM(CASE WHEN action = 'Clicked' THEN 1 ELSE 0 END) AS clicked
FROM ads GROUP BY ad_id)

SELECT ad_id, CASE WHEN clicked + viewed = 0 THEN 0
ELSE ROUND(CONVERT(FLOAT, clicked) / (clicked + viewed) * 100, 2) 
END as ctr
FROM calc
ORDER BY ctr DESC, ad_id;

WITH ad AS (SELECT DISTINCT ad_id FROM ads),
total AS (SELECT ad_id, COUNT(*) AS total FROM ads WHERE action <> 'Ignored' GROUP BY ad_id),
viewed AS (SELECT ad_id, COUNT(*) AS views FROM ads WHERE action = 'Clicked' GROUP BY ad_id),
results AS (SELECT a.ad_id, ISNULL(ROUND(CONVERT(FLOAT, v.views) / t.total * 100, 2), 0) AS ctr   
FROM ad a LEFT JOIN total t ON a.ad_id = t.ad_id LEFT JOIN viewed v ON a.ad_id = v.ad_id)

SELECT * FROM results ORDER BY ctr DESC, ad_id