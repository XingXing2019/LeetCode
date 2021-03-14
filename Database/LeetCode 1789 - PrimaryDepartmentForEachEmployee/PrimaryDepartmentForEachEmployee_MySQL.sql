select employee_id, department_id 
from (select *, count(employee_id) over(partition by employee_id) as c from employee) as t
where primary_flag = 'Y' or c = 1