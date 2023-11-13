IF EXISTS(SELECT * FROM SYS.Tables WHERE NAME = 'Produtos')
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY

	INSERT INTO Produtos(CodigoDoProduto,Nome,Valor,DataCriacao,DataAlteracao,Status,CategoriaID)
	VALUES (NEWID(), 'iPhone 13 Pro Max', 7999.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'iPhone 13', 5499.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'iPhone SE (2� gera��o)', 2999.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'iPhone 12 Mini', 4999.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'iPhone 11', 4499.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Moto G Power (2022)', 1499.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Moto G Stylus (2022)', 1799.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Moto G Pure', 1199.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Moto G6 Plus', 1399.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Moto Edge 20', 2199.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Samsung Galaxy S21', 3299.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Samsung Galaxy A52', 1799.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Samsung Galaxy S20 FE', 2999.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Samsung Galaxy Z Fold 3', 9999.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Samsung Galaxy Note 20', 4999.00, GETDATE(),NULL, 1, 1),
		   (NEWID(), 'Google Pixel 4 XL', 3999.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'OnePlus 8T', 2499.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'OnePlus 7 Pro', 2299.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'Apple Watch Series 7', 399.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Samsung Galaxy Watch 4', 249.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Fitbit Versa 4', 199.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Garmin Fenix 7', 299.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Fossil Gen 6', 179.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Dell XPS 13', 2499.00,GETDATE(), NULL, 1, 2),
		   (NEWID(), 'HP Spectre x360', 1799.00,GETDATE(), NULL, 1, 2),
		   (NEWID(), 'MacBook Air', 9999.00,GETDATE(), NULL, 1, 2),
		   (NEWID(), 'Asus ROG Zephyrus', 2499.00,GETDATE(), NULL, 1, 2),
		   (NEWID(), 'Lenovo ThinkPad X1 Carbon', 1999.00,GETDATE(), NULL, 1, 2),
		   (NEWID(), 'iPad Pro', 799.00, GETDATE(),NULL, 1, 3),
		   (NEWID(), 'Samsung Galaxy Tab S7', 599.00, GETDATE(),NULL, 1, 3),
		   (NEWID(), 'Amazon Fire HD', 149.00,GETDATE(), NULL, 1, 3),
		   (NEWID(), 'Lenovo Tab M10', 199.00,GETDATE(), NULL, 1, 3),
		   (NEWID(), 'Microsoft Surface Pro', 699.00,GETDATE(), NULL, 1, 3),
		   (NEWID(), 'Apple Watch Series 7', 399.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Samsung Galaxy Watch 4', 249.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Fitbit Versa 4', 199.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Garmin Fenix 7', 299.00,GETDATE(), NULL, 1, 4),
		   (NEWID(), 'Fossil Gen 6', 179.00,GETDATE(), NULL, 1, 4);

					   -- Roupas e Acess�rios
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Vestido de Festa', 199.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Camiseta Estampada', 29.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Cal�a Jeans', 59.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'T�nis Esportivo', 79.00,GETDATE(), NULL, 1, 2),
			(NEWID(), '�culos de Sol', 49.00, GETDATE(),NULL, 1, 2),
			(NEWID(), 'Bolsa de Couro', 99.00, GETDATE(),NULL, 1, 2),
			(NEWID(), 'Rel�gio de Pulso', 69.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Bon� de Baseball', 19.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Sapato Social', 89.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Pulseira de Prata', 39.00, GETDATE(),NULL, 1, 2),
			(NEWID(), 'Len�o de Seda', 29.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Jaqueta de Couro', 119.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Meias Coloridas', 9.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Mala de Viagem', 79.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Cinto de Couro', 29.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Luvas de Inverno', 19.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Camisa Polo', 39.00, GETDATE(), NULL, 1, 2),
			(NEWID(), 'Blusa de Moletom', 49.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Anel de Ouro', 99.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Gravata Elegante', 19.00,GETDATE(), NULL, 1, 2);
			
			
			-- M�veis e Decora��o
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Sof� de Couro', 799.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Mesa de Jantar', 499.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Cama King-Size', 699.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Estante de Livros', 299.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Poltrona Reclin�vel', 249.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Tapete de L�', 129.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Lumin�ria de Ch�o', 79.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Mesa de Centro', 119.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Arm�rio de Cozinha', 349.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Cortinas Decorativas', 39.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Cadeira de Escrit�rio', 99.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Quadro Abstrato', 59.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Rel�gio de Parede', 29.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Prateleira de Madeira', 49.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Mesa de Cabeceira', 69.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Comoda Espelhada', 169.00, GETDATE(), NULL, 1, 4),
			(NEWID(), 'Cama de Solteiro', 299.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Lumin�ria de Teto', 59.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Mesa de Escrit�rio', 199.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Guarda-Roupas', 399.00,GETDATE(), NULL, 1, 4);

						-- Esportes e Lazer
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Bicicleta de Montanha', 399.00, GETDATE(),NULL, 1, 7),
			(NEWID(), 'T�nis de Corrida', 79.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Raquete de T�nis', 29.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Bola de Futebol', 19.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Prancha de Surfe', 199.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Frisbee', 9.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Rede de V�lei', 49.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Skate Completo', 59.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Equipamento de Acampamento', 129.00, GETDATE(),NULL, 1, 7),
			(NEWID(), 'Bin�culos', 39.00, GETDATE(),NULL, 1, 7),
			(NEWID(), 'Canoa Infl�vel', 299.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Patinete El�trico', 199.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Taco de Beisebol', 19.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Tenda de Camping', 69.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Fita de Ioga', 9.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Luvas de Boxe', 29.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Patins Inline', 49.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Bola de Basquete', 15.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Kit de Pesca', 79.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Piscina Infl�vel', 39.00,GETDATE(), NULL, 1, 7);
			
			-- Livros e Materiais de Leitura
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Romance Best-Seller', 12.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Mist�rio', 9.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Fic��o Cient�fica', 11.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Autoajuda', 8.00, GETDATE(), NULL, 1, 8),
			(NEWID(), 'Dicion�rio de Ingl�s', 15.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Hist�ria', 10.00, GETDATE(),NULL, 1, 8),
			(NEWID(), 'Cole��o de Poesia', 14.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Revista de Moda', 5.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Ci�ncias', 13.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Receitas', 7.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Quadrinhos Cl�ssicos', 9.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Enciclop�dia Universal', 19.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Biografia', 8.00, GETDATE(),NULL, 1, 8),
			(NEWID(), 'Guia de Viagens', 12.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Cole��o de Contos', 11.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Arte', 15.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Pol�tica', 9.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Economia', 13.00, GETDATE(),NULL, 1, 8),
			(NEWID(), 'Livro de Psicologia', 10.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Matem�tica', 11.00,GETDATE(), NULL, 1, 8);
			
			-- Brinquedos e Jogos
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Quebra-Cabe�a 1000 Pe�as', 9.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Boneca de Porcelana', 29.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Carrinho de Controle Remoto', 19.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Bicicleta Infantil', 59.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Jogo de Xadrez', 12.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Artesanato', 15.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Bola de Praia', 5.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Boneco de A��o', 9.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Ci�ncia para Crian�as', 10.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Patinete Infantil', 29.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Jogo de Domin�', 8.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Quebra-Cabe�a 500 Pe�as', 6.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Constru��o', 19.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Puzzle 3D', 15.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Trem de Brinquedo', 39.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Pintura', 7.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Jogo de Mem�ria', 9.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Maquiagem Infantil', 5.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Bola de Futebol de Sal�o', 8.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Quebra-Cabe�a 250 Pe�as', 6.00,GETDATE(), NULL, 1, 10);
	END TRY	
	
	BEGIN CATCH
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
	THROW;
	
	END CATCH;
	
	IF @@TRANCOUNT > 0
	COMMIT TRANSACTION;
END 