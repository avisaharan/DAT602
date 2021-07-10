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
  `username` varchar(20) DEFAULT "",
  `password` varchar(20) DEFAULT "",
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

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `admin_delete_game`(pGameName varchar(20))
BEGIN
IF EXISTS(SELECT `GameName` FROM gamesession WHERE `gameName` = pGameName) THEN
	BEGIN
		DELETE FROM gamesession
		WHERE `gameName` = pGameName;
        
		SELECT concat("Deleted", pGameName) AS MESSAGE;
	END;
ELSE
	SELECT concat(pGameName, "does not exist.") AS MESSAGE;
END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `create_new_game`(pGameName varchar(20))
BEGIN
IF exists(SELECT gameName FROM gamesession WHERE gameName=pGameName) THEN
	SELECT concat("Game with the name '",pGameName,"' already exists.") AS Message;
    ELSE
	INSERT INTO gameSession (`gameName`)
    VALUES(pGameName);
    SELECT concat("Game '",pGameName,"' created.") AS MESSAGE;
    END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `after_move`(in pCurrentLocation int, out pnewLocation int)
BEGIN
	IF((SELECT `hasSnake` FROM tiles WHERE `tileID`=pcurrentLocation)=1) THEN
    set pnewLocation=pCurrentLocation-5;
    ELSEIF((SELECT `hasLadder` FROM tiles WHERE `tileID`=pcurrentLocation)=1) THEN
    set pnewLocation=pCurrentLocation+5;
    end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `admin_stop_game`(pGameId int)
BEGIN
UPDATE gameSession
SET `gameActive` = false
WHERE `gameId` = pGameId;
SELECT ('Game Stopped.') AS MESSAGE;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `admin_edit_player`(pUserName varchar(20), pNewPassword varchar(20), ploginAttempts int, phighScore int)
BEGIN

START TRANSACTION;
IF EXISTS(SELECT `userName` FROM player WHERE `userName` = pUserName) THEN
		UPDATE player
		SET `password` = pNewPassword, `loginAttempts`=ploginAttempts
		WHERE `userName` = pUserName;
		SELECT ("Player Data Updated") AS MESSAGE;
END IF;
COMMIT;
    
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `admin_delete_player`(pusername varchar(20))
BEGIN
IF EXISTS(SELECT `userName` FROM player WHERE `userName` = pUserName) THEN
	BEGIN
		DELETE FROM player
		WHERE `userName` = pUserName;
        
		SELECT concat("Deleted", pusername) AS MESSAGE;
	END;
ELSE
	SELECT concat(pUserName, "does not exist.") AS MESSAGE;
END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `admin_access`(pUserName varchar(20))
BEGIN
START TRANSACTION;
	IF EXISTS (SELECT `userName` FROM player WHERE `userName` = pUserName AND `isAdmin` = true) THEN
		BEGIN
			SELECT ("Access granted as Admin") AS MESSAGE;
		END;
	ELSE
	BEGIN
		SELECT ("Only admins can can access this form") AS MESSAGE;
	END;
    END IF;
    COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `find_username`(pUserName varchar(20))
BEGIN
START TRANSACTION;
	SELECT * FROM player AS MESSAGE
    WHERE username = pUserName;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_Active_games`()
BEGIN
SELECT `gameName` FROM gameSession AS MESSAGE
WHERE `gameActive`=1;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_all_games`()
BEGIN
	SELECT gameName from gamesession AS Message
    Order BY gameID DESC;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_all_players`()
BEGIN
	SELECT username FROM player AS Message;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_online_players`()
