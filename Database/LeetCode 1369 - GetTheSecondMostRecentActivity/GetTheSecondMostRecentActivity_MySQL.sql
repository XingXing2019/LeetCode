with activityRank as (select *, rank() over(partition by username order by startDate desc) as activityRank from useractivity),
temp as (select *, rank() over(partition by username order by activityRank desc) as recentRank from activityRank where activityRank < 3) 
select username, activity, startDate, endDate from temp where recentRank = 1