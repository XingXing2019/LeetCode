SELECT artist, COUNT(*) AS occurrences
FROM Spotify
GROUP BY artist
ORDER BY COUNT(*) DESC, artist