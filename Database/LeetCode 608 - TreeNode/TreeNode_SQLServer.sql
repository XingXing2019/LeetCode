WITH cte AS (
	SELECT t1.id, COUNT(t1.p_id) AS p, COUNT(t2.id) AS c FROM tree t1 LEFT JOIN tree t2 ON t1.id = t2.p_id group by t1.id
)
SELECT id, 'Root' AS Type FROM cte WHERE p = 0
UNION
SELECT id, 'Inner' AS Type FROM cte WHERE p <> 0 AND c <> 0
UNION
SELECT id, 'Leaf' AS Type FROM cte WHERE p <> 0 AND c = 0 