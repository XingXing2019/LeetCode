with TopInvoice as (
	select invoice_id
	from Purchases p1
	join Products p2 
	on p1.product_id = p2.product_id
	group by invoice_id
	order by sum(price * quantity) desc, invoice_id
	limit 1
)

select p1.product_id, quantity, (price * quantity) as price
from Purchases p1
join Products p2
on p1.product_id = p2.product_id
where p1.invoice_id = (select * from TopInvoice)