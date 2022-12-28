CREATE DATABASE [Sistema]
GO

USE [Sistema]
GO

CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
    (
	    [UsuarioId] ASC
    )
)
