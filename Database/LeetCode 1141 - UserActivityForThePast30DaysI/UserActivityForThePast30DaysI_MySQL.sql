SELECT activity_date `day`, COUNT(DISTINCT(user_id)) active_users FROM
activity WHERE activity_date BETWEEN '2019-06-28' AND '2019-07-27'
GROUP BY activity_date;