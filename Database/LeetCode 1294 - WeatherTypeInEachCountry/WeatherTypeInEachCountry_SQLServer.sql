WITH NovemberWeather AS (SELECT w.country_id, c.country_name, AVG(CONVERT(FLOAT, weather_state)) AS temperature
FROM weather w LEFT JOIN countries c ON w.country_id = c.country_id
WHERE day BETWEEN '2019-11-01' AND '2019-11-30'
GROUP BY w.country_id, c.country_name, DATEPART(MONTH, day))

SELECT country_name, CASE WHEN temperature <= 15 THEN 'Cold' WHEN temperature >= 25 THEN 'Hot' ELSE 'Warm' END AS weather_type 
FROM NovemberWeather