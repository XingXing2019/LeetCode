with friends as (
	select user1_id as user1_id, user2_id as user2_id from friendship
    union all
    select user2_id as user1_id, user1_id as user2_id from friendship
),
common_friends as (
	select f1.user1_id, f2.user2_id as user1_friend, f1.user2_id, f3.user2_id as user2_friend
    from friends f1 
    join friends f2 on f1.user1_id = f2.user1_id
    join friends f3 on f1.user2_id = f3.user1_id
)
select user1_id, user2_id, count(*) as common_friend 
from common_friends
where user1_friend = user2_friend and user1_id < user2_id
group by user1_id, user2_id
having count(*) >= 3