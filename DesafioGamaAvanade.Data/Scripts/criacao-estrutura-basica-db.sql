DROP database [DesafioAvanadeGama];

create database DesafioAvanadeGama;

use DesafioAvanadeGama;

create table Artista(
	ArtistaId uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
	Cache decimal(38,2) NOT NULL,
	Idade int NOT NULL
);

CREATE TABLE Genero(
	GeneroId uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
);

CREATE TABLE Produtor(
	ProdutorId uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
);

CREATE TABLE ArtistaGenero(
	ArtistaId uniqueidentifier Not null,
	GeneroId uniqueidentifier Not null,
	CONSTRAINT PK_Artista_Genero PRIMARY KEY NONCLUSTERED (ArtistaId,GeneroId),
	CONSTRAINT FK_ArtistaId FOREIGN KEY (ArtistaId)
	REFERENCES Artista(ArtistaId),
	CONSTRAINT FK_GeneroId FOREIGN KEY (GeneroId)
	REFERENCES Genero(GeneroId),
);

create table Reserva(
	ReservaId uniqueidentifier Not null PRIMARY KEY,
	ProdutorId uniqueidentifier Not null,
	ArtistaId uniqueidentifier Not null,
	DataInicio datetime	Not null,
	DataFim datetime	Not null,
	CacheTotal decimal(5,2) NOT NULL,
	constraint FK_Produtor FOREIGN KEY (ProdutorId) references Produtor(ProdutorId),
	constraint FK_Artista FOREIGN KEY (ArtistaId) references Artista(ArtistaId),
);

CREATE TABLE Profile (
    Id uniqueidentifier  Not null PRIMARY KEY,
    Description varchar(255) Not null
);

INSERT INTO profile (Id, Description)
VALUES (NewID(), 'ARTISTA');

INSERT INTO profile (Id, Description)
VALUES (NewID(), 'PRODUTOR');

SELECT * FROM PROFILE;

CREATE TABLE Users (
    Id uniqueidentifier  Not null,
    Login varchar(255) Not null PRIMARY KEY,
    Password varchar(255) Not null,
    ProfileId uniqueidentifier Not null,
    Created date,
	constraint FK_Profile FOREIGN KEY (ProfileId) references Profile(id)
);