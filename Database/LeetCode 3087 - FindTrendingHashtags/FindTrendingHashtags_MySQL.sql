select hashtag, count(hashtag) as hashtag_count
from (
	select substring(tweet, s, e - s + 1) as hashtag
	from (
		select tweet, locate('#', tweet) as s, 
		case 
			when locate(' ', tweet, locate('#', tweet)) = 0 then length(tweet)
			else locate(' ', tweet, locate('#', tweet))
		end as e
		from tweets
		where year(tweet_date) = 2024 
		and month(tweet_date) = 2
		and locate('#', tweet) <> 0
	) as t	
) as t
group by hashtag
order by hashtag_count desc, hashtag desc
limit 3