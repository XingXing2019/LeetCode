select tweet_id
from Tweets
where length(content) > 140
or length(content) - length(replace(content, '@', '')) > 3
or length(content) - length(replace(content, '#', '')) > 3