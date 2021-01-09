select sum(apple) apple_count, sum(orange) orange_count from
(select b.apple_count + ISNULL(c.apple_count, 0) apple, b.orange_count + ISNULL(c.orange_count, 0) orange
from boxes b left join chests c on b.chest_id = c.chest_id) as t