SELECT TOP 1 question_id AS survey_log FROM survey_log WHERE answer_id IS NOT NULL GROUP BY question_id
ORDER BY COUNT(answer_id) DESC 