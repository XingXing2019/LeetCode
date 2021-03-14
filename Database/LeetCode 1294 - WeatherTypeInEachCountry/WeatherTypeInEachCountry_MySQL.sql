SELECT t1.country_name, case 
when AVG <= 15 then 'Cold'
when AVG >= 25 then 'Hot'
ELSE 'Warm'
END AS weather_type 
FROM 
(SELECT c.country_name, AVG(w.weather_state) avg
FROM weather w LEFT JOIN countries c ON w.country_id  = c.country_id
WHERE DAY BETWEEN '2019-11-01' AND '2019-11-30'
GROUP BY w.country_id) t1;