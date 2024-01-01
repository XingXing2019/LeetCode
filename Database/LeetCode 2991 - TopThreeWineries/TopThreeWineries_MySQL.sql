with WineryRank as (
	select *, rank() over(partition by country order by points desc, winery) as winery_rank
    from (
		select country, winery, sum(points) as points
        from Wineries group by country, winery
    ) as t
)

select 
	w1.country,
	concat(w1.winery, ' (', w1.points, ')') as top_winery,
	ifnull(concat(w2.winery, ' (', w2.points, ')'), 'No second winery') as second_winery,
    ifnull(concat(w3.winery, ' (', w3.points, ')'), 'No third winery') as third_winery
from WineryRank w1
left join WineryRank w2 on w1.country = w2.country and w1.winery_rank + 1 = w2.winery_rank
left join WineryRank w3 on w2.country = w3.country and w2.winery_rank + 1 = w3.winery_rank
where w1.winery_rank = 1
order by w1.country