select Min(e2.Name) name from Employee e1 left join Employee e2 on e1.ManagerId = e2.Id
group by e1.ManagerId having count(*) >= 5 and Min(e2.Name) is not null;

select Name from Employee e1 join
(select e2.ManagerId from Employee e2 group by e2.ManagerId having count(*) >= 5) t
on e1.Id = t.ManagerId;