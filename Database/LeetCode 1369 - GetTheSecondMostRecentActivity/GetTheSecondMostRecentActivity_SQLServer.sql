WITH activityRank AS (SELECT *, RANK() OVER(PARTITION BY username ORDER BY startDate DESC) AS activityRank FROM userActivity), 
temp AS (SELECT *, RANK() OVER(PARTITION BY username ORDER BY activityRank DESC) AS rank FROM activityRank WHERE activityRank <= 2)
SELECT username, activity, startDate, endDate FROM temp WHERE rank = 1