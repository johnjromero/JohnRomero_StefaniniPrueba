IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'DataBase')
  BEGIN
    CREATE DATABASE [AppDB]

    END
    GO
       USE [AppDB]
    GO

GO

/*CLIENTE*/
CREATE TABLE Customer(
CustomerId INT IDENTITY(1,1) NOT NULL,
FullName VARCHAR(50) NOT NULL,
CreationDate DATETIME DEFAULT GETDATE()
PRIMARY KEY(CustomerId)
)

INSERT Customer(FullName) VALUES
('Jennifer Villa')

GO

/*BANCO*/
CREATE TABLE Bank(
BankId INT NOT NULL,
BankName VARCHAR(50) NOT NULL
PRIMARY KEY(BankId)
)

INSERT Bank(BankId,BankName) VALUES
(1, 'BBVA'),
(2, 'BANORTE')

GO

/*CUENTA BANCARIA*/
CREATE TABLE BankAccount(
BankAccountId INT IDENTITY(1,1) NOT NULL,
AccountNumber VARCHAR(50) DEFAULT NULL,
Denomination VARCHAR(4) NOT NULL,
BalanceAmount DECIMAL(28,8) NOT NULL,
CustomerId INT NOT NULL,
BankId INT NOT NULL,
PRIMARY KEY(BankAccountId),
CONSTRAINT FK_Customer FOREIGN KEY(CustomerId) REFERENCES Customer(CustomerId),
CONSTRAINT FK_Bank FOREIGN KEY(BankId) REFERENCES Bank(BankId)
)

INSERT BankAccount(AccountNumber,Denomination,BalanceAmount,CustomerId,BankId) VALUES
('123','A',110000000.00000000,1,1),
('456','B',65000000.00000000,1,2),
('789','C',500000.00000000,1,2)

GO

/*TIPO TRANSACCION*/
CREATE TABLE TransactionType(
TypeId INT NOT NULL,
TypeName VARCHAR(40) NOT NULL
PRIMARY KEY(TypeId)
)

INSERT TransactionType(TypeId,TypeName) VALUES
(1, 'Retiro'),
(2 ,'Transferencia')

/*TRANSACCION*/
CREATE TABLE BankingTransaction(
TransactionId INT IDENTITY(1,1) NOT NULL,
TransactionTypeId INT NOT NULL,
Amount DECIMAL(28,8) NOT NULL,
GMF DECIMAL(28,8) NOT NULL,
ParentAccount INT NOT NULL,
DestinationAccount INT DEFAULT NULL,
AccountBalance DECIMAL(28,8) NOT NULL,
PRIMARY KEY(TransactionId),
CONSTRAINT FK_TransactionType FOREIGN KEY(TransactionTypeId) REFERENCES TransactionType(TypeId),
CONSTRAINT FK_ParentBankAccount FOREIGN KEY(ParentAccount) REFERENCES BankAccount(BankAccountId),
CONSTRAINT FK_DestinationBankAccount FOREIGN KEY(DestinationAccount) REFERENCES BankAccount(BankAccountId)
)

CREATE TABLE AuditReport(
AuditId INT IDENTITY(1,1) NOT NULL,
CreationDate DATETIME NOT NULL,
Module VARCHAR(30) NOT NULL,
IssuerIP VARCHAR(15),
UserAgent VARCHAR(100) NOT NULL,
OperationType VARCHAR(20) NOT NULL,
ResultOperation VARCHAR(10) NOT NULL,
ResultMessage VARCHAR(100) DEFAULT NULL,
PRIMARY KEY(AuditId)
)