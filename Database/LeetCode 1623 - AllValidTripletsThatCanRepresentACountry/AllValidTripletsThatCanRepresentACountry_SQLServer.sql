SELECT a.student_name AS member_A, b.student_name AS member_B, c.student_name AS member_C 
FROM SchoolA a CROSS JOIN SchoolB b CROSS JOIN SchoolC c
WHERE a.student_id <> b.student_id AND a.student_id <> c.student_id AND b.student_id <> c.student_id 
AND a.student_name <> b.student_name AND a.student_name <> c.student_name AND b.student_name <> c.student_name 
