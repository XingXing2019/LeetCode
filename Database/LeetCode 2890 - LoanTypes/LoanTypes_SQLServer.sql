SELECT DISTINCT l1.user_id
FROM Loans l1
JOIN Loans l2 ON l1.user_id = l2.user_id
WHERE l1.loan_type = 'Refinance' AND l2.loan_type = 'Mortgage'
ORDER BY l1.user_id