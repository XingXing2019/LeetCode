select state, group_concat(city order by city separator ', ') as cities
from Cities
group by state
order by state