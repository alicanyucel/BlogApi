USE [master]
GO
/****** Object:  Database [NewsLetterCaseDatabase]    Script Date: 5.01.2025 11:17:58 ******/
CREATE DATABASE [NewsLetterCaseDatabase] ON  PRIMARY 
( NAME = N'NewsLetterCaseDatabase', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\NewsLetterCaseDatabase.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NewsLetterCaseDatabase_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\NewsLetterCaseDatabase_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewsLetterCaseDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET DB_CHAINING OFF 
GO
USE [NewsLetterCaseDatabase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5.01.2025 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Newsletter]    Script Date: 5.01.2025 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Newsletter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Newsletter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5.01.2025 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameLastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [NewsLetterCaseDatabase] SET  READ_WRITE 
GO
