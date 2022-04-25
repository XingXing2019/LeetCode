CREATE PROCEDURE UnpivotProducts AS
BEGIN
    DECLARE @sql_col NVARCHAR(MAX);
    WITH Cols AS (
        SELECT NAME FROM SYSCOLUMNS 
        WHERE ID IN (SELECT ID FROM SYSOBJECTS WHERE NAME = 'Products')
        AND NAME <> 'product_id'
    )

    SELECT @sql_col = ISNULL(@sql_col + ',', '') + QUOTENAME(NAME) FROM Cols GROUP BY NAME
    DECLARE @sql_str NVARCHAR(MAX);
    SET @sql_str = '
    SELECT * FROM Products
    UNPIVOT (
        price FOR store IN ('+ @sql_col +')
    ) AS unpvt'

    EXEC (@sql_str)
END