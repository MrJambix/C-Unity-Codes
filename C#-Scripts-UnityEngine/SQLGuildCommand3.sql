SELECT Players.player_name, GuildMembers.rank 
FROM Players 
JOIN GuildMembers ON Players.player_id = GuildMembers.player_id 
WHERE GuildMembers.guild_id = 1;
