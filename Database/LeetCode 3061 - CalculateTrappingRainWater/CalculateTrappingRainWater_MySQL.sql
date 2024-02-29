with LeftMax as (
	select id, max(height) over(order by id) as left_max from Heights
),

RightMax as (
	select id, max(height) over(order by id desc) as right_max from Heights
),

MinHeight as (
	select l.id, if(left_max < right_max, left_max, right_max) as min_height
	from LeftMax l join RightMax r on l.id = r.id
)

select sum(if(min_height > height, min_height - height, 0)) as total_trapped_water
from MinHeight m join Heights h on m.id = h.id
