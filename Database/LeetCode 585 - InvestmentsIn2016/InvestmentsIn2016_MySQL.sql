with cte1 as (select TIV_2015 from insurance group by TIV_2015 having count(TIV_2015) > 1),
cte2 as (select * from (select concat(LAT, '-', LON) as pos from insurance) as t group by pos having count(pos) = 1)
select sum(TIV_2016) as TIV_2016 from insurance where TIV_2015 in (select * from cte1) and concat(LAT, '-', LON) in (select * from cte2)