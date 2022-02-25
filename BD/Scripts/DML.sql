USE Classificados_2

INSERT INTO TipoUsuarios(TipoUsuario) VALUES ('Admin'), ('Comum')
GO

INSERT INTO TipoClassificados(Tipo) VALUES ('Produto'),('Serviço'),('Imobiliária')
GO

INSERT INTO Nichos(Nicho) VALUES ('Tecnologia'),('Esportes'),('Esilo de Vida'),('Beleza'),('Saúde')
GO

INSERT INTO Categorias VALUES (1,'Computadores'),(1,'Notebooks'),(1,'Video-Games'),(3,'Hair Style'),(4,'Maquiagem'),(5,'Equipamentos Aeróbicos')
GO

INSERT INTO Situacao VALUES ('Em Andamento'),('Cancelado'),('Concluida'),('Negada'),('Aceita'),('Favoritada')
GO

INSERT INTO Usuarios(idTipoUsuario,Nome,Email,Senha) VALUES (1,'Administrador','admin@admin','$2y$11$AMq74F4glA44Td4Gskj4v.49M7kpKcv3MeUwjZi83BEbwl6ZQ0uB2')
GO
