SELECT q.id, q.year, ISNULL(npv, 0) AS npv FROM queries q LEFT JOIN NPV n
ON q.id = n.id and q.year = n.year