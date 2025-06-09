WITH borrowed_books AS (
	SELECT book_id, COUNT(*) AS count 
	FROM borrowing_records
	WHERE return_date IS NULL
	GROUP BY book_id
)

SELECT l.book_id, title, author, genre, publication_year, b.count AS current_borrowers
FROM library_books l
LEFT JOIN borrowed_books b
ON l.book_id = b.book_id
WHERE l.total_copies = b.count
ORDER BY b.count DESC, title