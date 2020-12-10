select distinct l1.Num as ConsecutiveNums  
from Logs l1 join Logs l2 on l1.id = l2.id + 1
join Logs l3 on l2.id = l3.id + 1
where l1.Num = l2.Num and l2.Num = l3.Num;