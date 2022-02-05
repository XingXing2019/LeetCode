WITH first AS (
	SELECT ROW_NUMBER() OVER(ORDER BY first_col) AS order_id, first_col FROM Data
),

second AS (
	SELECT ROW_NUMBER() OVER(ORDER BY second_col DESC) AS order_id, second_col FROM Data
)

SELECT first_col, second_col 
FROM first f 
LEFT JOIN second s
ON f.order_id = s.order_id