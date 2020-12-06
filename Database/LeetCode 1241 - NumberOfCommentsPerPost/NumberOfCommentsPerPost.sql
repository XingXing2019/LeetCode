SELECT t1.sub_id post_id, 
case when t2.number_of_comments IS NULL then 0 
ELSE t2.number_of_comments 
END AS number_of_comments 
FROM 
(SELECT DISTINCT sub_id FROM submissions WHERE parent_id IS NULL) t1
LEFT JOIN (SELECT COUNT(DISTINCT sub_id) number_of_comments, parent_id, sub_id FROM submissions 
GROUP BY parent_id) t2 ON t1.sub_id = t2.parent_id
ORDER BY post_id;