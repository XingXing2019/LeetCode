WITH ConversionRate AS (
	SELECT m.member_id, m.name, 
	IIF(COUNT(DISTINCT v.visit_id) = 0, -1, CONVERT(FLOAT, COUNT(DISTINCT p.visit_id)) / COUNT(DISTINCT v.visit_id) * 100) AS ConversionRate
	FROM Members m 
	LEFT JOIN Visits v 
	ON m.member_id = v.member_id
	LEFT JOIN Purchases p
	ON v.visit_id = p.visit_id
	GROUP BY m.member_id, m.name
)

SELECT member_id, name,
CASE 
	WHEN ConversionRate >= 80 THEN 'Diamond' 
	WHEN ConversionRate >= 50 AND ConversionRate < 80 THEN 'Gold'
	WHEN ConversionRate >= 0 AND ConversionRate < 50 THEN 'Silver'
	ELSE 'Bronze'
END AS category
FROM ConversionRate