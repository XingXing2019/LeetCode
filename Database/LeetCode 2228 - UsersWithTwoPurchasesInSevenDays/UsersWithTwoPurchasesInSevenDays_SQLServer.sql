SELECT DISTINCT p1.user_id FROM Purchases p1
LEFT JOIN Purchases p2
ON p1.user_id = p2.user_id
AND p1.purchase_id <> p2.purchase_id
WHERE DATEDIFF(DAY, p1.purchase_date, p2.purchase_date) <= 7
AND DATEDIFF(DAY, p1.purchase_date, p2.purchase_date) >= 0