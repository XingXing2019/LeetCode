SELECT DISTINCT c.title FROM 
tvprogram t INNER JOIN content c
ON t.content_id = c.content_id
WHERE t.program_date BETWEEN '2020-06-01' AND '2020-06-30' AND 
		c.Kids_content = 'Y' AND 
		c.content_type = 'Movies';