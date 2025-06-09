WITH reviews AS (
	SELECT *, RANK() OVER(PARTITION BY employee_id ORDER BY review_date DESC) AS date_rank 
	FROM performance_reviews
)

SELECT e.employee_id, name, improvement_score 
FROM employees e JOIN (
	SELECT r1.employee_id, r3.rating - r1.rating AS improvement_score
	FROM reviews r1
	LEFT JOIN reviews r2 ON r1.employee_id = r2.employee_id AND r1.date_rank - r2.date_rank = 1
	LEFT JOIN reviews r3 ON r3.employee_id = r2.employee_id AND r2.date_rank - r3.date_rank = 1
	WHERE r3.date_rank = 1
	AND r1.rating < r2.rating AND r2.rating < r3.rating
) AS t ON e.employee_id = t.employee_id
ORDER BY improvement_score DESC, name