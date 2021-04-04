with cte as (
	select contest_id, gold_medal as medal from contests
    union all
    select contest_id, silver_medal as medal from contests
    union all
    select contest_id, bronze_medal as medal from contests
),

consective as (select distinct c1.medal from cte c1 join cte c2 on c1.contest_id = c2.contest_id + 1 and c1.medal = c2.medal
join cte c3 on c1.contest_id = c3.contest_id + 2 and c1.medal = c3.medal)

select name, mail from users where user_id in (select * from consective) 
or user_id in (select gold_medal from contests group by gold_medal having count(contest_id) >= 3)