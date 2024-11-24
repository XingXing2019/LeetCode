SELECT 
	book_id,
	title,
	author,
	published_year
FROM Books
WHERE rating IS NULL
ORDER BY book_id