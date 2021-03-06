/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2012
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [CarRent]
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_UPDATE]    Script Date: 4/12/2020 10:13:43 AM ******/
DROP PROCEDURE [dbo].[SP_MST_CAR_UPDATE]
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_TRUNCATE]    Script Date: 4/12/2020 10:13:43 AM ******/
DROP PROCEDURE [dbo].[SP_MST_CAR_TRUNCATE]
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_READ]    Script Date: 4/12/2020 10:13:43 AM ******/
DROP PROCEDURE [dbo].[SP_MST_CAR_READ]
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_INSERT]    Script Date: 4/12/2020 10:13:43 AM ******/
DROP PROCEDURE [dbo].[SP_MST_CAR_INSERT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_DELETE]    Script Date: 4/12/2020 10:13:43 AM ******/
DROP PROCEDURE [dbo].[SP_MST_CAR_DELETE]
GO
/****** Object:  Table [dbo].[MST_CAR]    Script Date: 4/12/2020 10:13:43 AM ******/
DROP TABLE [dbo].[MST_CAR]
GO
USE [master]
GO
/****** Object:  Database [CarRent]    Script Date: 4/12/2020 10:13:43 AM ******/
DROP DATABASE [CarRent]
GO
/****** Object:  Database [CarRent]    Script Date: 4/12/2020 10:13:43 AM ******/
CREATE DATABASE [CarRent]
GO
USE [CarRent]
GO
/****** Object:  Table [dbo].[MST_CAR]    Script Date: 4/12/2020 10:13:43 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_DELETE]    Script Date: 4/12/2020 10:13:43 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_INSERT]    Script Date: 4/12/2020 10:13:43 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_READ]    Script Date: 4/12/2020 10:13:43 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_TRUNCATE]    Script Date: 4/12/2020 10:13:43 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_MST_CAR_UPDATE]    Script Date: 4/12/2020 10:13:43 AM ******/
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
