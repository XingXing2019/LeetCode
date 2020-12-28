select max(num) as num 
from (select m.num as num from my_numbers m group by m.num having count(m.num) = 1) as t;