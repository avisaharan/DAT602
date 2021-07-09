DROP DATABASE IF EXISTS SnakeandLadder;
CREATE DATABASE SnakeAndLadder;
USE SnakeAndLadder;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DDL`()
BEGIN
    
CREATE TABLE `gamesession` (
  `gameID` int NOT NULL AUTO_INCREMENT,
  `gameName` varchar(20) DEFAULT NULL,
  `gameActive` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`gameID`),
  UNIQUE KEY `gameID_UNIQUE` (`gameID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `player` (
  `id` int AUTO_INCREMENT NOT NULL,
  `username` varchar(20) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `highScore` int DEFAULT NULL,
  `isAdmin` tinyint(1) DEFAULT NULL,
  `isOnline` tinyint(1) DEFAULT NULL,
  `loginAttempts` int DEFAULT '0',
  `gameID` int DEFAULT NULL,
  `location` int DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  FOREIGN KEY (`gameID`) REFERENCES gamesession (`gameID`) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tiles` (
  `tileID` int NOT NULL,
  `xPosition` int DEFAULT NULL,
  `yPosition` int DEFAULT NULL,
  `hasSnake` tinyint(1) DEFAULT '0',
  `hasLadder` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`tileID`),
  UNIQUE KEY `tileID_UNIQUE` (`tileID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `message` (
  `messageID` int NOT NULL,
  `gameID` int NOT NULL,
  `playerID` int NOT NULL,
  `message` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`messageID`),
  UNIQUE KEY `messageID_UNIQUE` (`messageID`),
  FOREIGN KEY (`playerID`) REFERENCES player (`id`) ON UPDATE CASCADE ON DELETE CASCADE,
  FOREIGN KEY (`gameID`) REFERENCES gamesession (`gameId`) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
END$$
DELIMITER ;