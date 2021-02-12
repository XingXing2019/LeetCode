select name from candidate left join 
(select candidateId, count(*) count from vote group by candidateId) t on id = candidateId
order by count desc limit 1