BEGIN
SELECT `userName` FROM player AS MESSAGE
WHERE `isOnline`=1;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_players_in_game`(pGamename VARCHAR(20))
BEGIN
	(SELECT `gameID` from gamesession WHERE `gameName`=pgameName)INTO @gameid;
    
	SELECT `userName` FROM player AS MESSAGE
    
WHERE `gameID`=@gameID;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `join_game`(puserName varchar(20), pGameName varchar(20))
BEGIN
SELECT gameID FROM gameSession WHERE gameName=pGameName into @gameID;
(SELECT id from player where username=pusername) into @playerId;
IF EXISTS(SELECT ID FROM player WHERE ID=@playerid) THEN
    BEGIN
    UPDATE player
	SET `gameID` = @gameID, `isOnline`=1
	WHERE `ID` = @playerID;
    END;
    SELECT concat((SELECT `username` FROM player WHERE ID=@playerID), " has joined ",(SELECT `gameName` FROM gamesession WHERE gameID=@gameId)) AS MESSAGE;
END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `leave_game`(pPlayerID int,pGameID int)
BEGIN
	UPDATE player
SET `isOnline` = false
WHERE `ID` = pPlayerID AND `gameID`=pGameID;

SELECT concat((SELECT `username` FROM player WHERE ID=pPlayerID), ' has left', (SELECT `gameName` FROM gamesession WHERE gameID=pgameID)) AS MESSAGE;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `login`(pUserName VARCHAR(20), pPassword VARCHAR(20))
BEGIN
DECLARE lcUserName varchar(20);
DECLARE lcPassword varchar(20);
DECLARE lcIsLocked bit;
DECLARE lcLoginAttempts integer;
SELECT `UserName`, `Password`, `loginAttempts`
FROM player
WHERE `UserName` = pUserName
INTO lcUserName, lcPassword, lcLoginAttempts;
IF (lcUserName IS NULL)  THEN
	BEGIN
		SELECT concat(pUserName, " Doesn't exist") AS MESSAGE;
	END;
	ELSEIF (lcLoginAttempts > 4) THEN
	BEGIN
		SELECT concat("Your account is locked. Please contact admin at ",`Email`) AS MESSAGE
        FROM player
        WHERE `isAdmin` = true
        LIMIT 1;		
	END;
    ELSEIF (lcPassword <> pPassword) THEN
    BEGIN
		UPDATE player
        SET `loginAttempts` = `loginAttempts` + 1
        WHERE `userName` = lcUserName;
        SELECT concat("Login Attempts Left: ", 5-`loginAttempts`) AS MESSAGE
        FROM player
        WHERE `userName` = lcUserName;
	END;
	ELSEIF ((lcUserName = pUserName) AND (lcPassword = pPassword) AND (lcLoginAttempts < 5)) THEN
    BEGIN
		UPDATE player
        SET `isOnline` = true, `loginAttempts` = 0
        WHERE`userName` = pUserName;
        SELECT ("Logged In") AS MESSAGE;
	END ;
    END IF;
    COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `logout`(pUserName varchar(20))
BEGIN
	START TRANSACTION;
        BEGIN
            UPDATE player
            SET `isOnline` = false
            WHERE `userName` = pUserName;
            SELECT concat("Logged out") AS MESSAGE;
        END;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `move_player`(pPlayerID int, pGameID int, pdiceValue int)
BEGIN
IF (SELECT `isOnline` FROM player WHERE `playerID`=pplayerID)=1 THEN
(SELECT `location` from player WHERE `playerID`=playerID AND `gameID`=pGameID) into @currentLocation;
	IF (100-@currentLocation)>pDiceValue THEN 
	UPDATE player
    SET `location`=@currentLocation+pdiceValue
    WHERE `ID`=pPlayerID AND `gameID`=pGameID;
    END If;
    (SELECT `location` from player WHERE `playerID`=playerID AND `gameID`=pGameID) into @currentLocation;
    call after_move(@currentLocation, @newlocation);
    UPDATE player
    SET `location`=@newLocation
    WHERE `ID`=pPlayerID AND `gameID`=pGameID;
END If;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `recent_chat`(pGameID int)
BEGIN
	SELECT `message` FROM message  AS MESSAGE
    WHERE `gameID`=pgameID
	ORDER BY `messageID` ASC
	LIMIT 10;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `register_player`(pUserName VARCHAR(20), pPassword VARCHAR(25))
BEGIN
START TRANSACTION;
  IF EXISTS (SELECT `userName` FROM player WHERE `userName` = pUserName) THEN
  BEGIN
     SELECT 'UserName is taken' AS MESSAGE;
  END;
	ELSE 
	 BEGIN
     INSERT INTO player(`UserName`,`Password`)
     VALUE (pUserName, pPassword);
     SELECT concat('registered ', pUserName) AS MESSAGE;
     END;
  END IF;
COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `send_message`(pMessage varchar(300), pUserID int, pGameID int)
BEGIN
	INSERT INTO message(`gameID`, `playerID`,`message`)
	VALUES(pGameID, pUserID,pMessage);
	SELECT concat('Message Sent') AS MESSAGE;
END$$
DELIMITER ;
