SELECT a.Id
FROM weather a JOIN weather b
ON DATEDIFF(a.RecordDate, b.RecordDate) = 1
WHERE a.Temperature > b.Temperature;