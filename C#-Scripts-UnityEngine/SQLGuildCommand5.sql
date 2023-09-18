SELECT Players.player_name 
FROM Players 
JOIN GuildMembers ON Players.player_id = GuildMembers.player_id 
WHERE GuildMembers.guild_id = 1 AND Players.online_status = 'Online';
