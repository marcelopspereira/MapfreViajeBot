USE [master]
GO
/****** Object:  Database [Grupo01]    Script Date: 12/4/2016 1:25:31 AM ******/
CREATE DATABASE [Grupo01]
GO
ALTER DATABASE [Grupo01] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Grupo01].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Grupo01] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Grupo01] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Grupo01] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Grupo01] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Grupo01] SET ARITHABORT OFF 
GO
ALTER DATABASE [Grupo01] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Grupo01] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Grupo01] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Grupo01] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Grupo01] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Grupo01] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Grupo01] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Grupo01] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Grupo01] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Grupo01] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Grupo01] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [Grupo01] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Grupo01] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Grupo01] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Grupo01] SET  MULTI_USER 
GO
ALTER DATABASE [Grupo01] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Grupo01] SET QUERY_STORE = ON
GO
ALTER DATABASE [Grupo01] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO)
GO
USE [Grupo01]
GO
/****** Object:  Table [dbo].[tblEspecialidades]    Script Date: 12/4/2016 1:25:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEspecialidades](
	[Pais] [varchar](50) NULL,
	[Cidade] [varchar](50) NULL,
	[Especialidade] [varchar](100) NULL,
	[Hospital] [varchar](100) NULL,
	[Endereco] [varchar](200) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
)

GO
/****** Object:  Table [dbo].[tblUsuarios]    Script Date: 12/4/2016 1:25:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsuarios](
	[CPF] [char](15) NOT NULL,
	[Nascimento] [datetime] NULL,
	[Nome] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET IDENTITY_INSERT [dbo].[tblEspecialidades] ON 

GO
INSERT [dbo].[tblEspecialidades] ([Pais], [Cidade], [Especialidade], [Hospital], [Endereco], [Id]) VALUES (N'FRANÇA', N'PARIS', N'ORTOPEDISTA', N'Sainte Anne', N'Rue Rivoli,181', 1)
GO
INSERT [dbo].[tblEspecialidades] ([Pais], [Cidade], [Especialidade], [Hospital], [Endereco], [Id]) VALUES (N'FRANÇA', N'PARIS', N'PRONTO SOCORRO', N'Mount Sinai', N'275 7th Ave', 2)
GO
INSERT [dbo].[tblEspecialidades] ([Pais], [Cidade], [Especialidade], [Hospital], [Endereco], [Id]) VALUES (N'FRANÇA', N'PARIS', N'GERAL', N'Ospedale San Carlo', N'275, Via Aurelia', 3)
GO
INSERT [dbo].[tblEspecialidades] ([Pais], [Cidade], [Especialidade], [Hospital], [Endereco], [Id]) VALUES (N'ITALIA', N'ROMA', N'ORTOPEDISTA', N'Centro Ortopédico Goya', N'165, Gran via', 4)
GO
SET IDENTITY_INSERT [dbo].[tblEspecialidades] OFF
GO
INSERT [dbo].[tblUsuarios] ([CPF], [Nascimento], [Nome]) VALUES (N'012.345.678-91 ', CAST(N'2016-01-01T00:00:00.000' AS DateTime), N'Maria da Silva Sauro')
GO
INSERT [dbo].[tblUsuarios] ([CPF], [Nascimento], [Nome]) VALUES (N'101.234.567-89 ', CAST(N'2016-01-01T00:00:00.000' AS DateTime), N'Julio da Silva Sauro')
GO
INSERT [dbo].[tblUsuarios] ([CPF], [Nascimento], [Nome]) VALUES (N'123.456.789-10 ', CAST(N'2016-01-01T00:00:00.000' AS DateTime), N'Maria da Silva Sauro')
GO
INSERT [dbo].[tblUsuarios] ([CPF], [Nascimento], [Nome]) VALUES (N'910.123.456-78 ', CAST(N'2016-01-01T00:00:00.000' AS DateTime), N'Joana da Silva Sauro')
GO
USE [master]
GO
ALTER DATABASE [Grupo01] SET  READ_WRITE 
GO
