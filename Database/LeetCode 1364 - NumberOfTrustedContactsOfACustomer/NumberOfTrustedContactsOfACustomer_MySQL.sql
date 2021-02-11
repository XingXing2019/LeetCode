with cte as (select user_id, count(user_id) as contacts_cnt, count(customer_id) as trusted_contacts_cnt 
from contacts c1 left join customers c2 on c1.contact_name = c2.customer_name group by user_id) 
select invoice_id, customer_name, price, ifnull(contacts_cnt, 0) as contacts_cnt, ifnull(trusted_contacts_cnt, 0) as trusted_contacts_cnt
from invoices i left join customers c1 on i.user_id = c1.customer_id left join cte c2 on i.user_id = c2.user_id
order by invoice_id