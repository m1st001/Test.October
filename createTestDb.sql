USE [master]
GO
/****** Object:  Database [Test.October]    Script Date: 03.10.2024 17:43:12 ******/
CREATE DATABASE [Test.October]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test.October', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Test.October.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Test.October_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Test.October_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Test.October] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test.October].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test.October] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test.October] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test.October] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test.October] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test.October] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test.October] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test.October] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test.October] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test.October] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test.October] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test.October] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test.October] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test.October] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test.October] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test.October] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test.October] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test.October] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test.October] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test.October] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test.October] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test.October] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test.October] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test.October] SET RECOVERY FULL 
GO
ALTER DATABASE [Test.October] SET  MULTI_USER 
GO
ALTER DATABASE [Test.October] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test.October] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test.October] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test.October] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test.October] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Test.October] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Test.October', N'ON'
GO
ALTER DATABASE [Test.October] SET QUERY_STORE = ON
GO
ALTER DATABASE [Test.October] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Test.October]
GO
/****** Object:  UserDefinedFunction [dbo].[CheckAssemblyFeasibility]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CheckAssemblyFeasibility](@OrderId INT)
RETURNS NVARCHAR(50)  
AS
BEGIN
    DECLARE @TotalAssemblyTime INT;
    DECLARE @TotalAvailableTime INT;
    DECLARE @Result NVARCHAR(50);

    -- Вычисляем общее время сборки для заказа
    SELECT @TotalAssemblyTime = SUM(i.AssemblyTime * at.Quantity)
    FROM AssemblyTasks at
    JOIN Items i ON at.ItemId = i.ItemId
    WHERE at.OrderId = @OrderId;

    -- Вычисляем общее доступное время на всех сборочных площадках
    SELECT @TotalAvailableTime = SUM(i.AssemblyTime * inv.Quantity)
    FROM Inventory inv
    JOIN Items i ON inv.ItemId = i.ItemId
    JOIN AssemblySites asite ON inv.AssemblySiteId = asite.AssemblySiteId;

    -- Сравниваем время сборки и доступное время
    IF @TotalAssemblyTime <= @TotalAvailableTime
        SET @Result = 'Да, успеют';
    ELSE
        SET @Result = 'Нет, не успеют';

    RETURN @Result;  
END;
GO
/****** Object:  UserDefinedFunction [dbo].[GetAssemblyTasks]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetAssemblyTasks]()
RETURNS @ResultTable TABLE
(
    SiteName NVARCHAR(MAX),
    OrderId INT,
    ItemType NVARCHAR(MAX),
    Quantity INT,
    AssemblyDate DATETIME
)
AS
BEGIN
    INSERT INTO @ResultTable
    SELECT 
        asite.SiteName,
        at.OrderId,
        i.ItemType,
        at.Quantity,
        at.AssemblyDate
    FROM 
        AssemblyTasks at
    JOIN 
        Items i ON at.ItemId = i.ItemId
    JOIN 
        Inventory inv ON inv.ItemId = i.ItemId
    JOIN 
        AssemblySites asite ON inv.AssemblySiteId = asite.AssemblySiteId
    ORDER BY 
        asite.SiteName, at.AssemblyDate;

    RETURN;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[GetItemQuantitiesBySite]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetItemQuantitiesBySite](@AssemblySiteId BIGINT = NULL)
RETURNS @ResultTable TABLE
(
    ItemType NVARCHAR(MAX),
    TotalQuantity INT,
    SiteName NVARCHAR(MAX)
)
AS
BEGIN
    INSERT INTO @ResultTable
    SELECT 
        i.ItemType,
        SUM(inv.Quantity) AS TotalQuantity,
        asite.SiteName
    FROM 
        Inventory inv
    JOIN 
        Items i ON inv.ItemId = i.ItemId
    JOIN 
        AssemblySites asite ON inv.AssemblySiteId = asite.AssemblySiteId
    WHERE 
        (@AssemblySiteId IS NULL OR inv.AssemblySiteId = @AssemblySiteId)  -- Фильтр по ID площадки
    GROUP BY 
        i.ItemType, asite.SiteName
    ORDER BY 
        asite.SiteName, i.ItemType;

    RETURN;
END;
GO
/****** Object:  Table [dbo].[Items]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemId] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemType] [nvarchar](50) NOT NULL,
	[AssemblyTime] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[InventoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[AssemblySiteId] [bigint] NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetAvailableStock]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetAvailableStock](@AssemblySiteId BIGINT)
RETURNS TABLE
AS
RETURN
(
    SELECT i.ItemType, SUM(inv.Quantity) AS AvailableQuantity
    FROM Inventory inv
    JOIN Items i ON inv.ItemId = i.ItemId
    WHERE inv.AssemblySiteId = @AssemblySiteId
    GROUP BY i.ItemType
);
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssemblySites]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssemblySites](
	[AssemblySiteId] [bigint] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AssemblySiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssemblyTasks]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssemblyTasks](
	[TaskId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AssemblyDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetActiveAssemblySites]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetActiveAssemblySites]()
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT asite.SiteName
    FROM AssemblySites asite
    JOIN AssemblyTasks an ON asite.AssemblySiteId = an.TaskId
    JOIN Orders o ON an.OrderId = o.OrderId
    WHERE o.Status = 'Active' -- Статус "Active" для активных заказов
);
GO
/****** Object:  UserDefinedFunction [dbo].[GetAvailableInventory]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetAvailableInventory]()
RETURNS TABLE
AS
RETURN
(
    SELECT 
        asite.SiteName,
        i.ItemType,
        SUM(inv.Quantity) AS AvailableQty
    FROM 
        Inventory inv
    JOIN 
        Items i ON inv.ItemId = i.ItemId
    JOIN 
        Orders o ON inv.OrderId = o.OrderId  -- Используем OrderId
    JOIN 
        AssemblySites asite ON inv.AssemblySiteId = asite.AssemblySiteId
    WHERE 
        o.Status IN ('Completed', 'Canceled')  -- Готовые заказы
    GROUP BY 
        asite.SiteName, 
        i.ItemType
);
GO
ALTER TABLE [dbo].[AssemblyTasks]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
GO
ALTER TABLE [dbo].[AssemblyTasks]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD FOREIGN KEY([AssemblySiteId])
REFERENCES [dbo].[AssemblySites] ([AssemblySiteId])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Orders]
GO
/****** Object:  StoredProcedure [dbo].[AddAssemblyTask]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAssemblyTask]
    @OrderId INT,
    @ItemId BIGINT,
    @Quantity INT,
    @AssemblyDate DATETIME
AS
BEGIN
    INSERT INTO AssemblyTasks (OrderId, ItemId, Quantity, AssemblyDate)
    VALUES (@OrderId, @ItemId, @Quantity, @AssemblyDate);
END
GO
/****** Object:  StoredProcedure [dbo].[AddItem]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddItem]
    @ItemType NVARCHAR(50),
    @AssemblyTime INT
AS
BEGIN
    INSERT INTO Items (ItemType, AssemblyTime) VALUES (@ItemType, @AssemblyTime);
END
GO
/****** Object:  StoredProcedure [dbo].[AddOrder]    Script Date: 03.10.2024 17:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddOrder]
    @OrderDate DATETIME,
    @Status NVARCHAR(50)
AS
BEGIN
    INSERT INTO Orders (OrderDate, Status) VALUES (@OrderDate, @Status);
END
GO
USE [master]
GO
ALTER DATABASE [Test.October] SET  READ_WRITE 
GO
