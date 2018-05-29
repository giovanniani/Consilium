USE [master]
GO
/****** Object:  Database [Consilium]    Script Date: 29/5/2018 12:04:31 ******/
CREATE DATABASE [Consilium]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Consilium', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVERGIOVANNI\MSSQL\DATA\Consilium.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Consilium_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVERGIOVANNI\MSSQL\DATA\Consilium_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Consilium] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Consilium].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Consilium] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Consilium] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Consilium] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Consilium] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Consilium] SET ARITHABORT OFF 
GO
ALTER DATABASE [Consilium] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Consilium] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Consilium] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Consilium] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Consilium] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Consilium] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Consilium] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Consilium] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Consilium] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Consilium] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Consilium] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Consilium] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Consilium] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Consilium] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Consilium] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Consilium] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Consilium] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Consilium] SET RECOVERY FULL 
GO
ALTER DATABASE [Consilium] SET  MULTI_USER 
GO
ALTER DATABASE [Consilium] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Consilium] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Consilium] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Consilium] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Consilium] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Consilium', N'ON'
GO
ALTER DATABASE [Consilium] SET QUERY_STORE = OFF
GO
USE [Consilium]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Consilium]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 29/5/2018 12:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[idAgenda] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[idAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comision]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comision](
	[idComision] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](25) NULL,
	[objetivo] [nvarchar](500) NULL,
	[fechaFin] [date] NULL,
	[fechaIni] [date] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Comision] PRIMARY KEY CLUSTERED 
(
	[idComision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComisionXSesion]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComisionXSesion](
	[idComisionXSesion] [int] IDENTITY(1,1) NOT NULL,
	[idComision] [int] NULL,
	[idSesion] [int] NULL,
 CONSTRAINT [PK_ComisionXSesion] PRIMARY KEY CLUSTERED 
(
	[idComisionXSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoPunto]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoPunto](
	[idEstado] [int] NOT NULL,
	[nombre] [nvarchar](25) NULL,
 CONSTRAINT [PK_EstadoPunto] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Justificacion]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Justificacion](
	[idJustificacion] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[idUsuario] [nvarchar](30) NULL,
	[asunto] [nvarchar](50) NULL,
	[texto] [nvarchar](500) NULL,
	[estado] [nvarchar](25) NULL,
 CONSTRAINT [PK_Justificacion] PRIMARY KEY CLUSTERED 
(
	[idJustificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Justification]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Justification](
	[idJustication] [int] IDENTITY(1,1) NOT NULL,
	[idMember] [varchar](30) NULL,
	[date] [date] NULL,
	[about] [varchar](50) NULL,
	[body] [varchar](350) NULL,
 CONSTRAINT [PK_Justification] PRIMARY KEY CLUSTERED 
(
	[idJustication] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logueo]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logueo](
	[idUsuario] [nvarchar](30) NOT NULL,
	[nombreUsuario] [nvarchar](50) NULL,
	[contrasenna] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logueo] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Identification] [nvarchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[Phone] [varbinary](20) NULL,
	[Email] [nchar](10) NULL,
	[Type] [nvarchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiembroXComision]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiembroXComision](
	[idMiembroXComision] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [nvarchar](30) NOT NULL,
	[idComisionXSesion] [int] NOT NULL,
	[tipoMiembro] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_MiembroXComision] PRIMARY KEY CLUSTERED 
