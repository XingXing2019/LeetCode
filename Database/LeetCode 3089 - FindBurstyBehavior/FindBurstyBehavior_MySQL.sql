with FebPost as (
	select * from Posts where post_date between '2024-02-01' and '2024-02-28'
),

AvgWeeklyPost as (
	select user_id, count(post_id) / 4.0 as avg_weekly_posts from FebPost group by user_id
),

MaxPost as (
	select user_id, max(count) as max_7day_posts from (
		select user_id, count(post_id) as count from (
			select p1.*
			from FebPost p1
			left join FebPost p2 on p1.user_id = p2.user_id
			where datediff(p1.post_date, p2.post_date) < 7
			and datediff(p1.post_date, p2.post_date) >= 0
		) as t
		group by user_id, post_date, post_id
	) as t
	group by user_id
)

select a.user_id, max_7day_posts, avg_weekly_posts
from AvgWeeklyPost a
join MaxPost m on a.user_id = m.user_id
where max_7day_posts >= 2 * avg_weekly_posts
order by a.user_id