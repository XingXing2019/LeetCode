with CoordinateRows as (
	select *, row_number() over() as CoordinateRows 
	from Coordinates 
)

select distinct c1.X, c1.Y
from CoordinateRows c1
join CoordinateRows c2
on c1.X = c2.Y and c1.Y = c2.X and c1.CoordinateRows <> c2.CoordinateRows
where c1.X <= c1.Y
order by c1.X, c1.Y