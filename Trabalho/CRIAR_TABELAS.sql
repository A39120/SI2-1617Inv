/*
*	Criação de tabelas
*	para o trabalho de AEnima
*/
SET XACT_ABORT ON
SET NOCOUNT ON
IF DB_ID('AEnima') IS NULL
	CREATE DATABASE AEnima
GO
USE AEnima;
GO

IF OBJECT_ID('AluguerPrecoDuracao') IS NOT NULL
	DROP TABLE AluguerPrecoDuracao
IF OBJECT_ID('AluguerDataFim') IS NOT NULL
	DROP TABLE AluguerDataFim
IF OBJECT_ID('Aluguer') IS NOT NULL
	DROP TABLE Aluguer
IF OBJECT_ID('Cliente') IS NOT NULL
	DROP TABLE Cliente
IF OBJECT_ID('Empregado') IS NOT NULL
	DROP TABLE Empregado
IF OBJECT_ID('TipoPromocao') IS NOT NULL
	DROP TABLE TipoPromocao
IF OBJECT_ID('PromocaoTemporal') IS NOT NULL
	DROP TABLE PromocaoTemporal
IF OBJECT_ID('PromocaoDesconto') IS NOT NULL
	DROP TABLE PromocaoDesconto
IF OBJECT_ID('Promocao') IS NOT NULL
	DROP TABLE Promocao
IF OBJECT_ID('Preco') IS NOT NULL
	DROP TABLE Preco
IF OBJECT_ID('Equipamento') IS NOT NULL
	DROP TABLE Equipamento
IF OBJECT_ID('Tipo') IS NOT NULL
	DROP TABLE Tipo
GO

CREATE TABLE Tipo(
	nome VARCHAR(31) PRIMARY KEY, 
	descr VARCHAR(255)
)

CREATE TABLE Equipamento(
	eqId INT IDENTITY(1,1) PRIMARY KEY, 
	descr VARCHAR(255),
	tipo VARCHAR(31) REFERENCES Tipo(nome) NOT NULL,
	valid BIT DEFAULT 1
)
-- Reset identity
DBCC CHECKIDENT ('Equipamento', RESEED, 1);

CREATE TABLE Cliente(
	cId INT IDENTITY(1,1) PRIMARY KEY,
	nif INT UNIQUE,
	nome VARCHAR(31),
	morada VARCHAR(100),
	valido BIT DEFAULT 1
)
-- Reset identity
DBCC CHECKIDENT ('Cliente', RESEED, 1);

INSERT INTO Cliente(nif, nome, morada) VALUES(NULL, NULL, NULL);

CREATE TABLE Empregado(
	eId INT IDENTITY(1,1) PRIMARY KEY, 
	nome VARCHAR(31)
)
-- Reset identity
DBCC CHECKIDENT ('Empregado', RESEED, 1);

CREATE TABLE Preco(
	tipo VARCHAR(31) REFERENCES Tipo(nome), 
	valor FLOAT,
	duracao TIME,
	validade DATE, 
	PRIMARY KEY(tipo, valor, duracao, validade),
	CONSTRAINT ck1_preco CHECK(valor >= 0),
	CONSTRAINT ck2_preco CHECK(duracao > '00:00:00') 
)

CREATE TABLE Promocao(
	pId INT IDENTITY(1,1) PRIMARY KEY,
	inicio DATETIME NOT NULL,
	fim DATETIME NOT NULL,
	descr VARCHAR(255),
	CONSTRAINT ck1_promocao CHECK(fim > inicio) 
)
-- Reset identity
DBCC CHECKIDENT ('Promocao', RESEED, 1);

CREATE TABLE PromocaoTemporal(
	pId INT REFERENCES Promocao(pId) PRIMARY KEY,
	tempoExtra TIME NOT NULL,
	CONSTRAINT ck1_promocaoTemporal CHECK(tempoExtra > '00:00:00')
)

CREATE TABLE PromocaoDesconto(
	pId INT REFERENCES Promocao(pId) PRIMARY KEY,
	percentagemDesconto FLOAT NOT NULL,
	CONSTRAINT ck1_PromocaoDesconto CHECK(percentagemDesconto > 0 AND percentagemDesconto <= 1) 
)

CREATE TABLE TipoPromocao(
	tipo VARCHAR(31) REFERENCES Tipo(nome) NOT NULL,
	pId INT REFERENCES Promocao(pId) NOT NULL,
	PRIMARY KEY(tipo, pId)
)

CREATE TABLE Aluguer(
	serial VARCHAR(36) DEFAULT NEWID(), 
	eqId INT REFERENCES Equipamento(eqId) NOT NULL,
	empregado INT REFERENCES Empregado(eId) NOT NULL,
	cliente INT REFERENCES Cliente(cId) NOT NULL,
	data_inicio DATETIME NOT NULL, 
	deleted BIT DEFAULT 0,
	PRIMARY KEY(serial),
	FOREIGN KEY(eqId) REFERENCES Equipamento(eqId), 
)

CREATE TABLE AluguerPrecoDuracao(
	serial_apd VARCHAR(36) PRIMARY KEY,
	duracao DATETIME NOT NULL,
	preco INT NOT NULL,
	FOREIGN KEY(serial_apd) REFERENCES Aluguer(serial)
)

CREATE TABLE AluguerDataFim(
	serial_adf VARCHAR(36) PRIMARY KEY,
	data_fim DATETIME NOT NULL
	FOREIGN KEY(serial_adf) REFERENCES Aluguer(serial)
)
