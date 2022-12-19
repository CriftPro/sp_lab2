DROP TABLE IF EXISTS character.characters;
DROP TABLE IF EXISTS character.players;
DROP SCHEMA IF EXISTS character;

CREATE SCHEMA character;



CREATE TABLE character.characters (
	id UUID NOT NULL,
    created_date TIMESTAMP NOT NULL,
	modified_date TIMESTAMP NULL,
    name VARCHAR(256) NOT NULL,
    class VARCHAR(30) NOT NULL,
		 
	lvl INT NOT NULL DEFAULT 1,
	stat_hp INT NOT NULL DEFAULT 10,
	stat_strength INT NOT NULL DEFAULT 10,
	stat_agility INT NOT NULL DEFAULT 10,
	stat_intelligence INT NOT NULL DEFAULT 10,
	stat_charisma INT NOT NULL DEFAULT 10,
		CONSTRAINT pk_character_character_id PRIMARY KEY (id));
        
		
insert into character.characters (id,created_date, modified_date, name, class)
select 'e0d58993-2e23-411e-9db5-358d9bf2d4d5',NOW(),null,'LordChampion','Warrior';



CREATE TABLE character.players (
	id UUID NOT NULL,
	created_date TIMESTAMP NOT NULL,
	modified_date TIMESTAMP NULL,
    nickname VARCHAR(300) NOT NULL,
	password VARCHAR(300) NOT NULL,
	email VARCHAR(300) NOT NULL,
	playable_character VARCHAR(100) NULL,
		CONSTRAINT pk_character_player_id PRIMARY KEY (id));
	
		
		

insert into character.players (id,created_date, modified_date,nickname,password, email,playable_character)
select 'e0d58993-5555-411e-9db5-358d9bf2d4d5', NOW(),NULL,'PlayerOne', '12345', 'player1@mail.com','';

select * 
from character.players;

select * 
from character.characters;