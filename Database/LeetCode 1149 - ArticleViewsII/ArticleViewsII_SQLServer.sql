SELECT DISTINCT viewer_id id FROM views GROUP BY view_date, viewer_id 
HAVING count(DISTINCT article_id) > 1 ORDER BY id