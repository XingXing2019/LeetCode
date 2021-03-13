SELECT v.customer_id, COUNT(*) count_no_trans 
FROM visits v 
WHERE v.visit_id NOT IN (
SELECT DISTINCT t.visit_id
FROM transactions t)
GROUP BY v.customer_id;