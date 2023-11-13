IF NOT Exists (Select Top 1 1 From sys.tables WHERE name = 'Produtos')
BEGIN
	Create table Produtos(   
	ID INT IDENTITY (1,1) UNIQUE ,
	CodigoDoProduto VARCHAR(40)PRIMARY KEY,
	Nome VARCHAR(50) NOT NULL,
	Valor DECIMAL(15,2),
	DataCriacao DATETIME NOT NULL,
	DataAlteracao DATETIME NULL,
	Status BIT,
	CategoriaId INT NOT NULL  
	);

	ALTER TABLE Produtos ADD CONSTRAINT FK_Produtos_Categoria FOREIGN KEY(CategoriaID) References Categorias (id)
END

