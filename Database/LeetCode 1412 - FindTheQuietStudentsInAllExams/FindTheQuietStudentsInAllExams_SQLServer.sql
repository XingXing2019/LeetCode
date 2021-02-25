WITH highest AS (SELECT *, RANK() OVER(PARTITION BY exam_id ORDER BY score DESC) AS topScore FROM exam),
lowest AS (SELECT *, RANK() OVER(PARTITION BY exam_id ORDER BY score) AS bottomScore FROM exam),
topBottomStudents AS (
SELECT DISTINCT student_id FROM (
SELECT * FROM highest h WHERE topScore = 1
UNION ALL
SELECT * FROM lowest WHERE bottomScore = 1) AS t)

SELECT * FROM student WHERE student_id NOT IN (SELECT * FROM topBottomStudents) AND student_id IN (SELECT DISTINCT student_id FROM exam)
ORDER BY student_id