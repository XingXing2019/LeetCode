with recursive cte as (
    select *
    from tweets
    where left(tweet_date, 7) = '2024-02'
),
cte1 as (
    select user_id, tweet_id, tweet_date, regexp_substr(tweet, '[#][^ ]+') as hashtag, regexp_replace(tweet, '[#][^ ]+', '', 1, 1) as tweet
    from cte
    union all
    select user_id, tweet_id, tweet_date, regexp_substr(tweet, '[#][^ ]+') as hashtag, regexp_replace(tweet, '[#][^ ]+', '', 1, 1) as tweet
    from cte1
    where locate('#', tweet, 1) != 0
)

select hashtag, count(hashtag) as 'count'
from cte1
group by hashtag
order by count desc, hashtag desc
limit 3