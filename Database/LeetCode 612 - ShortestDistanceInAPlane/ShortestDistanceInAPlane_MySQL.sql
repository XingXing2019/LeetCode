select distinct min(round(sqrt(abs(p1.x - p2.x) * abs(p1.x - p2.x) + abs(p1.y - p2.y) * abs(p1.y - p2.y)), 2)) as shortest from 
point_2d p1 cross join point_2d p2
where abs(p1.x - p2.x) + abs(p1.y - p2.y) <> 0