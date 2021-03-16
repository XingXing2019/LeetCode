WITH sub AS (SELECT DISTINCT sub_id FROM submissions WHERE parent_id IS NULL),
comments AS (SELECT parent_id, COUNT(DISTINCT sub_id) AS number_of_comments FROM submissions GROUP BY parent_id)
SELECT sub_id AS post_id, ISNULL(number_of_comments, 0) AS number_of_comments
FROM sub s LEFT JOIN comments c ON s.sub_id = c.parent_id