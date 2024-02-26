select distinct * from (
	select t1.N,
		case
			when t1.P is null then 'Root'
			when t2.P is null then 'Leaf'
			else 'Inner'
		end as Type
	from Tree t1
	left join Tree t2 on t1.N = t2.P
) as t
order by N
