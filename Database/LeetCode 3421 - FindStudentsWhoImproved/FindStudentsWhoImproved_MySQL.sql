with FirstScore as (
	select *, rank() over(partition by student_id, subject order by exam_date) as date_rank
    from Scores    
),

LatestScore as (
	select *, rank() over(partition by student_id, subject order by exam_date desc) as date_rank
    from Scores    
)

select t1.student_id, t1.subject, t1.score as first_score, t2.score as latest_score
from (
	select * from FirstScore
    where date_rank = 1
) as t1
join (
	select * from LatestScore
    where date_rank = 1
) as t2
on t1.student_id = t2.student_id
and t1.subject = t2.subject
where t2.score > t1.score