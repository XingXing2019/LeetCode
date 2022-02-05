with first as (
	select row_number() over(order by first_col) as row_id, first_col from data
),

second as (
	select row_number() over(order by second_col desc) as row_id, second_col from data
)

select first_col, second_col
from first f left join second s
on f.row_id = s.row_id