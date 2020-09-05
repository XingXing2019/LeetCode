SELECT w.name warehouse_name, SUM(p.Width * p.Length * p.Height * w.units) volume
FROM warehouse w INNER JOIN products p
ON w.product_id = p.product_id
GROUP BY w.name;