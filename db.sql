CREATE TABLE rapidity (
  idrapidity INT NOT NULL,
  RapidityName VARCHAR(50) NULL,
  PRIMARY KEY (idrapidity));
CREATE TABLE trust (
  idtrust INT NOT NULL,
  trustName VARCHAR(50) NULL,
  PRIMARY KEY (idtrust));
CREATE TABLE player (
  idplayer INT NOT NULL IDENTITY(1,1),
  nickname VARCHAR(50) NULL,
  idrapidity INT NOT NULL,
  idtrust INT NOT NULL,
  PRIMARY KEY (idplayer),
  FOREIGN KEY (idrapidity) REFERENCES rapidity(idrapidity),
  FOREIGN KEY(idtrust) REFERENCES trust(idtrust));
CREATE TABLE status (
  idstatus INT NOT NULL,
  statusName VARCHAR(50) NULL,
  PRIMARY KEY (idstatus));
CREATE TABLE route (
  idroute INT NOT NULL IDENTITY(1,1),
  distance FLOAT NULL,
  time FLOAT NULL,
  wazelink VARCHAR(300) NULL,
  mapslink VARCHAR(300) NULL,
  idplayer INT NOT NULL,
  idstatus INT NOT NULL,
  PRIMARY KEY (idroute),
  FOREIGN KEY(idplayer) REFERENCES player(idplayer),
  FOREIGN KEY(idstatus) REFERENCES status(idstatus));