(
	[idMiembroXComision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiembroXSesion]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiembroXSesion](
	[idMiembroXQuorum] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [nvarchar](30) NOT NULL,
	[idSesion] [int] NOT NULL,
	[presente] [bit] NOT NULL,
 CONSTRAINT [PK_MiembroXQuorum] PRIMARY KEY CLUSTERED 
(
	[idMiembroXQuorum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mocion]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mocion](
	[idMocion] [int] IDENTITY(1,1) NOT NULL,
	[idPunto] [int] NULL,
	[punto] [nvarchar](max) NULL,
	[propuesta] [nvarchar](max) NULL,
 CONSTRAINT [PK_Mocion] PRIMARY KEY CLUSTERED 
(
	[idMocion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motion]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motion](
	[idMotion] [int] IDENTITY(1,1) NOT NULL,
	[Tittle] [varchar](50) NULL,
	[Date] [date] NULL,
	[member] [varchar](50) NULL,
	[Proponentes] [varchar](50) NULL,
	[Propuesta] [varchar](350) NULL,
 CONSTRAINT [PK_Motion] PRIMARY KEY CLUSTERED 
(
	[idMotion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProponenteXMocion]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProponenteXMocion](
	[idProponente] [int] IDENTITY(1,1) NOT NULL,
	[idMocion] [int] NOT NULL,
	[idUsuario] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_ProponenteXMocion] PRIMARY KEY CLUSTERED 
(
	[idProponente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Punto]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Punto](
	[idPunto] [int] IDENTITY(1,1) NOT NULL,
	[idEstado] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[titulo] [nvarchar](50) NOT NULL,
	[idUsuario] [nvarchar](30) NOT NULL,
	[considerandos] [nvarchar](500) NOT NULL,
	[resultandos] [nvarchar](500) NOT NULL,
	[acuerdos] [nvarchar](500) NOT NULL,
	[adjunto] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Punto] PRIMARY KEY CLUSTERED 
(
	[idPunto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntoXAgenda]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntoXAgenda](
	[idPuntoXAgenda] [int] IDENTITY(1,1) NOT NULL,
	[idAgenda] [int] NULL,
	[idPunto] [int] NULL,
 CONSTRAINT [PK_PuntoXAgenda] PRIMARY KEY CLUSTERED 
(
	[idPuntoXAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Name] [varchar](50) NULL,
	[MemberName] [varchar](50) NULL,
	[MemberId] [varchar](50) NULL,
	[Considerations] [varchar](200) NULL,
	[Results] [varchar](200) NULL,
	[Agreements] [varchar](200) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultadoPunto]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadoPunto](
	[idResultado] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[votosFavor] [int] NOT NULL,
	[votosContra] [int] NOT NULL,
	[votosNulo] [int] NOT NULL,
	[votosAbstencion] [int] NOT NULL,
	[resultado] [nvarchar](25) NOT NULL,
	[idSesion] [int] NOT NULL,
	[idPunto] [int] NOT NULL,
	[quorum] [int] NOT NULL,
 CONSTRAINT [PK_ResultadoPunto] PRIMARY KEY CLUSTERED 
(
	[idResultado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesion]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesion](
	[idSesion] [int] IDENTITY(1,1) NOT NULL,
	[idTipo] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[idAgenda] [int] NOT NULL,
 CONSTRAINT [PK_Sesion] PRIMARY KEY CLUSTERED 
(
	[idSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[idSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[idPunto] [int] NULL,
	[considerandos] [nvarchar](350) NULL,
	[resultandos] [nvarchar](350) NULL,
	[acuerdos] [nvarchar](350) NULL,
	[adjunto] [nvarchar](max) NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[idSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoSesion]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoSesion](
	[idTipo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](30) NULL,
 CONSTRAINT [PK_TipoSesion] PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[idTipo] [int] NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/5/2018 12:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [nvarchar](30) NOT NULL,
	[nombre] [nvarchar](30) NOT NULL,
	[apellidoP] [nvarchar](30) NOT NULL,
	[apellidoM] [nvarchar](30) NOT NULL,
	[tipo] [int] NOT NULL,
	[estado] [nvarchar](25) NOT NULL,
	[correo] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ComisionXSesion]  WITH CHECK ADD  CONSTRAINT [FK_ComisionXSesion_Comision] FOREIGN KEY([idComision])
REFERENCES [dbo].[Comision] ([idComision])
GO
ALTER TABLE [dbo].[ComisionXSesion] CHECK CONSTRAINT [FK_ComisionXSesion_Comision]
GO
ALTER TABLE [dbo].[ComisionXSesion]  WITH CHECK ADD  CONSTRAINT [FK_ComisionXSesion_Sesion] FOREIGN KEY([idSesion])
REFERENCES [dbo].[Sesion] ([idSesion])
GO
ALTER TABLE [dbo].[ComisionXSesion] CHECK CONSTRAINT [FK_ComisionXSesion_Sesion]
GO
ALTER TABLE [dbo].[Justificacion]  WITH CHECK ADD  CONSTRAINT [FK_Justificacion_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Justificacion] CHECK CONSTRAINT [FK_Justificacion_Usuario]
GO
ALTER TABLE [dbo].[Logueo]  WITH CHECK ADD  CONSTRAINT [FK_Logueo_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logueo] CHECK CONSTRAINT [FK_Logueo_Usuario]
GO
ALTER TABLE [dbo].[MiembroXComision]  WITH CHECK ADD  CONSTRAINT [FK_MiembroXComision_ComisionXSesion] FOREIGN KEY([idComisionXSesion])
REFERENCES [dbo].[ComisionXSesion] ([idComisionXSesion])
GO
ALTER TABLE [dbo].[MiembroXComision] CHECK CONSTRAINT [FK_MiembroXComision_ComisionXSesion]
GO
ALTER TABLE [dbo].[MiembroXComision]  WITH CHECK ADD  CONSTRAINT [FK_MiembroXComision_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MiembroXComision] CHECK CONSTRAINT [FK_MiembroXComision_Usuario]
GO
ALTER TABLE [dbo].[MiembroXSesion]  WITH CHECK ADD  CONSTRAINT [FK_MiembroXQuorum_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[MiembroXSesion] CHECK CONSTRAINT [FK_MiembroXQuorum_Usuario]
GO
ALTER TABLE [dbo].[MiembroXSesion]  WITH CHECK ADD  CONSTRAINT [FK_MiembroXSesion_Sesion] FOREIGN KEY([idSesion])
REFERENCES [dbo].[Sesion] ([idSesion])
GO
ALTER TABLE [dbo].[MiembroXSesion] CHECK CONSTRAINT [FK_MiembroXSesion_Sesion]
GO
ALTER TABLE [dbo].[Mocion]  WITH CHECK ADD  CONSTRAINT [FK_Mocion_Punto] FOREIGN KEY([idPunto])
REFERENCES [dbo].[Punto] ([idPunto])
GO
ALTER TABLE [dbo].[Mocion] CHECK CONSTRAINT [FK_Mocion_Punto]
GO
ALTER TABLE [dbo].[ProponenteXMocion]  WITH CHECK ADD  CONSTRAINT [FK_ProponenteXMocion_Mocion] FOREIGN KEY([idMocion])
REFERENCES [dbo].[Mocion] ([idMocion])
GO
ALTER TABLE [dbo].[ProponenteXMocion] CHECK CONSTRAINT [FK_ProponenteXMocion_Mocion]
GO
ALTER TABLE [dbo].[ProponenteXMocion]  WITH CHECK ADD  CONSTRAINT [FK_ProponenteXMocion_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ProponenteXMocion] CHECK CONSTRAINT [FK_ProponenteXMocion_Usuario]
GO
ALTER TABLE [dbo].[Punto]  WITH CHECK ADD  CONSTRAINT [FK_Punto_EstadoPunto] FOREIGN KEY([idEstado])
REFERENCES [dbo].[EstadoPunto] ([idEstado])
GO
ALTER TABLE [dbo].[Punto] CHECK CONSTRAINT [FK_Punto_EstadoPunto]
GO
ALTER TABLE [dbo].[Punto]  WITH CHECK ADD  CONSTRAINT [FK_Punto_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Punto] CHECK CONSTRAINT [FK_Punto_Usuario]
GO
ALTER TABLE [dbo].[PuntoXAgenda]  WITH CHECK ADD  CONSTRAINT [FK_PuntoXAgenda_Agenda] FOREIGN KEY([idAgenda])
REFERENCES [dbo].[Agenda] ([idAgenda])
GO
ALTER TABLE [dbo].[PuntoXAgenda] CHECK CONSTRAINT [FK_PuntoXAgenda_Agenda]
GO
ALTER TABLE [dbo].[PuntoXAgenda]  WITH CHECK ADD  CONSTRAINT [FK_PuntoXAgenda_Punto] FOREIGN KEY([idPunto])
REFERENCES [dbo].[Punto] ([idPunto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PuntoXAgenda] CHECK CONSTRAINT [FK_PuntoXAgenda_Punto]
GO
ALTER TABLE [dbo].[ResultadoPunto]  WITH CHECK ADD  CONSTRAINT [FK_ResultadoPunto_Punto] FOREIGN KEY([idPunto])
REFERENCES [dbo].[Punto] ([idPunto])
GO
ALTER TABLE [dbo].[ResultadoPunto] CHECK CONSTRAINT [FK_ResultadoPunto_Punto]
GO
ALTER TABLE [dbo].[Sesion]  WITH CHECK ADD  CONSTRAINT [FK_Sesion_Agenda] FOREIGN KEY([idAgenda])
REFERENCES [dbo].[Agenda] ([idAgenda])
GO
ALTER TABLE [dbo].[Sesion] CHECK CONSTRAINT [FK_Sesion_Agenda]
GO
ALTER TABLE [dbo].[Sesion]  WITH CHECK ADD  CONSTRAINT [FK_Sesion_TipoSesion] FOREIGN KEY([idTipo])
REFERENCES [dbo].[TipoSesion] ([idTipo])
GO
ALTER TABLE [dbo].[Sesion] CHECK CONSTRAINT [FK_Sesion_TipoSesion]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Punto] FOREIGN KEY([idPunto])
REFERENCES [dbo].[Punto] ([idPunto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Punto]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY([tipo])
REFERENCES [dbo].[TipoUsuario] ([idTipo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario]
GO
/****** Object:  StoredProcedure [dbo].[deleteUsuario]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[deleteUsuario] 
	-- Add the parameters for the stored procedure here
	@pIdUsuario NVARCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from Usuario
	WHERE Usuario.idUsuario = @pIdUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[getAsistencia]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getAsistencia]
	-- Add the parameters for the stored procedure here
	@idSesion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT m.idSesion, m.idUsuario, u.nombre, u.apellidoP, u.apellidoM, m.presente
	FROM 
		MiembroXSesion m
	JOIN 
		Usuario u
	ON
		u.idUsuario = m.idUsuario
	WHERE
		m.idSesion = @idSesion
END
GO
/****** Object:  StoredProcedure [dbo].[getMiembrosXSesion]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getMiembrosXSesion]
	-- Add the parameters for the stored procedure here
	@idMiembro nvarchar(30),
	@idSesion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MiembroXSesion.idMiembroXQuorum
	FROM MiembroXSesion 
	where MiembroXSesion.idUsuario = @idMiembro AND MiembroXSesion.idSesion = @idSesion
END
GO
/****** Object:  StoredProcedure [dbo].[getPunto]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getPunto]
	-- Add the parameters for the stored procedure here
	@idPunto int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Punto
	WHERE Punto.idPunto = @idPunto
END
GO
/****** Object:  StoredProcedure [dbo].[getPuntosdeUsuario]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getPuntosdeUsuario]
	@idUsuario nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.idUsuario,u.nombre, u.apellidoP, u.apellidoM, p.titulo, p.fecha
	FROM Usuario u
	JOIN Punto p
	ON p.idUsuario = u.idUsuario
	WHERE u.idUsuario = @idUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[getPuntosSesion]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getPuntosSesion]
	-- Add the parameters for the stored procedure here
	@idSesion int
AS
BEGIN
	SELECT p.titulo, p.acuerdos, p.considerandos, p.idUsuario,p.resultandos
	FROM Punto p
	INNER JOIN PuntoXAgenda px
	ON p.idPunto = px.idPunto
	INNER JOIN Sesion s
	ON s.idAgenda = px.idAgenda
	WHERE s.idSesion = @idSesion
	
END
GO
/****** Object:  StoredProcedure [dbo].[getPuntosXUsuaio]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getPuntosXUsuaio]
	-- Add the parameters for the stored procedure here
	@idUsuario nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.idUsuario,u.nombre, u.apellidoP, u.apellidoM, p.titulo, p.fecha
	FROM Usuario u
	JOIN Punto p
	ON p.idUsuario = u.idUsuario
	WHERE u.idUsuario = @idUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[getPuntosXUsuario]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getPuntosXUsuario]
	@idUsuario nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.idUsuario,u.nombre, u.apellidoP, u.apellidoM, p.titulo, p.fecha
	FROM Usuario u
	JOIN Punto p
	ON p.idUsuario = u.idUsuario
	WHERE u.idUsuario = @idUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[getReporteSesion]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getReporteSesion] 
	-- Add the parameters for the stored procedure here
	@idSesion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT s.idSesion, s.fecha, r.idPunto, r.votosFavor, r.votosContra
	FROM Sesion s
	JOIN ResultadoPunto r
	ON s.idSesion = r.idSesion
	WHERE s.idSesion = @idSesion
END
GO
/****** Object:  StoredProcedure [dbo].[getReporteXSesion]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getReporteXSesion] 
	@idSesion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT s.idSesion, s.fecha, r.idPunto, r.votosFavor, r.votosContra, r.votosNulo, r.votosAbstencion,
	p.acuerdos,p.considerandos,p.resultandos,p.titulo

	FROM Sesion s
	JOIN ResultadoPunto r
	ON s.idSesion = r.idSesion
	JOIN Punto p
	ON r.idPunto = p.idPunto
	WHERE s.idSesion = @idSesion
END
GO
/****** Object:  StoredProcedure [dbo].[getSesionReporte]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getSesionReporte]
	-- Add the parameters for the stored procedure here
	@idSesion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT s.idSesion, s.fecha, r.idPunto, r.votosFavor, r.votosContra, r.votosNulo, r.votosAbstencion,
	p.acuerdos,p.considerandos,p.resultandos,p.titulo

	FROM Sesion s
	JOIN ResultadoPunto r
	ON s.idSesion = r.idSesion
	JOIN Punto p
	ON r.idPunto = p.idPunto
	WHERE s.idSesion = @idSesion
END
GO
/****** Object:  StoredProcedure [dbo].[getUsuarios]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getUsuarios] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Usuario;
END
GO
/****** Object:  StoredProcedure [dbo].[getUsuarioUnico]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getUsuarioUnico] 
	-- Add the parameters for the stored procedure here
	@pIdUsuario NVARCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Usuario where Usuario.idUsuario = @pIdUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[setUpdateUsuario]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[setUpdateUsuario] 
	-- Add the parameters for the stored procedure here
	@pIdUsuario nvarchar(30),
	@pNombre nvarchar(30),
	@pCorreo nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
IF (SELECT count(*) FROM Usuario where idUsuario = @pIdUsuario) = 0
	BEGIN
		INSERT INTO Usuario(idUsuario,nombre,correo)
		VALUES(@pIdUsuario,@pNombre,@pCorreo)
	END
ELSE	
	BEGIN
	UPDATE Usuario
	SET
		nombre = @pNombre,
		correo = @pCorreo
	WHERE idUsuario= @pIdUsuario
	END

END

GO
/****** Object:  StoredProcedure [dbo].[updateMiembroXSesion]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[updateMiembroXSesion] 
	-- Add the parameters for the stored procedure here
	@idMiembro NVARCHAR(30),
	@idSesion int,
	@isSelected bit
AS
	UPDATE 
		MiembroXSesion
	SET
		presente = @isSelected
	WHERE 
		idUsuario = @idMiembro AND idSesion = @idSesion
GO
/****** Object:  StoredProcedure [dbo].[updateResultadoPunto]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[updateResultadoPunto]
	-- Add the parameters for the stored procedure here
	@idPunto int,
	@votosFavor int,
	@votosContra int, 
	@votosAbstencion int,
	@votosNulo int,
	@quorum int,
	@resultado nvarchar(25)
AS
BEGIN

UPDATE
	ResultadoPunto
SET	
	votosFavor = @votosFavor, votosContra = @votosContra,
	votosNulo = @votosNulo, votosAbstencion = @votosAbstencion,
	resultado = @resultado, quorum = @quorum
WHERE 
	ResultadoPunto.idPunto = @idPunto
END
GO
/****** Object:  StoredProcedure [dbo].[usuarioYPuntos]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usuarioYPuntos] 
	-- Add the parameters for the stored procedure here
	@idUsuario nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.idUsuario,u.nombre, u.apellidoP, u.apellidoM, p.titulo
	FROM Usuario u
	JOIN Punto p
	ON p.idUsuario = u.idUsuario
	WHERE u.idUsuario = @idUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[votePunto]    Script Date: 29/5/2018 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[votePunto]
	-- Add the parameters for the stored procedure here
	@idPunto int,
	@estadoPunto int
AS
BEGIN
	UPDATE Punto
SET 
	Punto.idEstado = @estadoPunto
WHERE
	Punto.idPunto = @idPunto
	
END
GO
USE [master]
GO
ALTER DATABASE [Consilium] SET  READ_WRITE 
GO
