/*
*	Criação de tabelas
*	para o trabalho de AEnima
*/
SET XACT_ABORT ON
SET NOCOUNT ON
USE AEnima; --Se não existir a base de dados, deve criá-la
GO

IF OBJECT_ID('Aluguer') IS NOT NULL
	DROP TABLE Aluguer
IF OBJECT_ID('Cliente') IS NOT NULL
	DROP TABLE Cliente
IF OBJECT_ID('Empregado') IS NOT NULL
	DROP TABLE Empregado
IF OBJECT_ID('EquipamentoPromocao') IS NOT NULL
	DROP TABLE EquipamentoPromocao
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
	tipo VARCHAR(31) REFERENCES Tipo(nome) NOT NULL
)

CREATE TABLE Cliente
(
	cId INT IDENTITY(1,1) PRIMARY KEY,
	nif INT UNIQUE,
	nome VARCHAR(31),
	morada VARCHAR(100),
	
)
INSERT INTO Cliente(nif, nome, morada) VALUES(NULL, NULL, NULL);
ALTER TABLE Cliente
	ADD CONSTRAINT ck1_cliente CHECK(nif < 1000000000),
	ADD CONSTRAINT ck2_cliente CHECK(nif NOT NULL) 


CREATE TABLE Empregado(
	eId INT IDENTITY(1,1) PRIMARY KEY, 
	nome VARCHAR(31)
)

CREATE TABLE Preco(
	eqId INT REFERENCES Equipamento(eqId), 
	valor FLOAT,
	duracao TIME,
	validade DATE, 
	PRIMARY KEY(eqId, valor, duracao, validade),
	CONSTRAINT ck1_preco CHECK(valor >= 0),
	CONSTRAINT ck2_preco CHECK(duracao > '00:00:00') 
)

CREATE TABLE Promocao(
	pId INT IDENTITY(1,1) PRIMARY KEY,
	inicio DATE NOT NULL,
	fim DATE NOT NULL,
	descr VARCHAR(255),
	CONSTRAINT ck1_promocao CHECK(fim > inicio) 
)

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

CREATE TABLE EquipamentoPromocao(
	pId INT REFERENCES Promocao(pId),
	eqId INT REFERENCES Equipamento(eqId),
	PRIMARY KEY(pId, eqId)
)

CREATE TABLE Aluguer(
	serial VARCHAR(31) DEFAULT NEWID(), 
	eqId INT REFERENCES Equipamento(eqId) NOT NULL,
	empregado INT REFERENCES Empregado(eId) NOT NULL,
	cliente INT REFERENCES Cliente(cId) NOT NULL,
	preco_valor FLOAT NOT NULL, 
	preco_duracao TIME NOT NULL,
	preco_validade DATE NOT NULL, 
	data_inicio DATE NOT NULL, 
	PRIMARY KEY(serial),
	FOREIGN KEY(eqId, preco_valor, preco_duracao, preco_validade) REFERENCES Preco(eqId, valor, duracao, validade), 
	CONSTRAINT ck1_Aluguer CHECK(preco_validade > data_inicio) 
)