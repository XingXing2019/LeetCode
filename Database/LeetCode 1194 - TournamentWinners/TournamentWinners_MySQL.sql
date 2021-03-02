with firstScore as (select first_player as player_id, sum(first_score) as score from matches group by first_player),
secondScore as (select second_player as player_id, sum(second_score) as score from matches group by second_player),
score as (select p.player_id, group_id, (ifnull(f.score, 0) + ifnull(s.score, 0)) as score from players p 
left join firstScore f on p.player_id = f.player_id left join secondScore s on p.player_id = s.player_id),
scoreRank as (select *, rank() over(partition by group_id order by score desc, player_id) as scoreRank from score)

select group_id, player_id from scoreRank where scoreRank = 1