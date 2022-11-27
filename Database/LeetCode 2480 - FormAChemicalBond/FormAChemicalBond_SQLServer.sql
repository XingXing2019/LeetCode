SELECT e1.symbol AS metal, e2.symbol AS 'nonmetal'
FROM Elements e1
JOIN Elements e2
ON e1.type = 'Metal' AND e2.type = 'Nonmetal'