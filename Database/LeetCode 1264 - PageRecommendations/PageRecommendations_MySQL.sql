with cte as (select * from friendship where user1_id = 1 or user2_id = 1)
select distinct page_id as recommended_page from
(select distinct user1_id from cte where user1_id <> 1
union all 
select distinct user2_id from cte where user2_id <> 1) as f 
left join likes l on f.user1_id = l.user_id
where page_id not in (select page_id from likes where user_id = 1)
and page_id is not null