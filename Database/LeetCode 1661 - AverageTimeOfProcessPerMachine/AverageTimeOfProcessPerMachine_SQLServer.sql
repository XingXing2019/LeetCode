select t1.machine_id, round(avg(t2.e-t1.s), 3) as processing_time from 
(select machine_id, process_id, avg(timestamp) as s from Activity where activity_type = 'start' group by machine_id, process_id) t1
join (select machine_id, process_id, avg(timestamp) as e from Activity where activity_type = 'end' group by machine_id, process_id) t2
on t1.machine_id = t2.machine_id and t1.process_id = t2.process_id
group by t1.machine_id;