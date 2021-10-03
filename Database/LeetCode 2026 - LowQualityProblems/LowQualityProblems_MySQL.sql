select problem_id
from problems
where likes / (likes + dislikes) < 0.6
order by problem_id