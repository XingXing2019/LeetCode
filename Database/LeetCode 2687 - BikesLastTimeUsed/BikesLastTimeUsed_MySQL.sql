select bike_number, max(end_time) as end_time
from Bikes
group by bike_number
order by max(end_time) desc