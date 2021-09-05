DECLARE @Plateform TABLE (platform VARCHAR(20));
DECLARE @Experiment_Name TABLE (experiment_name VARCHAR(20));
INSERT INTO @Plateform VALUES ('IOS');
INSERT INTO @Plateform VALUES ('Android');
INSERT INTO @Plateform VALUES ('Web');
INSERT INTO @Experiment_Name VALUES ('Programming');
INSERT INTO @Experiment_Name VALUES ('Sports');
INSERT INTO @Experiment_Name VALUES ('Reading');

SELECT p.platform, en.experiment_name, COUNT(DISTINCT e.experiment_id) AS num_experiments
FROM @Plateform p CROSS JOIN @Experiment_Name en
LEFT JOIN Experiments e 
ON p.platform = e.platform 
AND en.experiment_name = e.experiment_name
GROUP BY p.platform, en.experiment_name
ORDER BY p.platform;

WITH platform AS (
	SELECT 'Android' AS platform
	UNION ALL
	SELECT 'IOS' AS platform
	UNION ALL
	SELECT 'Web' AS platform
),

experiment_name AS (
	SELECT 'Programming' AS experiment_name
	UNION ALL
	SELECT 'Sports' AS experiment_name
	UNION ALL
	SELECT 'Reading' AS experiment_name
)

SELECT p.platform, en.experiment_name, COUNT(DISTINCT e.experiment_id) AS num_experiments
FROM platform p CROSS JOIN experiment_Name en
LEFT JOIN Experiments e 
ON p.platform = e.platform 
AND en.experiment_name = e.experiment_name
GROUP BY p.platform, en.experiment_name
ORDER BY p.platform

