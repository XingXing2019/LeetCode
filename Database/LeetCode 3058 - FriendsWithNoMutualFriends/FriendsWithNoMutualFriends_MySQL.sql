with AllFriends as (
	select user_id1, user_id2 from Friends
	union
	select user_id2, user_id1 from Friends
)

select * from Friends
where concat(user_id1, '-', user_id2) not in (
	select concat(f1.user_id1, '-', f2.user_id2) as ids
	from AllFriends f1
	join AllFriends f2 on f1.user_id2 = f2.user_id1
	where f1.user_id1 <> f2.user_id2
)
order by user_id1, user_id2
