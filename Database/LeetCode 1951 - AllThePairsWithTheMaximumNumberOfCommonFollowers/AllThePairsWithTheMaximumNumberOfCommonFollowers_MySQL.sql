with common as (
	select r1.user_id as user1_id, r2.user_id as user2_id, count(distinct r1.follower_id) as count
    from relations r1 cross join relations r2
    where r1.user_id < r2.user_id and r1.follower_id = r2.follower_id
	group by r1.user_id, r2.user_id
)

select user1_id, user2_id
from common where count = (select max(count) from common)