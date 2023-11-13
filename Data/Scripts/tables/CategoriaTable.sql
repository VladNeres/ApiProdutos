 IF Not Exists (Select Top 1 1 From sys.tables WHERE name = 'Categorias')
BEGIN
    CREATE TABLE Categorias(
                 ID INT PRIMARY KEY IDENTITY(1,1),
                 Nome VARCHAR(50) NOT NULL,
                 DataCriacao DATETIME NOT NULL, 
                 DataAlteracao DATETIME NULL
		            );
END