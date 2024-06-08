SELECT user_id
FROM Emails e
LEFT JOIN Texts t ON e.email_id = t.email_id
AND DATEDIFF(DAY, e.signup_date, t.action_date) = 1
WHERE signup_action = 'Verified'
ORDER BY user_id