with GenderRank as (
	select 
		user_id, gender,
		case
			when gender = 'female' then 1
			when gender = 'other' then 2
			else 3
		end as gender_rank,
		rank() over(partition by gender order by user_id) as id_rank
	from Genders
)

select user_id, gender
from GenderRank
order by id_rank, gender_rank