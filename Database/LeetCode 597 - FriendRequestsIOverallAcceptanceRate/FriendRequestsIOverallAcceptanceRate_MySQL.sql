SELECT 
ROUND(
	IFNULL(
	(SELECT COUNT(*) FROM 
	(SELECT DISTINCT r.requester_id, r.accepter_id FROM request_accepted r) a)
	/
	(SELECT COUNT(*) FROM 
	(SELECT DISTINCT f.sender_id, f.send_to_id FROM friend_request f) b), 0)
, 2) accept_rate;