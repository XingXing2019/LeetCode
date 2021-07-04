with SameSong as (select l1.user_id as user1, l2.user_id as user2
from Listens l1
cross join Listens l2
where l1.user_id <> l2.user_id and l1.song_id = l2.song_id and l1.day = l2.day
group by l1.user_id, l2.user_id, l1.day
having COUNT(distinct l1.song_id) >= 3),

Friends as (
	select user1_id as user1, user2_id as user2 from Friendship
	union all
	select user2_id as user1, user1_id as user2 from Friendship
)

select distinct s.user1 as user_id, s.user2 as recommended_id 
from SameSong s
left join Friends f
on s.user1 = f.user1 and s.user2 = f.user2
where f.user1 is null and f.user2 is null
