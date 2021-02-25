with recursive recursion as (select product_id, period_start, period_end, average_daily_sales from sales
union all
select product_id, date_add(period_start, interval 1 day), period_end, average_daily_sales from recursion where period_start < period_end),
sum_amount as ( select product_id, left(period_start, 4) as report_year, sum(average_daily_sales) over(partition by product_id, left(period_start, 4)) as total_amount from recursion),
cte as (select distinct * from sum_amount)

select p.product_id, p.product_name, report_year, total_amount from cte c left join product p on c.product_id = p.product_id
order by p.product_id, report_year;

