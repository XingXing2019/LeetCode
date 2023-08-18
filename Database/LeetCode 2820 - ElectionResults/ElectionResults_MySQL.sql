with ValidVotes as (
	select * from Votes where candidate is not null
),

FinalVotes as (
	select candidate, sum(weight) as votes
	from ValidVotes v
	join (
		select voter, 1 / count(*) as weight
		from ValidVotes
		group by voter
	) as w
	on v.voter = w.voter
	group by candidate
)

select candidate
from FinalVotes 
where votes = (select max(votes) from FinalVotes)
order by candidate