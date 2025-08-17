SELECT b.book_id, title, author, genre, pages, rating_spread, polarization_score
FROM books b
JOIN (
	SELECT 
		book_id,
		MAX(session_rating) - MIN(session_rating) AS rating_spread,
		ROUND(SUM(IIF(session_rating <= 2 OR session_rating >= 4, 1, 0)) * 1.0 / COUNT(*), 2) AS polarization_score
	FROM reading_sessions 
	GROUP BY book_id
	HAVING MIN(session_rating) <= 2
	AND MAX(session_rating) >= 4
	AND COUNT(*) >= 5
) AS t ON t.book_id = b.book_id
WHERE polarization_score >= 0.6
ORDER BY polarization_score DESC, title DESC