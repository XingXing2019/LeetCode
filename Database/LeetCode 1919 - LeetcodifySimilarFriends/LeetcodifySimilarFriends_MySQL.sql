with SameSong as (
	select l1.user_id as user1, l2.user_id as user2
	from listens l1 cross join listens l2 
	where l1.user_id <> l2.user_id and l1.song_id = l2.song_id and l1.day = l2.day and l1.user_id < l2.user_id
	group by l1.user_id, l2.user_id, l1.day
	having count(distinct l1.song_id) >= 3
),

Friends as (
	select user1_id as user1, user2_id as user2 from friendship
    union all
    select user2_id as user1, user1_id as user2 from friendship
)

select distinct s.user1 as user1_id, s.user2 as user2_id
from SameSong s join Friends f on s.user1 = f.user1 and s.user2 = f.user2

