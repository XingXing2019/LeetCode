select t2.bin, count(t1.bin) total from 
(select 
case when duration / 60 < 5 then '[0-5>' 
when duration / 60 < 10 then '[5-10>'
when duration / 60 < 15 then '[10-15>'
else '15 or more' end as bin
from Sessions) t1
right join (select '[0-5>' bin union select '[5-10>' bin union select '[10-15>' bin union select '15 or more' bin) as t2
on t1.bin = t2.bin
group by t2.bin;