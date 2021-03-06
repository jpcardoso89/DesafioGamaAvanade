DROP database [DesafioAvanadeGama];

create database DesafioAvanadeGama;

use DesafioAvanadeGama;

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

create table Artista(
	ArtistaId uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
	Cache decimal(38,2) NOT NULL,
	Idade int NOT NULL,
	UserLogin varchar(255) Not null,
	constraint FK_User_Art FOREIGN KEY (UserLogin) references Users(Login)
);

CREATE TABLE Genero(
	GeneroId uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
);

INSERT INTO Genero (GeneroId, Nome)
VALUES (NewID(), 'Terror');

INSERT INTO Genero (GeneroId, Nome)
VALUES (NewID(), 'Drama');

INSERT INTO Genero (GeneroId, Nome)
VALUES (NewID(), 'Com�dia');

INSERT INTO Genero (GeneroId, Nome)
VALUES (NewID(), 'Aventura');

INSERT INTO Genero (GeneroId, Nome)
VALUES (NewID(), 'Cult');

INSERT INTO Genero (GeneroId, Nome)
VALUES (NewID(), 'Espionagem');

INSERT INTO Genero (GeneroId, Nome)
VALUES (NewID(), 'Fic��o cient�fica');

CREATE TABLE Produtor(
	ProdutorId uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
	UserLogin varchar(255) Not null,
	constraint FK_User_Prod FOREIGN KEY (UserLogin) references Users(Login)
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
	CacheTotal decimal(38,2) NOT NULL,
	constraint FK_Produtor FOREIGN KEY (ProdutorId) references Produtor(ProdutorId),
	constraint FK_Artista FOREIGN KEY (ArtistaId) references Artista(ArtistaId),
);

create table Producao(
	ProducaoId uniqueidentifier Not null PRIMARY KEY,
	ProdutorId uniqueidentifier Not null,
	Titulo varchar(255) NOT NULL,
	DataInicialDasGravacoes datetime Not null,
	Orcamento decimal(38,2) NOT NULL,
	constraint FK_Producao_Produtor FOREIGN KEY (ProdutorId) references Produtor(ProdutorId)
);