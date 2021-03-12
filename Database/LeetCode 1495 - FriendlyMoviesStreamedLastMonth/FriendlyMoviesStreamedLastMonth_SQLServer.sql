WITH JuneMovie AS (SELECT content_id FROM TVProgram WHERE program_date BETWEEN '2020-06-01' AND '2020-06-30')

SELECT DISTINCT title 
FROM JuneMovie j LEFT JOIN Content c ON j.content_id = c.content_id
WHERE c.Kids_content = 'Y' AND content_type = 'Movies'