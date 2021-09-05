with platform as (
	select 'IOS' as platform
	union all
	select 'Android' as platform
	union all
	select 'Web' as platform
),

experiment_name as (
	select 'Programming' as experiment_name
	union all
	select 'Sports' as experiment_name
	union all
	select 'Reading' as experiment_name
)

select p.platform, en.experiment_name, count(distinct e.experiment_id) as num_experiments
from platform p cross join experiment_name en
left join experiments e 
on p.platform = e.platform
and en.experiment_name = e.experiment_name
group by p.platform, en.experiment_name