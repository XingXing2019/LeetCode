select id, count(id) as num from  (select requester_id id from request_accepted
union all
select accepter_id id from request_accepted) t
group by id order by count(id) desc limit 1