with winners as (
	select Wimbledon as winners from championships
    union all
    select Fr_open as winners from championships
    union all
    select US_open as winners from championships
    union all
    select Au_open as winners from championships
)
select player_id, player_name, count(*) as grand_slams_count from winners 
left join players on winners = player_id
group by winners