CREATE TABLE guilds (
    guild_id INT AUTO_INCREMENT PRIMARY KEY,
    guild_name VARCHAR(255) NOT NULL,
    guild_leader_id INT NOT NULL,
    member_count INT NOT NULL DEFAULT 1
);

CREATE TABLE guild_members (
    member_id INT AUTO_INCREMENT PRIMARY KEY,
    guild_id INT,
    player_id INT NOT NULL,
    player_name VARCHAR(255) NOT NULL,
    status ENUM('online', 'offline') NOT NULL DEFAULT 'offline',
    location VARCHAR(255),
    FOREIGN KEY (guild_id) REFERENCES guilds(guild_id)
);
