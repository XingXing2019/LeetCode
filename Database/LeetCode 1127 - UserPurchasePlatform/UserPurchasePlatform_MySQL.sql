with mobile as (
	select user_id, 'mobile' as platform, spend_date, sum(amount) as total_amount, count(distinct user_id) as total_users
    from spending
	group by user_id, spend_date
	having count(distinct platform) = 1
	and min(platform) = 'mobile'
),
desktop as (
	select user_id, 'desktop' as platform, spend_date, sum(amount) as total_amount, count(distinct user_id) as total_users
    from spending
	group by user_id, spend_date
	having count(distinct platform) = 1
	and min(platform) = 'desktop'
),
mobile_desktop as (
	select user_id, 'both' as platform, spend_date, sum(amount) as total_amount, count(distinct user_id) as total_users
    from spending
    group by user_id, spend_date
    having count(distinct platform) = 2
),
date as (
	select distinct spend_date from spending
),
total as (
	select d.spend_date, ifnull(platform, 'mobile') as platform, ifnull(total_amount, 0) as total_amount, ifnull(total_users, 0) as total_users
	from date d left join mobile m on d.spend_date = m.spend_date
	union all
	select d.spend_date, ifnull(platform, 'desktop') as platform, ifnull(total_amount, 0) as total_amount, ifnull(total_users, 0) as total_users
	from date d left join desktop dt on d.spend_date = dt.spend_date
	union all
	select d.spend_date, ifnull(platform, 'both') as platform, ifnull(total_amount, 0) as total_amount, ifnull(total_users, 0) as total_users
	from date d left join mobile_desktop md on d.spend_date = md.spend_date
)
select spend_date, platform, sum(total_amount) as total_amount, sum(total_users) as total_users
from total
group by spend_date, platform