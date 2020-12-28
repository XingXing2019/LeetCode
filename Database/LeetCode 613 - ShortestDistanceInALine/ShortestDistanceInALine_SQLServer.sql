select min(abs(p1.x - p2.x)) as shortest
from point p1, point p2
where p1.x - p2.x <> 0