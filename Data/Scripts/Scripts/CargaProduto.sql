IF EXISTS(SELECT * FROM SYS.Tables WHERE NAME = 'Produtos')
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY

	INSERT INTO Produtos(CodigoDoProduto,Nome,Valor,DataCriacao,DataAlteracao,Status,CategoriaID)
	VALUES (NEWID(), 'iPhone 13 Pro Max', 7999.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'iPhone 13', 5499.00,GETDATE(), NULL, 1, 1),
		   (NEWID(), 'iPhone SE (2ª geração)', 2999.00,GETDATE(), NULL, 1, 1),
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

					   -- Roupas e Acessórios
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Vestido de Festa', 199.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Camiseta Estampada', 29.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Calça Jeans', 59.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Tênis Esportivo', 79.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Óculos de Sol', 49.00, GETDATE(),NULL, 1, 2),
			(NEWID(), 'Bolsa de Couro', 99.00, GETDATE(),NULL, 1, 2),
			(NEWID(), 'Relógio de Pulso', 69.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Boné de Baseball', 19.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Sapato Social', 89.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Pulseira de Prata', 39.00, GETDATE(),NULL, 1, 2),
			(NEWID(), 'Lenço de Seda', 29.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Jaqueta de Couro', 119.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Meias Coloridas', 9.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Mala de Viagem', 79.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Cinto de Couro', 29.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Luvas de Inverno', 19.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Camisa Polo', 39.00, GETDATE(), NULL, 1, 2),
			(NEWID(), 'Blusa de Moletom', 49.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Anel de Ouro', 99.00,GETDATE(), NULL, 1, 2),
			(NEWID(), 'Gravata Elegante', 19.00,GETDATE(), NULL, 1, 2);
			
			
			-- Móveis e Decoração
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Sofá de Couro', 799.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Mesa de Jantar', 499.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Cama King-Size', 699.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Estante de Livros', 299.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Poltrona Reclinável', 249.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Tapete de Lã', 129.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Luminária de Chão', 79.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Mesa de Centro', 119.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Armário de Cozinha', 349.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Cortinas Decorativas', 39.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Cadeira de Escritório', 99.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Quadro Abstrato', 59.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Relógio de Parede', 29.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Prateleira de Madeira', 49.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Mesa de Cabeceira', 69.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Comoda Espelhada', 169.00, GETDATE(), NULL, 1, 4),
			(NEWID(), 'Cama de Solteiro', 299.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Luminária de Teto', 59.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Mesa de Escritório', 199.00,GETDATE(), NULL, 1, 4),
			(NEWID(), 'Guarda-Roupas', 399.00,GETDATE(), NULL, 1, 4);

						-- Esportes e Lazer
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Bicicleta de Montanha', 399.00, GETDATE(),NULL, 1, 7),
			(NEWID(), 'Tênis de Corrida', 79.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Raquete de Tênis', 29.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Bola de Futebol', 19.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Prancha de Surfe', 199.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Frisbee', 9.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Rede de Vôlei', 49.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Skate Completo', 59.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Equipamento de Acampamento', 129.00, GETDATE(),NULL, 1, 7),
			(NEWID(), 'Binóculos', 39.00, GETDATE(),NULL, 1, 7),
			(NEWID(), 'Canoa Inflável', 299.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Patinete Elétrico', 199.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Taco de Beisebol', 19.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Tenda de Camping', 69.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Fita de Ioga', 9.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Luvas de Boxe', 29.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Patins Inline', 49.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Bola de Basquete', 15.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Kit de Pesca', 79.00,GETDATE(), NULL, 1, 7),
			(NEWID(), 'Piscina Inflável', 39.00,GETDATE(), NULL, 1, 7);
			
			-- Livros e Materiais de Leitura
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Romance Best-Seller', 12.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Mistério', 9.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Ficção Científica', 11.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Autoajuda', 8.00, GETDATE(), NULL, 1, 8),
			(NEWID(), 'Dicionário de Inglês', 15.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de História', 10.00, GETDATE(),NULL, 1, 8),
			(NEWID(), 'Coleção de Poesia', 14.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Revista de Moda', 5.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Ciências', 13.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Receitas', 7.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Quadrinhos Clássicos', 9.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Enciclopédia Universal', 19.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Biografia', 8.00, GETDATE(),NULL, 1, 8),
			(NEWID(), 'Guia de Viagens', 12.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Coleção de Contos', 11.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Arte', 15.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Política', 9.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Economia', 13.00, GETDATE(),NULL, 1, 8),
			(NEWID(), 'Livro de Psicologia', 10.00,GETDATE(), NULL, 1, 8),
			(NEWID(), 'Livro de Matemática', 11.00,GETDATE(), NULL, 1, 8);
			
			-- Brinquedos e Jogos
			INSERT INTO Produtos (CodigoDoProduto, Nome, Valor, DataCriacao, DataAlteracao, Status, CategoriaID)
			VALUES
			(NEWID(), 'Quebra-Cabeça 1000 Peças', 9.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Boneca de Porcelana', 29.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Carrinho de Controle Remoto', 19.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Bicicleta Infantil', 59.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Jogo de Xadrez', 12.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Artesanato', 15.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Bola de Praia', 5.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Boneco de Ação', 9.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Ciência para Crianças', 10.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Patinete Infantil', 29.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Jogo de Dominó', 8.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Quebra-Cabeça 500 Peças', 6.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Construção', 19.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Puzzle 3D', 15.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Trem de Brinquedo', 39.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Pintura', 7.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Jogo de Memória', 9.00, GETDATE(), NULL, 1, 10),
			(NEWID(), 'Kit de Maquiagem Infantil', 5.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Bola de Futebol de Salão', 8.00,GETDATE(), NULL, 1, 10),
			(NEWID(), 'Quebra-Cabeça 250 Peças', 6.00,GETDATE(), NULL, 1, 10);
	END TRY	
	
	BEGIN CATCH
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
	THROW;
	
	END CATCH;
	
	IF @@TRANCOUNT > 0
	COMMIT TRANSACTION;
END 