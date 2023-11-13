IF NOT EXISTS(SELECT * FROM sys.databases WHERE NAME = 'MercadoDb')
BEGIN 
CREATE DATABASE MercadoDb
END

IF EXISTS (SELECT * FROM sys.databases WHERE NAME = 'MercadoDb')
BEGIN 

USE MercadoDb
END