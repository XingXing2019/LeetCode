WITH fails AS (SELECT fail_date, DATEDIFF(DAY, '2019-01-01', fail_date) AS days, ROW_NUMBER() OVER(ORDER BY fail_date) AS row_numbers FROM failed WHERE fail_date BETWEEN '2019-01-01' AND '2019-12-31'),
successes AS (SELECT success_date, DATEDIFF(DAY, '2019-01-01', success_date) AS days, ROW_NUMBER() OVER(ORDER BY success_date) AS row_numbers FROM succeeded WHERE success_date BETWEEN '2019-01-01' AND '2019-12-31')
SELECT 'failed' AS period_state, MIN(fail_date) AS start_date, MAX(fail_date) AS end_date FROM fails GROUP BY (days - row_numbers) 
UNION ALL 
SELECT 'succeeded' AS period_state, MIN(success_date) AS start_date, MAX(success_date) AS end_date FROM successes GROUP BY (days - row_numbers)
ORDER BY start_date