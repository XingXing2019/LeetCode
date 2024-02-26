with Pizza as (
	select concat(t1.topping_name, ',', t2.topping_name, ',', t3.topping_name) as pizza, t1.cost + t2.cost + t3.cost as total_cost
    from Toppings t1
    join Toppings t2 on t1.topping_name < t2.topping_name
    join Toppings t3 on t1.topping_name < t2.topping_name and t2.topping_name < t3.topping_name
)

select * from Pizza
order by total_cost desc, pizza asc