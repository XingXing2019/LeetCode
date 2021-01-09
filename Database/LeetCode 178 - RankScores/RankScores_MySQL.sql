select s.score, t2.rank 
from scores s left join 
(select t1.score, rank() over(order by score desc) as `rank` from (select distinct score from scores) as t1) as t2
on s.score = t2.score
order by t2.rank;
