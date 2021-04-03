drop database if exists DAT601_AbhimanuSaharan;
create database DAT601_AbhimanuSaharan;
use DAT601_AbhimanuSaharan;

drop procedure if exists ddl;
delimiter //
create procedure ddl()
begin

CREATE TABLE `Player` (
  `userid` int NOT NULL,
  `Password` varchar(30) NOT NULL,
  `HighScore` int,
  `IsOnline` boolean NOT NULL,
  `Admin` boolean,
  PRIMARY KEY (`userid`)
);

CREATE TABLE `GameSession` (
  `SessionID` int,
  `Player1` int,
  `Player2` int,
  PRIMARY KEY (`SessionID`),
  FOREIGN KEY (Player1) REFERENCES Player(userid),
  FOREIGN KEY (Player2) REFERENCES Player(userid)
);

CREATE TABLE `Field` (
  `FieldID` int,
  `BoardID` int,
  PRIMARY KEY (`FieldID`)
);

CREATE TABLE `GameBoard` (
  `BoardID` int,
  `SessionID` int,
  `Player1Location` int,
  `Player2Location` int,
  PRIMARY KEY (`BoardID`),
  FOREIGN KEY (SessionID) REFERENCES GameSession(SessionId),
  FOREIGN KEY (Player1Location) REFERENCES Field(FieldID),
  FOREIGN KEY (Player2Location) REFERENCES Field(FieldID)
);

alter table Field add foreign key (BoardID) references GameBoard(BoardID);

CREATE TABLE `Objects` (
  `SnakeORLadder` boolean,
  `StartingField` int,
  `EndingField` int,
  FOREIGN KEY (StartingField) REFERENCES Field(FieldID),
  FOREIGN KEY (EndingField) REFERENCES Field(FieldID)
);
END //
delimiter ;
-- DDL Ends
-- DML Starts

drop procedure if exists dml;
delimiter //
create procedure dml()
begin

-- insert starts

INSERT INTO Player(userId,Password, HighScore, IsOnline, Admin)
VALUES(1,'jhsjhd',0, true, false),
		(2,'jhsjhd',0, true, true),
        (3,'jhsjhd',0, false, false);

INSERT INTO GameSession(SessionID,Player1,Player2)
VALUES(1,1,2),
(2,3,null);

INSERT INTO Field(FieldID)
VALUES(1);

INSERT INTO GameBoard(BoardID,SessionID,Player1Location,Player2Location)
VALUES(1,1,1,1);

INSERT INTO Objects(SnakeorLadder)
VALUES(false);

-- insert ends
-- update start

UPDATE Player
SET PASSWORD="JKHF" WHERE userId=1;

UPDATE GameSession
SET Player1=null WHERE Player1=1;

UPDATE GameBoard
SET Player1Location=null
WHERE SessionID=1;

update objects
set SnakeorLadder=true where SnakeOrLadder=false;

-- update ends
-- delete start

Delete from GameSession
where player1=null or player2=null;

-- delete ends
-- select starts

SELECT userid, highscore from Player AS ScoreBoard;
Select * from GameSession;
Select userid,password FROM Player AS OnlinePlayers where IsOnline=true;

-- select ends

END //
delimiter ;

call ddl();
call dml();