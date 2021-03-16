SELECT e.left_operand, e.operator, e.right_operand,
	case when e.operator = '=' 
	then if(v1.value = v2.value, 'true', 'false')
	when e.operator = '>' 
	then if(v1.value > v2.value, 'true', 'false')
	ELSE if(v1.value < v2.value, 'true', 'false')
	END AS value 
FROM expressions e 
LEFT JOIN `variables` v1
ON e.left_operand = v1.name
LEFT JOIN `variables` v2
ON e.right_operand = v2.name;
