with TriangleSize as (
	select
		A, B, C, A + B + C as sum,
		case
			when A <= B and A <= C then A
			when B <= A and B <= C then B
			else C
		end as min,
		case
			when A >= B and A >= C then A
			when B >= A and B >= C then B
			else C
		end as max
	from Triangles
)

select	
	case
		when sum - max <= max then 'Not A Triangle'
        when A = B and A = C then 'Equilateral'
        when A = B or A = C or B = C then 'Isosceles'
        else 'Scalene'
	end as triangle_type
from TriangleSize