WITH AllCalls AS (
	SELECT caller_id AS caller_id, recipient_id AS recipient_id, call_time FROM Calls
	UNION ALL
	SELECT recipient_id AS caller_id, caller_id AS recipient_id, call_time FROM Calls
),

FirstLastCall AS (
	SELECT caller_id, MIN(call_time) FirstCall, MAX(call_time) LastCall 
	FROM AllCalls
	GROUP BY caller_id, FORMAT(call_time, 'd')
),

FirstCall AS (
	SELECT a.caller_id, a.recipient_id FROM 
	AllCalls a JOIN FirstLastCall f
	ON a.caller_id = f.caller_id
	AND a.call_time = FirstCall
),

LastCall AS (
	SELECT a.caller_id, a.recipient_id FROM 
	AllCalls a JOIN FirstLastCall f
	ON a.caller_id = f.caller_id
	AND a.call_time = LastCall
)

SELECT DISTINCT f.caller_id AS user_id
FROM FirstCall f
JOIN LastCall l 
ON f.caller_id = l.caller_id
AND f.recipient_id = l.recipient_id
