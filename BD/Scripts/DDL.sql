CREATE DATABASE Classificados_2
 
 USE Classificados_2

CREATE TABLE TipoUsuarios(
idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
TipoUsuario CHAR(5) UNIQUE NOT NULL
)
GO

CREATE TABLE TipoClassificados(
idTipoClassificados TINYINT PRIMARY KEY IDENTITY,
Tipo VARCHAR(16) UNIQUE NOT NULL
)
GO

CREATE TABLE Nichos(
idNicho TINYINT PRIMARY KEY IDENTITY,
Nicho VARCHAR(25) UNIQUE NOT NULL
)
GO

CREATE TABLE Categorias(
idCategoria SMALLINT PRIMARY KEY IDENTITY,
idNicho TINYINT FOREIGN KEY REFERENCES Nichos(idNicho),
Categoria VARCHAR(30) UNIQUE NOT NULL
)
GO

CREATE TABLE Situacao(
idSituacao TINYINT PRIMARY KEY IDENTITY,
Situacao VARCHAR(15) UNIQUE NOT NULL
)
GO

CREATE TABLE Usuarios(
idUsuario INT PRIMARY KEY IDENTITY,
idTipoUsuario TINYINT FOREIGN KEY REFERENCES TipoUsuarios(idTipoUsuario),
Nome VARCHAR(20),
Sobrenome VARCHAR(50),
Email VARCHAR(256) UNIQUE,
Senha CHAR(60) NOT NULL,
DDD VARCHAR(3),
Telefone VARCHAR(9) UNIQUE
)

CREATE TABLE Classificados(
idClassificado INT PRIMARY KEY IDENTITY,
idUsuario INT FOREIGN KEY REFERENCES Usuarios(idUsuario),
idSituacao TINYINT FOREIGN KEY REFERENCES Situacao(idSituacao),
Titulo VARCHAR(100) NOT NULL,
Descricao VARCHAR(300),
DataCricao DATETIME,
DataExpiracao DATETIME,
Acessos SMALLINT
)
ALTER TABLE Classificados ADD Imagem varchar(255)not null

CREATE TABLE Ofertas(
idOfertas INT PRIMARY KEY IDENTITY,
idUsuario INT FOREIGN KEY REFERENCES Usuarios(idUsuario),
idClassificado INT FOREIGN KEY REFERENCES Classificados(idClassificado),
idSituacao TINYINT FOREIGN KEY REFERENCES Situacao(idSituacao),
Descricao VARCHAR(70)
)

CREATE TABLE ImagemBanco (
    idImg INT PRIMARY KEY identity(1,1),
    idUsuario INT FOREIGN KEY REFERENCES Usuarios(idUsuario),
	idClassificado INT FOREIGN KEY REFERENCES Classificados(idclassificado),
    Binario VARBINARY(MAX) NOT NULL,
    mimeType VARCHAR(30) NOT NULL,
    NomeArquivo VARCHAR(150) NOT NULL
);
GO