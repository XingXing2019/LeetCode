select c.candidate_id
from candidates c 
join rounds r
on c.interview_id = r.interview_id
group by candidate_id
having min(years_of_exp) >= 2
and sum(score) >= 16