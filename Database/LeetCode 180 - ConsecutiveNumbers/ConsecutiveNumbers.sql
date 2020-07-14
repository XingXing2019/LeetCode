SELECT DISTINCT l1.Num AS ConsecutiveNums 
FROM LOGS l1, LOGS l2, LOGS l3
WHERE l1.id = l2.id - 1
AND l2.id = l3.id - 1
AND l1.Num = l2.Num 
AND l2.Num = l3.Num;