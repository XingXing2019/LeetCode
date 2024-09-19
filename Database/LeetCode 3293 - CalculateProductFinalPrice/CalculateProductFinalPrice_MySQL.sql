select p.product_id, p.price * (100 - ifnull(d.discount, 0)) / 100 as final_price, p.category
from products p
left join discounts d on p.category = d.category
order by p.product_id