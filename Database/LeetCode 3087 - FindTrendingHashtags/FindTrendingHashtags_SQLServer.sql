SELECT TOP 3 hashtag, COUNT(hashtag) AS hashtag_count
FROM (
	SELECT SUBSTRING(tweet, s, e - s + 1) AS hashtag
	FROM (
		SELECT tweet,
		CHARINDEX('#', tweet) AS s, 
		CASE 
			WHEN CHARINDEX(' ', tweet, CHARINDEX('#', tweet)) = 0 THEN LEN(tweet)
			ELSE CHARINDEX(' ', tweet, CHARINDEX('#', tweet))
		END AS e
		FROM Tweets
		WHERE CHARINDEX('#', tweet) <> 0
		AND DATEPART(YEAR, tweet_date) = 2024
		AND DATEPART(MONTH, tweet_date) = 2
	) AS t
) AS t
GROUP BY hashtag
ORDER BY hashtag_count DESC, hashtag DESC