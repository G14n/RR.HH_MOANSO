USE [master]
GO
/****** Object:  Database [MOANSO]    Script Date: 25/10/2023 16:08:43 ******/
CREATE DATABASE [MOANSO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MOANSO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MOANSO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MOANSO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MOANSO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MOANSO] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MOANSO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MOANSO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MOANSO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MOANSO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MOANSO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MOANSO] SET ARITHABORT OFF 
GO
ALTER DATABASE [MOANSO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MOANSO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MOANSO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MOANSO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MOANSO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MOANSO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MOANSO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MOANSO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MOANSO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MOANSO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MOANSO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MOANSO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MOANSO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MOANSO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MOANSO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MOANSO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MOANSO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MOANSO] SET RECOVERY FULL 
GO
ALTER DATABASE [MOANSO] SET  MULTI_USER 
GO
ALTER DATABASE [MOANSO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MOANSO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MOANSO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MOANSO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MOANSO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MOANSO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MOANSO', N'ON'
GO
ALTER DATABASE [MOANSO] SET QUERY_STORE = ON
GO
ALTER DATABASE [MOANSO] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MOANSO]
GO
/****** Object:  Table [dbo].[Publicacion]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publicacion](
	[ID_publicacion] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Requerimiento] [varchar](100) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Publicacion] PRIMARY KEY CLUSTERED 
(
	[ID_publicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajado]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajado](
	[ID_Trabajador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido_Pa] [nvarchar](20) NOT NULL,
	[Apellido_Ma] [nvarchar](20) NOT NULL,
	[Fecha_Nacimiento] [datetime] NOT NULL,
	[Direccion] [nvarchar](30) NULL,
	[Telefono1] [nvarchar](9) NOT NULL,
	[Telefono2] [nvarchar](9) NULL,
	[Banco] [nvarchar](10) NOT NULL,
	[Cuenta_Bancaria] [nvarchar](20) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Trabajado] PRIMARY KEY CLUSTERED 
(
	[ID_Trabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spDeshabilitaPublicacion]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spDeshabilitaPublicacion]
(@ID_publicacion int
)
as
begin
update Publicacion set
Estado = 0
where ID_publicacion = @ID_publicacion
end
GO
/****** Object:  StoredProcedure [dbo].[spDeshabilitaTrabajador]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeshabilitaTrabajador]
(@ID_Trabajador int
)
as
begin
update Trabajado set
Estado = 0
where ID_Trabajador = @ID_Trabajador
end
GO
/****** Object:  StoredProcedure [dbo].[spEditaPublicacion]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEditaPublicacion]
(@ID_publicacion int,
 @Titulo nvarchar(50),
 @Descripcion nvarchar(100), 
 @Requerimiento nvarchar(100), 
 @Estado bit
)
as
begin
update Publicacion set
Titulo=@Titulo,
Descripcion=@Descripcion,
Requerimiento=@Requerimiento,
Estado=@Estado
where ID_publicacion = @ID_publicacion
end
GO
/****** Object:  StoredProcedure [dbo].[spEditaTrabajador]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEditaTrabajador]
(@ID_Trabajador int,
 @Nombre nvarchar(50),
 @Apellido_Pa nvarchar(20), 
 @Apellido_Ma nvarchar(20), 
 @Fecha_Nacimiento datetime, 
 @Direccion nvarchar(30), 
 @Telefono1 nvarchar(9),
 @Telefono2 nvarchar(9),
 @Banco nvarchar(10),
 @Cuenta_Bancaria nvarchar(20),
 @Estado bit
)
as
begin
update Trabajado set
Nombre=@Nombre,
Apellido_Pa=@Apellido_Pa,
Apellido_Ma=@Apellido_Ma,
Fecha_Nacimiento=@Fecha_Nacimiento,
Direccion=@Direccion,
Telefono1=@Telefono1,
Telefono2=@Telefono2,
Banco=@Banco,
Cuenta_Bancaria=@Cuenta_Bancaria,
Estado=@Estado
where ID_Trabajador = @ID_Trabajador
end
GO
/****** Object:  StoredProcedure [dbo].[spInsertaPublicacion]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertaPublicacion]
(
 @Titulo nvarchar(50),
 @Descripcion nvarchar(100), 
 @Requerimiento nvarchar(100), 
 @Estado bit

)
as
begin
insert into Publicacion( Titulo,Descripcion,Requerimiento,Estado) values
( @Titulo, @Descripcion, @Requerimiento, @Estado)
end
GO
/****** Object:  StoredProcedure [dbo].[spInsertaTrabajador]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[spInsertaTrabajador]
(
 @Nombre nvarchar(50),
 @Apellido_Pa nvarchar(20), 
 @Apellido_Ma nvarchar(20), 
 @Fecha_Nacimiento datetime, 
 @Direccion nvarchar(30), 
 @Telefono1 nvarchar(9),
 @Telefono2 nvarchar(9),
 @Banco nvarchar(10),
 @Cuenta_Bancaria nvarchar(20),
 @Estado bit
)
as
begin
insert into Trabajado( Nombre, Apellido_Pa, Apellido_Ma, Fecha_Nacimiento, Direccion, Telefono1,Telefono2,Banco,Cuenta_Bancaria,Estado) values
( @Nombre, @Apellido_Pa, @Apellido_Ma, @Fecha_Nacimiento, @Direccion, @Telefono1,@Telefono2,@Banco,@Cuenta_Bancaria,@Estado)
end
GO
/****** Object:  StoredProcedure [dbo].[spListaCliente]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListaCliente]
AS
SELECT idCliente, razonSocial, idTipoCliente, fecRegCliente, idCiudad, estCliente
from Cliente
 where estCliente='1'
GO
/****** Object:  StoredProcedure [dbo].[spListaPublicacion]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spListaPublicacion]
AS
SELECT ID_publicacion,Titulo,Descripcion,Requerimiento,Estado
from Publicacion
 where Estado='1'
GO
/****** Object:  StoredProcedure [dbo].[spListaTrabajador]    Script Date: 25/10/2023 16:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListaTrabajador]
AS
SELECT ID_Trabajador, Nombre, Apellido_Pa, Apellido_Ma, Fecha_Nacimiento, Direccion, Telefono1,Telefono2,Banco,Cuenta_Bancaria,Estado
from Trabajado
 where Estado='1'
GO
USE [master]
GO
ALTER DATABASE [MOANSO] SET  READ_WRITE 
GO
