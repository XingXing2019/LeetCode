select e1.id, e1.month, ifnull(e1.salary, 0) + ifnull(e2.salary, 0) + ifnull(e3.salary, 0) as salary
from employee e1
left join employee e2 on e1.Id = e2.Id and e1.Month = e2.Month + 1
left join employee e3 on e1.Id = e3.Id and e2.Month = e3.Month + 1
left join (select id, max(month) as month from employee group by id) as t on e1.Id = t.Id
where t.month <> e1.month
order by e1.id, e1.month desc