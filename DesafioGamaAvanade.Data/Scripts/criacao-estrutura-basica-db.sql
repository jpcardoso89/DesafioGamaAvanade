create database DesafioAvanadeGama;

use DesafioAvanadeGama

create table Artista(
	Id uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
	Cache decimal(5,2) NOT NULL,
	Idade int NOT NULL
);

Alter table Artista alter column Cache decimal(38,2) not null;

CREATE TABLE Genero(
	Id uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
);

CREATE TABLE Produtor(
	Id uniqueidentifier Not null PRIMARY KEY,
	Nome varchar(255) NOT NULL,
);

CREATE TABLE ArtistaGenero(
	ArtistaId uniqueidentifier Not null,
	GeneroId uniqueidentifier Not null,
	CONSTRAINT PK_Artista_Genero PRIMARY KEY NONCLUSTERED (ArtistaId,GeneroId),
	CONSTRAINT FK_ArtistaId FOREIGN KEY (ArtistaId)
	REFERENCES Artista(Id),
	CONSTRAINT FK_GeneroId FOREIGN KEY (GeneroId)
	REFERENCES Genero(Id),
);

create table Reserva(
	Id uniqueidentifier Not null PRIMARY KEY,
	ProdutorId uniqueidentifier Not null,
	ArtistaId uniqueidentifier Not null,
	DataInicio datetime	Not null,
	DataFim datetime	Not null,
	CacheTotal decimal(5,2) NOT NULL,
	constraint FK_Produtor FOREIGN KEY (ProdutorId) references Produtor(Id),
	constraint FK_Artista FOREIGN KEY (ArtistaId) references Artista(Id),
);
