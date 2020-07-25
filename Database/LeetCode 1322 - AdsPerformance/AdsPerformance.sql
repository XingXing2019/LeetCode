SELECT a.ad_id, ROUND(IFNULL(clicked / (clicked + viewed) * 100, 0), 2) AS ctr
FROM
(
	SELECT ad_id, 
	SUM(CASE WHEN `action` = 'Clicked' THEN 1 ELSE 0 END) AS clicked, 
	SUM(CASE WHEN `action` = 'Viewed' THEN 1 ELSE 0 END) AS viewed
	FROM ads
	GROUP BY ad_id
) AS a
ORDER BY ctr DESC, ad_id ASC;