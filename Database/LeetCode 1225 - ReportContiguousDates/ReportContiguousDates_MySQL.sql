with fails as (select fail_date, (to_days(fail_date) - row_number() over(order by fail_date)) as row_numbers from failed where fail_date between '2019-01-01' and '2019-12-31'),
successes as (select success_date, (to_days(success_date) - row_number() over(order by success_date)) as row_numbers from succeeded where success_date between '2019-01-01' and '2019-12-31')
select 'failed' as period_state, min(fail_date) as start_date, max(fail_date) as end_date from fails group by (row_numbers)
union all
select 'succeeded' as period_state, min(success_date) as start_date, max(success_date) as end_date from successes group by (row_numbers)
order by start_date