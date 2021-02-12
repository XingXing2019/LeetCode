with cte as (select id, sum(amount) net from 
(select paid_by id, -amount amount from transactions
union all 
select paid_to id, amount from transactions) t group by id)
select *, case when credit < 0 then 'Yes' else 'No' end as credit_limit_breached from (
select user_id, user_name, (credit + ifnull(net, 0)) credit from users left join cte on user_id = id) t