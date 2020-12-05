SELECT sa.student_name member_A, sb.student_name member_B, sc.student_name member_C
FROM schoola sa
JOIN schoolb sb
JOIN schoolc sc
WHERE (
	sa.student_id != sb.student_id and
	sa.student_id != sc.student_id and
	sb.student_id != sc.student_id
) AND (
	sa.student_name != sb.student_name and
	sa.student_name != sc.student_name and
	sb.student_name != sc.student_name
);