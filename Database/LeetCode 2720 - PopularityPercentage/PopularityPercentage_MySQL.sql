with Users as (
	select user1, user2 from Friends
    union
    select user2, user1 from friends
)

select 
	user1,
    round(count(user2) / (select count(distinct user1) from users) *100, 2) as percentage_popularity 
from users
group by user1
order by user1