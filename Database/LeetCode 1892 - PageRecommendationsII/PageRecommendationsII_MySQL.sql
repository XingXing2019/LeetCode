with friend as (select user1_id as user_id, user2_id as friend from friendship
union all
select user2_id as user_id, user1_id as friend from friendship)

select f.user_id, l1.page_id, count(distinct f.friend) as friends_likes 
from friend f
left join likes l1 on f.friend = l1.user_id
left join likes l2 on f.user_id = l2.user_id and l1.page_id = l2.page_id
where l2.page_id is null
group by f.user_id, l1.page_id