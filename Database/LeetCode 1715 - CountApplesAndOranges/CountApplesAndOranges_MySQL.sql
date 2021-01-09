select sum(b.apple_count + ifnull(c.apple_count, 0)) apple_count, sum(b.orange_count + ifnull(c.orange_count, 0)) orange_count 
from boxes b left join chests c on b.chest_id = c.chest_id;