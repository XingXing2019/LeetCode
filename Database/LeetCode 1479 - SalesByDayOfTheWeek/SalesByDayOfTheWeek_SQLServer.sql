WITH temp1 AS (SELECT 
CASE WHEN DATEPART(WEEKDAY, order_date) = 1 THEN 'Sunday'
WHEN DATEPART(WEEKDAY, order_date) = 2 THEN 'Monday'
WHEN DATEPART(WEEKDAY, order_date) = 3 THEN 'Tuesday'
WHEN DATEPART(WEEKDAY, order_date) = 4 THEN 'Wednesday'
WHEN DATEPART(WEEKDAY, order_date) = 5 THEN 'Thursday'
WHEN DATEPART(WEEKDAY, order_date) = 6 THEN 'Friday'
ELSE 'Saturday' END AS day, SUM(quantity) sum, i.item_category FROM orders o 
LEFT JOIN items i ON o.item_id = i.item_id
GROUP BY item_category, DATEPART(WEEKDAY, order_date)),

temp2 AS (SELECT * FROM(SELECT * FROM temp1) AS sourceTable 
PIVOT(MIN(sum) FOR day in ([Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Sunday])) AS pivotTable),

temp3 AS (SELECT DISTINCT item_category FROM items)

SELECT t3.item_category AS CATEGORY, ISNULL(Monday, 0) AS MONDAY, ISNULL(Tuesday, 0) AS TUESDAY, ISNULL(Wednesday, 0) AS WEDNESDAY,
ISNULL(Thursday, 0) AS THURSDAY, ISNULL(Friday, 0) AS FRIDAY, ISNULL(Saturday, 0) AS SATURDAY, ISNULL(Sunday, 0) AS SUNDAY
FROM temp3 t3 LEFT JOIN temp2 t2 on t2.item_category = t3.item_category ORDER BY t3.item_category;