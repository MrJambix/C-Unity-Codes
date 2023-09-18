USE GameDatabase;

CREATE TABLE Guilds (
    GuildID INT AUTO_INCREMENT PRIMARY KEY,
    GuildName VARCHAR(255) NOT NULL,
    GuildLeaderID INT NOT NULL
);

CREATE TABLE GuildMembers (
    MemberID INT AUTO_INCREMENT PRIMARY KEY,
    GuildID INT,
    PlayerID INT NOT NULL,
    JoinDate DATE,
    FOREIGN KEY (GuildID) REFERENCES Guilds(GuildID)
);
