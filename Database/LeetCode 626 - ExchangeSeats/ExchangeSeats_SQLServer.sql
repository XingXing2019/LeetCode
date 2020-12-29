select s1.id, case
	when s1.id % 2 <> 0 then ISNULL(s3.student, s1.student)
	else s2.student end as student
from 
seat s1 left join seat s2 on  s1.id = s2.id + 1 
left join seat s3 on s1.id = s3.id - 1;

select case 
	when id % 2 <> 0 and id <> count then id + 1
	when id % 2 <> 0 and id = count then id
	else id - 1 end as id, student
from (
select * from seat, (select count(*) as count from seat) as t) as seatCount
order by id;