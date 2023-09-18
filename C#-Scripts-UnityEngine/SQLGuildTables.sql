CREATE TABLE Guilds (
    guild_id INT AUTO_INCREMENT PRIMARY KEY,
    guild_name VARCHAR(255) NOT NULL,
    description TEXT,
    date_created DATE NOT NULL
);

CREATE TABLE Players (
    player_id INT AUTO_INCREMENT PRIMARY KEY,
    player_name VARCHAR(255) NOT NULL,
    online_status ENUM('Online', 'Offline') NOT NULL
);

CREATE TABLE GuildMembers (
    guild_id INT,
    player_id INT,
    rank VARCHAR(255) NOT NULL,
    date_joined DATE NOT NULL,
    FOREIGN KEY (guild_id) REFERENCES Guilds(guild_id),
    FOREIGN KEY (player_id) REFERENCES Players(player_id)
);
