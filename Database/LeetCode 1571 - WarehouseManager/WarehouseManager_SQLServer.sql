SELECT name AS warehouse_name, SUM(units * Width * Length * Height) AS volume 
FROM warehouse w LEFT JOIN products p ON w.product_id = p.product_id
GROUP BY name