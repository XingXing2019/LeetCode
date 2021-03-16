WITH joined AS (SELECT v1.name AS left_operand, v1.value AS leftVal, operator, v2.name AS right_operand, v2.value AS rightVal 
FROM Expressions e LEFT JOIN Variables v1 ON e.left_operand = v1.name LEFT JOIN Variables v2 ON e.right_operand = v2.name)
SELECT left_operand, operator, right_operand, 
CASE WHEN (leftVal = rightVal AND operator = '=' OR leftVal > rightVal AND operator = '>' OR leftVal < rightVal AND operator = '<') THEN 'true'
ELSE 'false' END AS value FROM joined