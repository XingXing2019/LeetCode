select distinct p1.user_id
from purchases p1
left join purchases p2
on p1.user_id = p2.user_id
and p1.purchase_id <> p2.purchase_id
where datediff(p1.purchase_date, p2.purchase_date) <= 7
and datediff(p1.purchase_date, p2.purchase_date) >= 0
order by user_id