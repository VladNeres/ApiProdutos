IF EXISTS( SELECT * FROM SYS.TABLES WHERE NAME = 'Categorias')
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY

	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Eletr�nicos',GETDATE(),NULL)

	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Roupas e Acess�rios',GETDATE(),NULL)
	
	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Alimentos e Bebidas',GETDATE(),NULL)
	
	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('M�veis e Decora��o',GETDATE(),NULL)
	
	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Sa�de e Beleza',GETDATE(),NULL)
	
	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Autom�veis e Acess�rios',GETDATE(),NULL)
	
	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Esportes e Lazer',GETDATE(),NULL)

	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Livros e Materiais de Leitura',GETDATE(),NULL)

	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Ferramentas e Equipamentos',GETDATE(),NULL)

	INSERT INTO Categorias(Nome, DataCriacao,DataAlteracao)
	VALUES ('Brinquedos e Jogos',GETDATE(),NULL)
 END TRY
	
	BEGIN CATCH
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
	THROW;
	END CATCH

	IF @@TRANCOUNT > 0
	COMMIT TRANSACTION
END
