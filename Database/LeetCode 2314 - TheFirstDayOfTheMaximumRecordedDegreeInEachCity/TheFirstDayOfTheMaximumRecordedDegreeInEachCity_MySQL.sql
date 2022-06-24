with MaxDegree as (
	select city_id, max(degree) as max_degree 
	from Weather
	group by city_id
)

select city_id, min(day) as day, degree from (
	select * from Weather 
	where (city_id, degree) in (
		select * from MaxDegree
	)
) as t
group by city_id, degree
order by city_id