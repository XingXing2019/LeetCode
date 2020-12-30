select t2.project_id, t2.employee_id from (
	select p1.project_id, e1.employee_id, e1.experience_years, t1.years from 
	project p1 left join employee e1 on p1.employee_id = e1.employee_id 
	left join (
		select p2.project_id, max(e2.experience_years) years from 
		project p2 left join employee e2 on p2.employee_id = e2.employee_id 
		group by project_id
	) t1 on p1.project_id = t1.project_id) t2 
where t2.experience_years = t2.years;
