SELECT TOP(1) name FROM candidate LEFT JOIN (
SELECT CandidateId, COUNT(*) count FROM vote GROUP BY CandidateId) t ON id = t.CandidateId 
ORDER BY count DESC