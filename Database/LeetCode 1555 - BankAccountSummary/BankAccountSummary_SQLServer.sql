WITH cte AS (
SELECT id, SUM(amount) net FROM (
SELECT paid_by id, -amount amount FROM transactions 
UNION ALL
SELECT paid_to, amount FROM transactions) t GROUP BY id)
SELECT *, (CASE WHEN credit < 0 THEN 'Yes' else 'No' END) AS credit_limit_breached FROM
(SELECT user_id, user_name, (credit + ISNULL(net, 0)) credit FROM users u LEFT JOIN cte c ON u.user_id = c.id) t