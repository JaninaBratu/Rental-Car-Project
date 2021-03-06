USE [master]
GO
/****** Object:  Database [Rental_Car]    Script Date: 8/17/2016 9:56:11 PM ******/
CREATE DATABASE [Rental_Car]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Rental_Car', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\Rental_Car.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Rental_Car_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\Rental_Car_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Rental_Car] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Rental_Car].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Rental_Car] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Rental_Car] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Rental_Car] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Rental_Car] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Rental_Car] SET ARITHABORT OFF 
GO
ALTER DATABASE [Rental_Car] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Rental_Car] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Rental_Car] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Rental_Car] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Rental_Car] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Rental_Car] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Rental_Car] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Rental_Car] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Rental_Car] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Rental_Car] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Rental_Car] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Rental_Car] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Rental_Car] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Rental_Car] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Rental_Car] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Rental_Car] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Rental_Car] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Rental_Car] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Rental_Car] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Rental_Car] SET  MULTI_USER 
GO
ALTER DATABASE [Rental_Car] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Rental_Car] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Rental_Car] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Rental_Car] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Rental_Car]
GO
/****** Object:  Table [dbo].[tblBrand]    Script Date: 8/17/2016 9:56:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBrand](
	[BrandId] [int] NOT NULL identity(1,1),
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblBrand] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCar]    Script Date: 8/17/2016 9:56:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCar](
	[CarId] [int] NOT NULL identity(1,1),
	[ModelId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[RegistrationNumber] [int] NOT NULL,
	[isRent] [bit] NOT NULL,
 CONSTRAINT [PK_tblCar] PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblClient]    Script Date: 8/17/2016 9:56:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClient](
	[ClientId] [int] NOT NULL identity(1,1),
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[CNP] [int] NOT NULL,
 CONSTRAINT [PK_tblClient] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLocation]    Script Date: 8/17/2016 9:56:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLocation](
	[LocationId] [int] NOT NULL identity(1,1),
	[Name] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[TotalSum] [int] NOT NULL,
 CONSTRAINT [PK_tblLocation] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblModel]    Script Date: 8/17/2016 9:56:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblModel](
	[ModelId] [int] NOT NULL identity(1,1),
	[Name] [nvarchar](50) NOT NULL,
	[BrandId] [int] NOT NULL,
	[PricePerDay] [float] NULL,
 CONSTRAINT [PK_tblModel] PRIMARY KEY CLUSTERED 
(
	[ModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblRezervation]    Script Date: 8/17/2016 9:56:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRezervation](
	[RezervationId] [int] NOT NULL identity(1,1),
	[ClientId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[StartLocation] [nvarchar](50) NOT NULL,
	[EndLocation] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_tblRezervation] PRIMARY KEY CLUSTERED 
(
	[RezervationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblCar]  WITH CHECK ADD FOREIGN KEY([ModelId])
REFERENCES [dbo].[tblModel] ([ModelId])
GO
ALTER TABLE [dbo].[tblCar]  WITH CHECK ADD  CONSTRAINT [FK_tblCar_tblLocation] FOREIGN KEY([LocationId])
REFERENCES [dbo].[tblLocation] ([LocationId])
GO
ALTER TABLE [dbo].[tblCar] CHECK CONSTRAINT [FK_tblCar_tblLocation]
GO
ALTER TABLE [dbo].[tblModel]  WITH CHECK ADD  CONSTRAINT [FK_tblModel_tblBrand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[tblBrand] ([BrandId])
GO
ALTER TABLE [dbo].[tblModel] CHECK CONSTRAINT [FK_tblModel_tblBrand]
GO
ALTER TABLE [dbo].[tblRezervation]  WITH CHECK ADD  CONSTRAINT [FK_tblRezervation_tblCar] FOREIGN KEY([CarId])
REFERENCES [dbo].[tblCar] ([CarId])
GO
ALTER TABLE [dbo].[tblRezervation] CHECK CONSTRAINT [FK_tblRezervation_tblCar]
GO
ALTER TABLE [dbo].[tblRezervation]  WITH CHECK ADD  CONSTRAINT [FK_tblRezervation_tblClient] FOREIGN KEY([ClientId])
REFERENCES [dbo].[tblClient] ([ClientId])
GO
ALTER TABLE [dbo].[tblRezervation] CHECK CONSTRAINT [FK_tblRezervation_tblClient]
GO
USE [master]
GO
ALTER DATABASE [Rental_Car] SET  READ_WRITE 
GO
