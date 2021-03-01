SELECT * FROM 
(SELECT * FROM products) AS sourceTable 
PIVOT(MIN(price) FOR store IN ([store1], [store2], [store3]) ) AS pivotTable