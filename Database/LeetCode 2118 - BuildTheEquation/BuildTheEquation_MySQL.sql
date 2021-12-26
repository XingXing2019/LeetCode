with equations as (
	select power,
	case when factor > 0 then
		case when power = 0 then concat('+', factor)
		when power = 1 then concat('+', factor, 'X')
		else concat('+', factor, 'X^', power) end
	else
		case when power = 0 then concat('', factor)
		when power = 1 then concat(factor, 'X')
		else concat(factor, 'X^', power) end
	end as equation
	from terms
)

select concat(group_concat(equation order by power desc separator ''), '=0') as equation
from equations
