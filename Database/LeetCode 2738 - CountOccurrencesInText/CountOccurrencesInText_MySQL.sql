select 'bull' as word, count(*) as count
from Files
where content like '% bull %'
union
select 'bear' as word, count(*) as count
from Files
where content like '% bear %'