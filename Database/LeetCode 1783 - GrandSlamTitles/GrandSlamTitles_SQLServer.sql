WITH winner AS (SELECT Wimbledon AS winner FROM Championships 
UNION ALL 
SELECT Fr_open AS winner FROM Championships 
UNION ALL 
SELECT US_open AS winner FROM Championships 
UNION ALL 
SELECT Au_open AS winner FROM Championships)

SELECT player_id, player_name, COUNT(*) AS grand_slams_count FROM winner  
LEFT JOIN players ON winner = player_id
GROUP BY player_id, player_name