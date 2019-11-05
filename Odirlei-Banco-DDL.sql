create database odirlei_lanhouse_saep;

use odirlei_lanhouse_saep;

create table Usuarios(
	Id int identity primary key,
	Email varchar(255) not null unique,
	Senha varchar(255) not null
);

create table TiposDefeitos(
	Id int identity primary key,
	Nome varchar(255) not null unique
);

create table TiposEquipamentos(
	Id int identity primary key,
	Nome varchar(255) not null unique
);

create table RegistroDefeitos(
	Id int identity primary key,
	DataChamado datetime not null,
	IdTipoEquipamento int foreign key references TiposEquipamentos(Id),
	IdTipoDefeito int foreign key references TiposDefeitos(Id),
	Descricao text
);