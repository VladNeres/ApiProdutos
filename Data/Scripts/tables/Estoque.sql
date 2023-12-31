﻿IF NOT EXISTS(SELECT TOP 1 1 FROM Sys.Tables WHERE Name = 'Estoque')
BEGIN
	CREATE TABLE Estoque(
	Produto_ID INT  PRIMARY KEY,
	Codigo_Produto VARCHAR(40) NOT NULL,
	ProdutoNome	VARCHAR(50) NOT NULL,
	Quantidade INT NOT NULL,
	DataEntrada DATETIME,
	DataSaida DATETIME)

	ALTER TABLE Estoque ADD CONSTRAINT  FK_ESTOQUE_PRODUTO FOREIGN KEY(Codigo_Produto) References PRODUTOS (CodigoDoProduto)
	
END