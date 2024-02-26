with CandidatsSkill as (
	select * from Candidates
    where skill in ('Python', 'Tableau', 'PostgreSQL')
)

select candidate_id from CandidatsSkill
group by candidate_id
having count(distinct skill) = 3
order by candidate_id