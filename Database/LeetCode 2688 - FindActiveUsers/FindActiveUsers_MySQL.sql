with DoubleOrders as (
	select user_id
    from Users
    group by user_id, created_at
    having count(created_at) > 1
),

Orders as (
	select user_id, created_at, dense_rank() over(partition by user_id order by created_at) as orders
    from Users
    where user_id not in (select * from DoubleOrders)
)

select o1.user_id
from Orders o1
left join Orders o2
on o1.user_id = o2.user_id and o1.orders + 1 = o2.orders
where datediff(o2.created_at, o1.created_at) <= 7
union
select * from DoubleOrders