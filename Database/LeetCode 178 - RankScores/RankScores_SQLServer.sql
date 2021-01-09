select s.score, t2.rank
from scores s left join 
(select score, rank() over(order by score desc) as rank from (select distinct score from scores) as t1) as t2
on s.score = t2.score
order by rank