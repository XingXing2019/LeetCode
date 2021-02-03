with cte as (select log_id, log_id + row_number() over (order by log_id desc) as sum from logs)
select min(log_id) as start_id, max(log_id) as end_id from cte group by sum order by start_id;