select name as results from (
select name from (
	select u.name from movie_rating mr1 
    join users u on mr1.user_id = u.user_id 
    group by u.name 
    order by count(*) desc, u.name limit 1
) as t1
union
select title from (
	select m.title from movie_rating mr2 
    join movies m on mr2.movie_id = m.movie_id where left(mr2.created_at, 7) = '2020-02' 
    group by m.title 
    order by avg(mr2.rating) desc, m.title limit 1
) as t2) as t3