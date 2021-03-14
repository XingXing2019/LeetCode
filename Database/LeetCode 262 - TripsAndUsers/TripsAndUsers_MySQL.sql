with joined as (select status, request_at 
from trips t 
left join users u1 on t.client_id = u1.users_id 
left join users u2 on t.driver_id = u2.users_id
where u1.banned = 'No' and u2.banned = 'no' and request_at between '2013-10-01' and '2013-10-03'),
total as (select request_at, count(*) as total from joined group by request_at),
cancelled as (select request_at, count(*) as cancelled from joined where status <> 'completed' group by request_at)
select t.request_at as Day,  round(ifnull(cancelled / total, 0.00), 2) as 'Cancellation Rate'
from total t left join cancelled c on t.request_at = c.request_at