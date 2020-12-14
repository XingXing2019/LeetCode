SELECT DISTINCT c1.seat_id
FROM cinema c1, cinema c2
WHERE ABS(c1.seat_id - c2.seat_id) = 1 AND c1.free = 1 AND c2.free = 1
ORDER BY c1.seat_id;