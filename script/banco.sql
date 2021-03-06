 CREATE DATABASE Livraria
 
 GO
 
 USE Livraria
 
CREATE TABLE [dbo].[InstituicaodeEnsino](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NULL,
	[Endereco] [varchar](max) NULL,
	[CNPJ] [varchar](14) NULL,
 CONSTRAINT [PK_InstituicaodeEnsino] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livro]    Script Date: 11/08/2020 18:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Genero] [varchar](max) NULL,
	[Descricao] [varchar](max) NULL,
	[Publicacao] [date] NULL,
	[Titulo] [varchar](max) NULL,
	[Editora] [varchar](max) NULL,
	[Paginas] [int] NULL,
	[Autor] [varchar](max) NULL,
	[Emprestado] [bit] NOT NULL,
	[Reservado] [bit] NOT NULL,
	[IdUsuarioReserva] [int] NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/08/2020 18:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NULL,
	[Endereco] [varchar](max) NULL,
	[CPF] [varchar](11) NULL,
	[Telefone] [varchar](20) NULL,
	[Email] [varchar](200) NULL,
	[IdInstituicaoDeEnsino] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioLivroEmprestado]    Script Date: 11/08/2020 18:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioLivroEmprestado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdLivro] [int] NULL,
	[DataEmprestimo] [datetime] NULL,
	[DataDevolucao] [datetime] NULL,
	[Devolvido] [bit] NOT NULL,
 CONSTRAINT [PK__UsuarioL__3213E83F2996F475] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[InstituicaodeEnsino] ON 

INSERT [dbo].[InstituicaodeEnsino] ([Id], [Nome], [Endereco], [CNPJ]) VALUES (19, N'Teste1', N'asdfasdfasdf', N'00000000000191')
INSERT [dbo].[InstituicaodeEnsino] ([Id], [Nome], [Endereco], [CNPJ]) VALUES (24, N'DDDSDFS', N'asdfasdf', N'12312312312312')
SET IDENTITY_INSERT [dbo].[InstituicaodeEnsino] OFF
SET IDENTITY_INSERT [dbo].[Livro] ON 

INSERT [dbo].[Livro] ([Id], [Genero], [Descricao], [Publicacao], [Titulo], [Editora], [Paginas], [Autor], [Emprestado], [Reservado], [IdUsuarioReserva]) VALUES (20, N'GEEGEG', N'Descriçaõ teste', CAST(N'2020-08-10' AS Date), N'TESTE1', N'ASDFASDF', 10, N'Fernando do carmo', 0, 0, NULL)
INSERT [dbo].[Livro] ([Id], [Genero], [Descricao], [Publicacao], [Titulo], [Editora], [Paginas], [Autor], [Emprestado], [Reservado], [IdUsuarioReserva]) VALUES (21, N'gENERO', N'ASDFJ ASDFA SDASDF ASDF', CAST(N'2020-08-10' AS Date), N'Livro 2', N'string', 10, N'AMADEU', 0, 1, 24)
INSERT [dbo].[Livro] ([Id], [Genero], [Descricao], [Publicacao], [Titulo], [Editora], [Paginas], [Autor], [Emprestado], [Reservado], [IdUsuarioReserva]) VALUES (22, N'Terro', N'Descriçaõ teste', CAST(N'2020-10-08' AS Date), N'Livro 2', N'EDITORA TESTE', 10, N'Autor teste', 0, 1, 24)
INSERT [dbo].[Livro] ([Id], [Genero], [Descricao], [Publicacao], [Titulo], [Editora], [Paginas], [Autor], [Emprestado], [Reservado], [IdUsuarioReserva]) VALUES (28, N'TESTES', N'asdfasd', CAST(N'2020-08-10' AS Date), N'TESTE', N'ASDFASD', 123, N'asdfasdf', 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Livro] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nome], [Endereco], [CPF], [Telefone], [Email], [IdInstituicaoDeEnsino]) VALUES (24, N'Aristóteles', N'TESTE', N'04829787163', N'1321321321326132', N'asdfasdfasdfadf', 24)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [dbo].[UsuarioLivroEmprestado] ON 

INSERT [dbo].[UsuarioLivroEmprestado] ([Id], [IdUsuario], [IdLivro], [DataEmprestimo], [DataDevolucao], [Devolvido]) VALUES (4, 24, 28, CAST(N'2020-08-10T19:15:10.340' AS DateTime), CAST(N'2020-08-11T14:53:50.687' AS DateTime), 1)
INSERT [dbo].[UsuarioLivroEmprestado] ([Id], [IdUsuario], [IdLivro], [DataEmprestimo], [DataDevolucao], [Devolvido]) VALUES (6, 24, 20, CAST(N'2020-08-11T14:54:13.490' AS DateTime), CAST(N'2020-08-11T14:54:17.573' AS DateTime), 1)
INSERT [dbo].[UsuarioLivroEmprestado] ([Id], [IdUsuario], [IdLivro], [DataEmprestimo], [DataDevolucao], [Devolvido]) VALUES (7, 24, 20, CAST(N'2020-08-11T14:54:44.193' AS DateTime), CAST(N'2020-08-11T14:54:48.680' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[UsuarioLivroEmprestado] OFF
ALTER TABLE [dbo].[Livro] ADD  DEFAULT ((0)) FOR [Emprestado]
GO
ALTER TABLE [dbo].[Livro] ADD  DEFAULT ((0)) FOR [Reservado]
GO
ALTER TABLE [dbo].[UsuarioLivroEmprestado] ADD  CONSTRAINT [DF__UsuarioLi__Devol__151B244E]  DEFAULT ((0)) FOR [Devolvido]
GO
ALTER TABLE [dbo].[Livro]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Usuario] FOREIGN KEY([IdUsuarioReserva])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Livro] CHECK CONSTRAINT [FK_Livro_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_InstituicaodeEnsino] FOREIGN KEY([IdInstituicaoDeEnsino])
REFERENCES [dbo].[InstituicaodeEnsino] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_InstituicaodeEnsino]
GO
ALTER TABLE [dbo].[UsuarioLivroEmprestado]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioLivrosEmpretados_Livro] FOREIGN KEY([IdLivro])
REFERENCES [dbo].[Livro] ([Id])
GO
ALTER TABLE [dbo].[UsuarioLivroEmprestado] CHECK CONSTRAINT [FK_UsuarioLivrosEmpretados_Livro]
GO
ALTER TABLE [dbo].[UsuarioLivroEmprestado]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioLivrosEmpretados_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioLivroEmprestado] CHECK CONSTRAINT [FK_UsuarioLivrosEmpretados_Usuario]
GO
USE [master]
GO
ALTER DATABASE [Livraria] SET  READ_WRITE 
GO
