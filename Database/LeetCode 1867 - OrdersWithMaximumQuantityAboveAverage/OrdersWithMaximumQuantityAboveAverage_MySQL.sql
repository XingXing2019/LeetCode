with Max as (select max(avg) as max from (select avg(quantity) as avg from OrdersDetails group by order_id) as temp),
orders as (select * from OrdersDetails join Max on 1 = 1 
group by order_id
having max(quantity) > max)
select order_id from orders