SELECT TOP(1) id, COUNT(id) num FROM (
SELECT requester_id AS id FROM request_accepted
UNION ALL
SELECT accepter_id AS id FROM request_accepted) t
GROUP BY id ORDER BY count(id) DESC