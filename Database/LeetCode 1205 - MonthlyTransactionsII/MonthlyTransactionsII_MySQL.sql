with cte1 as (select left(t.trans_date, 7) month, country, count(*) as count, sum(amount) as amount from transactions t where state = 'approved' group by country, left(t.trans_date, 7)),
cte2 as (select left(c.trans_date, 7) month, country, count(*) as count, sum(amount) as amount from chargebacks c left join transactions t on c.trans_id = t.id group by country, left(c.trans_date, 7)),
cte3 as (select Ifnull(c1.month, c2.month) as month, ifnull(c1.country, c2.country) as country, ifnull(c1.count, 0) as approved_count, ifnull(c1.amount, 0) as approved_amount,
ifnull(c2.count, 0) as chargeback_count, ifnull(c2.amount, 0) as chargeback_amount  from cte1 c1 left join cte2 c2 on c1.country = c2.country and c1.month = c2.month
union all
select Ifnull(c1.month, c2.month) as month, ifnull(c1.country, c2.country) as country, ifnull(c1.count, 0) as approved_count, ifnull(c1.amount, 0) as approved_amount,
ifnull(c2.count, 0) as chargeback_count, ifnull(c2.amount, 0) as chargeback_amount from cte1 c1 right join cte2 c2 on c1.country = c2.country and c1.month = c2.month)
select distinct * from cte3
