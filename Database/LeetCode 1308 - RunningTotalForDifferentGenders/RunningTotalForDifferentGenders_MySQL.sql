select gender, day, sum(score_points) over(order by day) as total from scores where gender = 'F'
union
select gender, day, sum(score_points) over(order by day) as total from scores where gender = 'M';

select gender, day, sum(score_points) over(partition by gender order by day) as total from scores;

