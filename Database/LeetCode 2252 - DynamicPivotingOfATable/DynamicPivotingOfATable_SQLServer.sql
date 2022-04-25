CREATE PROCEDURE PivotProducts AS
BEGIN
	DECLARE @sql_col NVARCHAR(MAX);
	SELECT @sql_col = ISNULL(@sql_col + ',', '') + QUOTENAME(store) FROM Products GROUP BY store ORDER BY store
		
	DECLARE @sql_str NVARCHAR(MAX);
	SET @sql_str = '
	SELECT *
	FROM (SELECT * FROM Products) AS temp 
	PIVOT (SUM(price) FOR store IN ('+ @sql_col +')) AS pvt 
	ORDER BY pvt.product_id'

	EXEC (@sql_str)
END