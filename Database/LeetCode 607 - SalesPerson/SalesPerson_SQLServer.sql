select name from salesperson where name not in
(select distinct p.name
from salesperson p 
left join orders o on o.sales_id = p.sales_id 
left join company c on o.com_id = c.com_id
where c.name = 'RED');