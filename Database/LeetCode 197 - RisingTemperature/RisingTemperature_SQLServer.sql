select t.id1 as id from (
select w1.Id as id1, w1.Temperature as t1, w2.Temperature as t2 from weather w1 left join weather w2 on DATEDIFF(DAY, w2.RecordDate, w1.RecordDate) = 1) as t
where t1 > t2;