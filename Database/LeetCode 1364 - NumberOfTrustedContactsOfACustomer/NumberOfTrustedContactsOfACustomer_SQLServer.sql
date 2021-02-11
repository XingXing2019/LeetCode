WITH cte AS (SELECT user_id, COUNT(*) AS contacts_cnt, COUNT(customer_id) trusted_contacts_cnt 
FROM contacts c1 LEFT JOIN Customers c2 ON c1.contact_name = c2.customer_name 
GROUP BY user_id)
SELECT invoice_id, customer_name, price, ISNULL(contacts_cnt, 0) contacts_cnt, ISNULL(trusted_contacts_cnt, 0) trusted_contacts_cnt
FROM invoices i 
LEFT JOIN customers c1 ON i.user_id = c1.customer_id
LEFT JOIN cte c2 on i.user_id = c2.user_id
ORDER BY invoice_id