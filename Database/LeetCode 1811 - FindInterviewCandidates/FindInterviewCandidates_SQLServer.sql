WITH cte AS (SELECT contest_id, gold_medal AS medal FROM Contests
UNION ALL 
SELECT contest_id, silver_medal AS medal FROM Contests
UNION ALL
SELECT contest_id, bronze_medal AS medal FROM Contests),

consective AS (
SELECT c1.medal FROM cte c1 JOIN cte c2 ON c1.contest_id = c2.contest_id + 1 AND c1.medal = c2.medal
JOIN cte c3 ON c1.contest_id = c3.contest_id + 2 AND c1.medal = c3.medal)

SELECT name, mail FROM Users 
WHERE user_id IN (SELECT * FROM consective) OR user_id IN (SELECT gold_medal AS candidates FROM Contests GROUP BY gold_medal HAVING COUNT(contest_id) >= 3);

WITH consective AS (SELECT c1.gold_medal c1G, c1.silver_medal c1S, c1.bronze_medal c1B, c2.gold_medal c2G, c2.silver_medal c2S, c2.bronze_medal c2B, c3.gold_medal c3G, c3.silver_medal c3S, c3.bronze_medal c3B FROM
Contests c1 JOIN Contests c2 ON c1.contest_id = c2.contest_id + 1 
JOIN Contests c3 ON c2.contest_id = c3.contest_id + 1),

candidates AS (SELECT c1G AS candidates FROM consective WHERE c1G IN (c2G, c2S, c2B) AND c1G IN (c3G, c3S, c3B)
UNION ALL 
SELECT c1S AS candidates FROM consective WHERE c1S IN (c2G, c2S, c2B) AND c1S IN (c3G, c3S, c3B)
UNION ALL
SELECT c1B AS candidates FROM consective WHERE c1B IN (c2G, c2S, c2B) AND c1B IN (c3G, c3S, c3B)
UNION ALL
SELECT gold_medal AS candidates FROM Contests GROUP BY gold_medal HAVING COUNT(gold_medal) >= 3)

SELECT DISTINCT name, mail FROM candidates LEFT JOIN Users ON candidates = user_id