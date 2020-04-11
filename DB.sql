/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [master]
GO
/****** Object:  Database [CarRent]    Script Date: 4/11/2020 11:52:50 PM ******/
CREATE DATABASE [CarRent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRent', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CarRent.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRent_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CarRent_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarRent] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRent] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRent] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRent] SET RECOVERY FULL 
GO
ALTER DATABASE [CarRent] SET  MULTI_USER 
GO
ALTER DATABASE [CarRent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRent] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRent] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CarRent', N'ON'
GO
ALTER DATABASE [CarRent] SET QUERY_STORE = OFF
GO
USE [CarRent]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [CarRent]
GO
/****** Object:  Table [dbo].[MST_CAR]    Script Date: 4/11/2020 11:52:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MST_CAR](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](50) NULL,
	[Model] [nvarchar](100) NULL,
	[ProdYear] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_MST_CAR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_DELETE]    Script Date: 4/11/2020 11:52:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Krista Natalia
-- Create date: 2020-4-10
-- Description:	SP to delete data in MST_CAR
-- =============================================
CREATE PROCEDURE [dbo].[SP_MST_CAR_DELETE] 
	(
	@Id bigint
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM MST_CAR output deleted.id WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_INSERT]    Script Date: 4/11/2020 11:52:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Krista Natalia
-- Create date: 2020-4-9
-- Description:	SP for Insert Master Car
-- =============================================
CREATE PROCEDURE [dbo].[SP_MST_CAR_INSERT]  
	(
	@Brand varchar(50),
	@Model varchar(100),
	@ProdYear int,
	@Price float
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[MST_CAR]
	(Brand,Model,ProdYear,Price,CreatedDate
	) output inserted.id
	VALUES
	(@Brand,@Model,@ProdYear,@Price,getdate())
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_READ]    Script Date: 4/11/2020 11:52:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Krista Natalia
-- Create date: 2020-4-10
-- Description:	SP select data from MST_CAR
-- =============================================
CREATE PROCEDURE [dbo].[SP_MST_CAR_READ]   

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM MST_CAR
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_TRUNCATE]    Script Date: 4/11/2020 11:52:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Krista Natalia
-- Create date: 2020-04-11
-- Description:	SP to truncate table MST_CAR
-- =============================================
CREATE PROCEDURE [dbo].[SP_MST_CAR_TRUNCATE] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	TRUNCATE TABLE MST_CAR
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_UPDATE]    Script Date: 4/11/2020 11:52:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Krista Natalia
-- Create date: 2020-4-10
-- Description:	SP to update data in MST_CAR
-- =============================================
CREATE PROCEDURE [dbo].[SP_MST_CAR_UPDATE] 
	(
	@Id bigint,
	@Brand varchar(50),
	@Model varchar(100),
	@ProdYear int,
	@Price float
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[MST_CAR]
	SET
	Brand = @Brand,
	Model = @Model,
	ProdYear = @ProdYear,
	Price = @Price,
	UpdatedDate = getdate()
	OUTPUT Inserted.ID 
	WHERE
	Id = @Id
END
GO
USE [master]
GO
ALTER DATABASE [CarRent] SET  READ_WRITE 
GO
