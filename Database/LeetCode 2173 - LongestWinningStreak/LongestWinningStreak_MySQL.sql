with win_count as (
	select *, 
	sum(if(result = 'win', 0, 1)) over (partition by player_id order by match_day) as win_count
	from matches
),

streak as (
	select player_id, win_count, count(*) - sum(if(result = 'win', 0, 1)) as streak
    from win_count
	group by player_id, win_count
)

select player_id, max(streak) as longest_streak
from streak
group by player_id