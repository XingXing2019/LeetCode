with match_words as (
	select distinct post_id, topic_id from 
	posts left join keywords
	on concat(' ', content, ' ') like concat('% ', word, ' %')
)

select post_id, ifnull(group_concat(topic_id order by topic_id), 'Ambiguous!') as topic
from match_words
group by post_id