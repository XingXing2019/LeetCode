select p.project_id, round(avg(convert(decimal, e.experience_years)), 2) as average_years
from project p left join employee e on p.employee_id = e.employee_id group by p.project_id;