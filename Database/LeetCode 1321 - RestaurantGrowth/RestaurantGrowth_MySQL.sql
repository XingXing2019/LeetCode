with cte1 as (select visited_on, sum(amount) as amount from customer group by visited_on),
cte2 as (select visited_on, sum(amount) over(order by visited_on) as amount from cte1)
select c1.visited_on, c1.amount - ifnull(c2.amount, 0) as amount, round((c1.amount - ifnull(c2.amount, 0)) / 7, 2) as average_amount 
from cte2 c1 left join cte2 c2 on datediff(c1.visited_on, c2.visited_on) = 7
where datediff(c1.visited_on, (select min(visited_on) from customer)) > 5