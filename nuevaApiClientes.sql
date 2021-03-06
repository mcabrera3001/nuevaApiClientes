USE [master]
GO
/****** Object:  Database [trocadero]    Script Date: 29/9/2021 12:14:31 ******/
CREATE DATABASE [trocadero]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'trocadero', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSQLSERVER\MSSQL\DATA\trocadero.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'trocadero_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSQLSERVER\MSSQL\DATA\trocadero_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [trocadero] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [trocadero].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [trocadero] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [trocadero] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [trocadero] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [trocadero] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [trocadero] SET ARITHABORT OFF 
GO
ALTER DATABASE [trocadero] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [trocadero] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [trocadero] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [trocadero] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [trocadero] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [trocadero] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [trocadero] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [trocadero] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [trocadero] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [trocadero] SET  DISABLE_BROKER 
GO
ALTER DATABASE [trocadero] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [trocadero] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [trocadero] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [trocadero] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [trocadero] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [trocadero] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [trocadero] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [trocadero] SET RECOVERY FULL 
GO
ALTER DATABASE [trocadero] SET  MULTI_USER 
GO
ALTER DATABASE [trocadero] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [trocadero] SET DB_CHAINING OFF 
GO
ALTER DATABASE [trocadero] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [trocadero] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [trocadero] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [trocadero] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'trocadero', N'ON'
GO
ALTER DATABASE [trocadero] SET QUERY_STORE = OFF
GO
USE [trocadero]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 29/9/2021 12:14:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[dni] [char](8) NOT NULL,
	[domicilio] [varchar](50) NULL,
	[telefono] [char](10) NULL,
	[posnet] [int] NOT NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta_corriente]    Script Date: 29/9/2021 12:14:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta_corriente](
	[id_cuenta_corriente] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[fecha] [smalldatetime] NOT NULL,
	[movimiento] [varchar](7) NOT NULL,
	[transaccion] [varchar](6) NOT NULL,
	[posnet] [char](2) NULL,
	[importe] [decimal](8, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cuenta_corriente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [dni], [domicilio], [telefono], [posnet]) VALUES (1, N'Mauro', N'Cabrera', N'36115002', N'', N'          ', 1)
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [dni], [domicilio], [telefono], [posnet]) VALUES (2, N'Alejandra', N'Fernadez', N'36584468', N'', N'          ', 2)
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [dni], [domicilio], [telefono], [posnet]) VALUES (3, N'Luis', N'Cabrera', N'13310036', N'', N'          ', 1)
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [dni], [domicilio], [telefono], [posnet]) VALUES (4, N'Patricia', N'Barrionuevo', N'17270572', N'', N'          ', 3)
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
USE [master]
GO
ALTER DATABASE [trocadero] SET  READ_WRITE 
GO
