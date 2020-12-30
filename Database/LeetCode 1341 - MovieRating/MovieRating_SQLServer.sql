select name as results from (
select name from
(select top(1) u.name from Movie_Rating mr1 join users u on mr1.user_id = u.user_id
group by u.name order by count(*) desc, u.name) as t1
union 
select title from
(select top(1) m.title from Movie_Rating mr2 join Movies m on mr2.movie_id = m.movie_id where left(mr2.created_at, 7) = '2020-02' 
group by m.title order by avg(convert(decimal, mr2.rating)) desc, m.title) as t2) as t3;