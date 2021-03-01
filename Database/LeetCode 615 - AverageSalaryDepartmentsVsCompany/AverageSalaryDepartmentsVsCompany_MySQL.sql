with department as (select left(pay_date, 7) as pay_month, department_id, amount from salary s left join employee e on s.employee_id = e.employee_id),
departmentAvg as (select pay_month, department_id, avg(amount) as departmentAvg from department group by pay_month, department_id),
companyAvg as (select pay_month, avg(amount) as companyAvg from department group by pay_month)
select d.pay_month, d.department_id,
case when departmentAvg = companyAvg then 'same'
when departmentAvg > companyAvg then 'higher'
else 'lower' end as comparison  
from departmentAvg d left join companyAvg c on d.pay_month = c.pay_month 