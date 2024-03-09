USE [master]
GO
/****** Object:  Database [Book]    Script Date: 18/10/2023 23:53:17 ******/
CREATE DATABASE [Book]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Book', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Book.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Book_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Book_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Book] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Book].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Book] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Book] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Book] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Book] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Book] SET ARITHABORT OFF 
GO
ALTER DATABASE [Book] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Book] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Book] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Book] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Book] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Book] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Book] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Book] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Book] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Book] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Book] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Book] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Book] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Book] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Book] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Book] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Book] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Book] SET RECOVERY FULL 
GO
ALTER DATABASE [Book] SET  MULTI_USER 
GO
ALTER DATABASE [Book] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Book] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Book] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Book] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Book] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Book] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Book', N'ON'
GO
ALTER DATABASE [Book] SET QUERY_STORE = OFF
GO
USE [Book]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 18/10/2023 23:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[id] [int] NOT NULL,
	[name] [nvarchar](128) NULL,
	[coverimage] [nvarchar](128) NULL,
	[author] [nvarchar](128) NULL,
	[publishedyear] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (1, N'Sotus - Tháng Ngày Ta Cùng Nhau Bước Qua - Tập 1 (Bản Thường)', N'images/Book1.jpg', N'BitterSweet', 2019)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (2, N'Hậu Cung Như Ý Truyện - Tập 1', N'images/Book2.jpg', N'Lưu Liễm Tử', 2022)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (3, N'Phương Pháp Giải Toán Tự Luận Và Trắc Nghiệm Hình Học Lớp 12', N'images/Book3.jpg', N'Nguyễn Văn Nho', 2017)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (4, N'Thiên Quan Tứ Phúc - Tập 1 (Tái Bản)', N'images/Book4.jpg', N'Mặc Hương Đồng Khứu', 2021)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (5, N'Tuổi Trẻ Đáng Giá Bao Nhiêu', N'images/Book5.jpg', N'Rosie Nguyễn', 2021)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (6, N'Dám Mơ Lớn, Đừng Hoài Phí Tuổi Trẻ', N'images/Book6.jpg', N'Lư Tư Hạo', 2022)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (7, N'Hành Tinh Của Một Kẻ Nghĩ Nhiều', N'images/Book7.jpg', N'Amateur Psychology Nguyễn Đoàn Minh Thư', 2023)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (8, N'Cây Cam Ngọt Của Tôi', N'images/Book8.jpg', N'José Mauro de Vasconcelos', 2020)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (9, N'Nhà Giả Kim', N'images/Book9.jpg', N'Paulo Coelho', 2020)
INSERT [dbo].[Book] ([id], [name], [coverimage], [author], [publishedyear]) VALUES (10, N'Đắc Nhân Tâm', N'images/Book10.jpg', N'Dale Carnegie', 2021)
GO
USE [master]
GO
ALTER DATABASE [Book] SET  READ_WRITE 
GO
