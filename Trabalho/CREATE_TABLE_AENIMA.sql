/*
*	Criação de tabelas
*	para o trabalho de AEnima
*/
SET XACT_ABORT ON
SET NOCOUNT ON
USE AEnima; --Se não existir a base de dados, deve criá-la
GO

IF OBJECT_ID('PromocaoTemporal') IS NOT NULL
	DROP TABLE PromocaoTemporal
IF OBJECT_ID('PromocaoDesconto') IS NOT NULL
	DROP TABLE PromocaoDesconto
IF OBJECT_ID('Promocao') IS NOT NULL
	DROP TABLE Promocao
IF OBJECT_ID('Aluguer') IS NOT NULL
	DROP TABLE Aluguer
IF OBJECT_ID('Preco') IS NOT NULL
	DROP TABLE Preco
IF OBJECT_ID('Equipamento') IS NOT NULL
	DROP TABLE Equipamento
IF OBJECT_ID('Tipo') IS NOT NULL
	DROP TABLE Tipo
IF OBJECT_ID('Cliente') IS NOT NULL
	DROP TABLE Cliente
IF OBJECT_ID('Empregado') IS NOT NULL
	DROP TABLE Empregado

GO
CREATE TABLE Tipo(
	nome VARCHAR(31) PRIMARY KEY, 
	descr VARCHAR(255)
)

CREATE TABLE Equipamento(
	id VARCHAR(31) PRIMARY KEY, 
	descr VARCHAR(255),
	tipo VARCHAR(31) REFERENCES Tipo(nome) NOT NULL
)

CREATE TABLE Cliente
(
	id INT IDENTITY(1, 1) PRIMARY KEY,
	nif INT,
	nome VARCHAR(31) DEFAULT 'Cliente Final',
	morada VARCHAR(100) DEFAULT NULL
)

CREATE TABLE Empregado(
	id INT IDENTITY(1,1) PRIMARY KEY, 
	nome VARCHAR(31)
)

CREATE TABLE Preco(
	id_equipamento VARCHAR(31) REFERENCES Equipamento(id), 
	valor FLOAT,
	duracao TIME,
	validade DATE, 
	PRIMARY KEY(id_equipamento, valor, duracao)
)

CREATE TABLE Promocao(
	id VARCHAR(31) PRIMARY KEY,
	inicio DATE,
	fim DATE,
	descr VARCHAR(255) 
)

CREATE TABLE PromocaoTemporal(
	id VARCHAR(31) REFERENCES Promocao(id) PRIMARY KEY,
	tempoExtra TIME 
)

CREATE TABLE PromocaoDesconto(
	id VARCHAR(31) REFERENCES Promocao(id) PRIMARY KEY,
	percentagemDesconto INT
	CONSTRAINT ck1_PromocaoDesconto CHECK(percentagemDesconto > 0 AND percentagemDesconto < 100) 
)

CREATE TABLE Aluguer(
	e_id VARCHAR(31) REFERENCES Equipamento(id),
	serial INT IDENTITY(1,1) NOT NULL, 
	empregado INT REFERENCES Empregado(id),
	cliente INT REFERENCES Cliente(id),
	preco FLOAT, 
	duracao TIME, 
	inicio DATE, 
	PRIMARY KEY(e_id, serial),
	FOREIGN KEY(e_id, preco, duracao) REFERENCES Preco(id_equipamento, valor, duracao) 
)