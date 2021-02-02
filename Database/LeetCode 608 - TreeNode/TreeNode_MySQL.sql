with cte as (Select t1.id, t1.p_id, t2.id as c_id from tree t1 left join tree t2 on t1.id = t2.p_id
group by t1.id)
select id, 'Root' as Type from cte where p_id is null
union
select id, 'Inner' as Type from cte where p_id is not null and c_id is not null
union
select id, 'Leaf' as Type from cte where p_id is not null and c_id is null 