with conversion_rate as (
	select m.member_id, m.name, 
	if (count(distinct v.visit_id) = 0, -1, count(distinct p.visit_id) / count(distinct v.visit_id) * 100) as conversion_rate
	from members m
	left join visits v on m.member_id = v.member_id
	left join purchases p on v.visit_id = p.visit_id
	group by m.member_id, m.name
)

select member_id, name, 
case
	when conversion_rate >= 80 then 'Diamond'
    when conversion_rate >= 50 and conversion_rate < 80 then 'Gold'
    when conversion_rate >= 0 and conversion_rate < 50 then 'Silver'
    else 'Bronze'
end as category
from conversion_rate