with score as (
	select *
	from schools s join exam e
	on s.capacity >= e.student_count
),

ranks as (
	select school_id, score, 
	rank() over(partition by school_id order by student_count desc, score) as ranks
	from score
)

select s.school_id, if(ranks is null, -1, score) as score
from schools s left join ranks r
on s.school_id = r.school_id
where ranks = 1 or ranks is null