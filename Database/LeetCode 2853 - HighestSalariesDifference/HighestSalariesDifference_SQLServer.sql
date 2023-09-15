DECLARE @MarketingMax INT = (SELECT MAX(salary) FROM Salaries WHERE department = 'Marketing')
DECLARE @EngineeringMax INT = (SELECT MAX(salary) FROM Salaries WHERE department = 'Engineering')
SELECT ABS(@MarketingMax - @EngineeringMax) AS salary_difference