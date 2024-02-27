SELECT DISTINCT s1.user_id
FROM Sessions s1
JOIN Sessions s2 ON s1.user_id = s2.user_id 
WHERE s1.session_id <> s2.session_id 
AND s1.session_type = s2.session_type
AND DATEDIFF(HOUR, s1.session_end, s2.session_start) >= -12 
AND DATEDIFF(HOUR, s1.session_end, s2.session_start) <= 12
ORDER BY s1.user_id