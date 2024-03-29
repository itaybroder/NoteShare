USE [master]
GO
/****** Object:  Database [NoteShare]    Script Date: 04/05/2023 15:36:17 ******/
CREATE DATABASE [NoteShare]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NoteShare', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\NoteShare.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NoteShare_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\NoteShare_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NoteShare] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NoteShare].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NoteShare] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NoteShare] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NoteShare] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NoteShare] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NoteShare] SET ARITHABORT OFF 
GO
ALTER DATABASE [NoteShare] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NoteShare] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NoteShare] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NoteShare] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NoteShare] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NoteShare] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NoteShare] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NoteShare] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NoteShare] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NoteShare] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NoteShare] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NoteShare] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NoteShare] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NoteShare] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NoteShare] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NoteShare] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NoteShare] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NoteShare] SET RECOVERY FULL 
GO
ALTER DATABASE [NoteShare] SET  MULTI_USER 
GO
ALTER DATABASE [NoteShare] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NoteShare] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NoteShare] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NoteShare] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NoteShare] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NoteShare] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NoteShare] SET QUERY_STORE = OFF
GO
USE [NoteShare]
GO
/****** Object:  Table [dbo].[CommentTBL]    Script Date: 04/05/2023 15:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentTBL](
	[UserID] [int] NOT NULL,
	[NotebookID] [int] NOT NULL,
	[Comment] [nvarchar](100) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CommentTBL] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikeTBL]    Script Date: 04/05/2023 15:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikeTBL](
	[UserID] [int] NOT NULL,
	[NotebookID] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[LikeID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_LikeTBL] PRIMARY KEY CLUSTERED 
(
	[LikeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotebookTBL]    Script Date: 04/05/2023 15:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotebookTBL](
	[NotebookID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Format] [nvarchar](50) NOT NULL,
	[Path] [nvarchar](50) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
	[Accessibility] [nvarchar](50) NULL,
	[SchoolId] [int] NULL,
	[SubjectID] [int] NOT NULL,
	[OnlineNotebookFormat] [nvarchar](4000) NULL,
 CONSTRAINT [PK_NotebookTBL] PRIMARY KEY CLUSTERED 
(
	[NotebookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolTBL]    Script Date: 04/05/2023 15:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolTBL](
	[SchoolID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_SchoolTBL] PRIMARY KEY CLUSTERED 
(
	[SchoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectTBL]    Script Date: 04/05/2023 15:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectTBL](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
 CONSTRAINT [PK_SubjectTBL] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInSchoolTBL]    Script Date: 04/05/2023 15:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInSchoolTBL](
	[UserID] [int] NOT NULL,
	[SchoolID] [int] NOT NULL,
 CONSTRAINT [PK_UserInSchoolTBL] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[SchoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTBL]    Script Date: 04/05/2023 15:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTBL](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FIrstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Permission] [nvarchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserTBL] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CommentTBL] ON 

INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (16, 1019, N'This is very cool notebook', CAST(N'2023-05-01' AS Date), 56)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (17, 1024, N'Wow i love this notebook', CAST(N'2023-05-01' AS Date), 57)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (17, 1021, N'I love physics', CAST(N'2023-05-01' AS Date), 58)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (17, 1023, N'I love math', CAST(N'2023-05-01' AS Date), 59)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (17, 1023, N'cool', CAST(N'2023-05-01' AS Date), 60)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (17, 1042, N'Nice', CAST(N'2023-05-01' AS Date), 61)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (24, 1042, N'אני אוהב פיזיקה', CAST(N'2023-05-01' AS Date), 62)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (30, 1043, N'וואי מחברת מגניבה רצח', CAST(N'2023-05-02' AS Date), 63)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (30, 1043, N'כל הכבוד!! זה ממש עזר לי עם סמדר, בלי קשר סמדר מורה ממש טובה', CAST(N'2023-05-02' AS Date), 64)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (30, 1022, N'מגניב', CAST(N'2023-05-02' AS Date), 65)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (31, 1045, N'וואו, מגניב', CAST(N'2023-05-02' AS Date), 66)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (31, 1047, N'Hello', CAST(N'2023-05-02' AS Date), 67)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (24, 1043, N'כן סמדר באמת מדהימה', CAST(N'2023-05-02' AS Date), 69)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (24, 1043, N'קול', CAST(N'2023-05-02' AS Date), 70)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (24, 1045, N'קולללללל', CAST(N'2023-05-02' AS Date), 71)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (24, 1045, N'אוהב אותך גון', CAST(N'2023-05-02' AS Date), 72)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (24, 1048, N'wow', CAST(N'2023-05-02' AS Date), 73)
INSERT [dbo].[CommentTBL] ([UserID], [NotebookID], [Comment], [CreatedDate], [CommentID]) VALUES (24, 1048, N'wow this is cool', CAST(N'2023-05-04' AS Date), 74)
SET IDENTITY_INSERT [dbo].[CommentTBL] OFF
GO
SET IDENTITY_INSERT [dbo].[LikeTBL] ON 

INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (16, 1024, CAST(N'0001-01-01' AS Date), 3)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (17, 1018, CAST(N'2023-01-14' AS Date), 5)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (17, 1027, CAST(N'2023-01-15' AS Date), 7)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (22, 1028, CAST(N'2023-01-16' AS Date), 9)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (22, 1029, CAST(N'2023-01-16' AS Date), 10)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-16' AS Date), 24)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-16' AS Date), 25)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-16' AS Date), 26)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-16' AS Date), 27)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-16' AS Date), 28)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-16' AS Date), 29)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-16' AS Date), 30)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (17, 1024, CAST(N'2023-02-17' AS Date), 35)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-17' AS Date), 36)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1023, CAST(N'2023-02-19' AS Date), 38)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1023, CAST(N'2023-02-19' AS Date), 40)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (16, 1021, CAST(N'2023-02-20' AS Date), 41)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1027, CAST(N'2023-02-20' AS Date), 42)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1023, CAST(N'2023-02-20' AS Date), 43)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1023, CAST(N'2023-03-14' AS Date), 45)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1023, CAST(N'2023-03-14' AS Date), 46)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1018, CAST(N'2023-04-08' AS Date), 48)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (29, 1040, CAST(N'2023-04-27' AS Date), 51)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (29, 1019, CAST(N'2023-04-27' AS Date), 53)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (29, 1029, CAST(N'2023-04-27' AS Date), 54)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (29, 1041, CAST(N'2023-04-27' AS Date), 55)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1021, CAST(N'2023-04-28' AS Date), 56)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (16, 1039, CAST(N'2023-04-29' AS Date), 57)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (17, 1042, CAST(N'2023-05-01' AS Date), 58)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1042, CAST(N'2023-05-01' AS Date), 59)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (30, 1043, CAST(N'2023-05-02' AS Date), 60)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (16, 1043, CAST(N'2023-05-02' AS Date), 61)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (31, 1046, CAST(N'2023-05-02' AS Date), 62)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (31, 1045, CAST(N'2023-05-02' AS Date), 63)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (16, 1022, CAST(N'2023-05-02' AS Date), 64)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1043, CAST(N'2023-05-02' AS Date), 65)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1045, CAST(N'2023-05-02' AS Date), 66)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1048, CAST(N'2023-05-02' AS Date), 67)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (27, 1048, CAST(N'2023-05-02' AS Date), 68)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1048, CAST(N'2023-05-02' AS Date), 69)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1048, CAST(N'2023-05-02' AS Date), 70)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1048, CAST(N'2023-05-02' AS Date), 71)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (16, 1048, CAST(N'2023-05-02' AS Date), 72)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1048, CAST(N'2023-05-04' AS Date), 73)
INSERT [dbo].[LikeTBL] ([UserID], [NotebookID], [CreatedDate], [LikeID]) VALUES (24, 1048, CAST(N'2023-05-04' AS Date), 74)
SET IDENTITY_INSERT [dbo].[LikeTBL] OFF
GO
SET IDENTITY_INSERT [dbo].[NotebookTBL] ON 

INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1016, 17, N'History', N'This is my history notebook, contains the summery of all the stuff.', N'purple.png', N'document', N'notebookfiles/notebook-1016.pdf', CAST(N'2023-01-07' AS Date), CAST(N'2023-05-02' AS Date), N'private', 11, 6, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1018, 16, N'Physics', N'My high school notebook.', N'blue.png', N'online', N'', CAST(N'2022-12-27' AS Date), CAST(N'2023-05-02' AS Date), N'public', NULL, 5, N'<h2 style="text-align: center;"><font color="#e6d1d1">This is my liked Notebook</font></h2><div style="text-align: center;"><font color="#e6d1d1">hello</font></div><div style="text-align: center;"><font color="#e6d1d1">df</font></div><div style="text-align: center;"><font color="#e6d1d1">sdfsdfs</font></div><div style="text-align: center;"><font color="#e6d1d1">sdfsdfsd</font></div>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1019, 17, N'Math', N'ffhfhfdh', N'green.png', N'document', N'notebookfiles/notebook-1019.pdf', CAST(N'2023-01-14' AS Date), CAST(N'2023-01-14' AS Date), N'public', NULL, 1, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1021, 16, N'Physics is not so fun', N'This is a test viewing notebooks from search', N'blue.png', N'online', N'', CAST(N'2023-01-07' AS Date), CAST(N'2023-01-07' AS Date), N'public', NULL, 1, N'<b>Helloxcxvxcxvx</b>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1022, 17, N'Art ', N'This is my art notebook. I love art.', N'purple.png', N'online', N'notebookfiles/notebook-1022.pdf', CAST(N'2023-01-10' AS Date), CAST(N'2023-05-02' AS Date), N'public', 13, 11, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1023, 17, N'linear algebra', N'', N'purple.png', N'online', N'', CAST(N'2023-01-14' AS Date), CAST(N'2023-05-02' AS Date), N'public', 11, 1, N'<h2><font face="Garamond"><b>This is my algebra course</b></font></h2><div><font face="Garamond"><b><br></b></font></div><div><ol><li><font face="Garamond" size="4"><b>hey</b></font></li><li><font face="Garamond" size="4"><b>hello</b></font></li><li><font face="Garamond" size="4"><b>whatsapp</b></font></li></ol><div><ul><li><font face="Garamond" size="4"><b>hey</b></font></li><li><font face="Garamond" size="4"><b>he</b></font></li><li><font face="Garamond" size="4"><b>hey</b></font></li></ul><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff">5<sup>6</sup> * 5<sup>2</sup>= 5<sup>6 + 2</sup></font></div></div></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>dsfhjdsfsdfkjs</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>sd</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>fsd</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>fsd</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>s</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>df</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>sd</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>fsdfsdfsdfsdfsd</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>sdfsdfs</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>sdfsdfsdfs</sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup><br></sup></font></div><div><font size="6" style="background-color: rgb(255, 26, 26);" color="#ffffff"><sup>sdfs</sup></font></div><div><br></div><div><br></div>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1024, 17, N'Computer Networking', N'this is my notebook from Ramon class.', N'green.png', N'online', N'', CAST(N'2023-01-13' AS Date), CAST(N'2023-05-02' AS Date), N'private', 12, 4, N'<h2 style="text-align: center;"><b style=""><font color="#ffffff" style="background-color: rgb(51, 100, 112);">Hello this is my first working notebook</font></b></h2><div style="text-align: center;"><b style="background-color: rgb(246, 252, 253);"><u>hello world</u></b></div><div style="text-align: left;"><b style="background-color: rgb(246, 252, 253);">I love computer science</b></div><div style="text-align: left;"><b style="background-color: rgb(246, 252, 253);"><br></b></div><div style="text-align: left;"><b style="background-color: rgb(246, 252, 253);"><br></b></div><div style="text-align: left;"><b style="background-color: rgb(246, 252, 253);"><br></b></div><h2 style="text-align: left;"><b style="background-color: rgb(216, 85, 85);">gggffyfy</b></h2><div><b style="background-color: rgb(216, 85, 85);">fsdfsdf</b></div>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1027, 17, N'English literature', N'All my sons module f notebook', N'green.png', N'online', N'', CAST(N'2023-01-15' AS Date), CAST(N'2023-05-02' AS Date), N'public', 13, 14, N'<h2 style="text-align: left;"><b style="background-color: rgb(255, 56, 56);">Welcome to my english notebook</b></h2><div><b style="background-color: rgb(255, 56, 56);"><br></b></div><div><b style="background-color: rgb(255, 56, 56);"><br></b></div><div><b style="background-color: rgb(255, 56, 56);"><br></b></div><div><h2 style="font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; color: rgb(51, 51, 51); text-align: left;"><span style="font-weight: 700; background-color: rgb(255, 56, 56);">Welcome to my english notebook</span></h2></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><h2 style="font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; color: rgb(51, 51, 51); text-align: left;"><span style="font-weight: 700; background-color: rgb(255, 56, 56);">Welcome to my english notebook</span></h2></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><h2 style="font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; color: rgb(51, 51, 51); text-align: left;"><span style="font-weight: 700; background-color: rgb(255, 56, 56);">Welcome to my english notebook</span></h2></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><span style="font-weight: 700; background-color: rgb(255, 56, 56);"><br></span></div><div><h2 style="font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; color: rgb(51, 51, 51); text-align: left;"><span style="font-weight: 700; background-color: rgb(255, 56, 56);">Welcome to my english notebook</span></h2></div>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1028, 17, N'History class Atidim', N'This is my new history notebook.', N'red.png', N'online', N'', CAST(N'2023-01-15' AS Date), CAST(N'2023-05-02' AS Date), N'public', 11, 6, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1029, 22, N'English literature', N'fdsfsfsfdsd', N'purple.png', N'online', N'', CAST(N'2023-01-16' AS Date), CAST(N'2023-01-16' AS Date), N'public', NULL, 1, N'<h2><b><font color="#c75252">Hello tihs is m f</font></b></h2>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1039, 16, N'English class', N'thi', N'purple.png', N'online', N'', CAST(N'2023-04-14' AS Date), CAST(N'2023-04-14' AS Date), N'public', NULL, 3, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1040, 29, N'English class 2', N'This is my English notebook for university.', N'purple.png', N'online', N'', CAST(N'2023-04-27' AS Date), CAST(N'2023-04-27' AS Date), N'public', NULL, 3, N'<span style="background-color: rgb(215, 35, 35);"><font color="#fff0f0" size="5"><b style="">English class</b></font></span><div style="text-align: left;">this is my notebok</div>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1041, 29, N'History class', N'History notebook, by itaybroder', N'green.png', N'document', N'notebookfiles/notebook-1041.pdf', CAST(N'2023-04-27' AS Date), CAST(N'2023-04-27' AS Date), N'public', NULL, 6, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1042, 17, N'בגרות מעבדה פיזיקה', N'', N'purple.png', N'online', N'', CAST(N'2023-05-01' AS Date), CAST(N'2023-05-01' AS Date), N'public', 12, 5, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1043, 30, N'שירותי רשת', N'מחברת מגניבה של שירותי רשת', N'green.png', N'online', N'', CAST(N'2023-05-02' AS Date), CAST(N'2023-05-02' AS Date), N'public', 12, 4, N'<div style="text-align: left;"><font size="6" color="#f8e7e7" style="background-color: rgb(223, 78, 78);">Wow,&nbsp;</font></div><div style="text-align: left;"><b><font size="6" color="#f8e7e7" style="background-color: rgb(223, 78, 78);">cool notebook</font></b></div><div style="text-align: left;"><u><font size="6" color="#f8e7e7" style="background-color: rgb(223, 78, 78);">bdfgdg esdgd sgdfgdsfg</font></u></div><div style="text-align: left;"><font size="6" color="#f8e7e7" style="background-color: rgb(223, 78, 78);"><br></font></div><div style="text-align: left;"><font size="6" color="#f8e7e7" style="background-color: rgb(223, 78, 78);">fsdf&nbsp;</font></div><div style="text-align: left;"><font color="#f8e7e7" size="6"><span style="background-color: rgb(223, 78, 78);">Admin was here!</span></font></div>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1045, 31, N'מחברת בכימיה', N'מחברת מגניבה בכימיה', N'blue.png', N'online', N'notebookfiles/notebook-1045.pdf', CAST(N'2023-05-02' AS Date), CAST(N'2023-05-02' AS Date), N'public', 12, 15, N'<font face="Times New Roman" size="6" style="background-color: rgb(89, 232, 204);">Hellloooo everyone, this is my new notebook. I love you all.</font><div><font face="Times New Roman" size="6" style="background-color: rgb(89, 232, 204);">jhon, pork.</font></div>')
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1046, 31, N'Biology class, Atidim', N'This is my biology class', N'red.png', N'online', N'', CAST(N'2023-05-02' AS Date), CAST(N'2023-05-02' AS Date), N'public', 11, 13, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1047, 31, N'Art class Ramon', N'מחברת באומנות', N'purple.png', N'online', N'', CAST(N'2023-05-02' AS Date), CAST(N'2023-05-02' AS Date), N'private', 12, 11, NULL)
INSERT [dbo].[NotebookTBL] ([NotebookID], [UserID], [Title], [Description], [Color], [Format], [Path], [CreatedDate], [UpdateDate], [Accessibility], [SchoolId], [SubjectID], [OnlineNotebookFormat]) VALUES (1048, 27, N'מתמטיקה יב2 רמון', N'cool math notebook', N'red.png', N'online', N'', CAST(N'2023-05-02' AS Date), CAST(N'2023-05-02' AS Date), N'public', 12, 1, N'<font face="Courier New" size="7" style="background-color: rgb(194, 102, 255);">Cool math notebook I love math</font>')
SET IDENTITY_INSERT [dbo].[NotebookTBL] OFF
GO
SET IDENTITY_INSERT [dbo].[SchoolTBL] ON 

INSERT [dbo].[SchoolTBL] ([SchoolID], [Name], [Country], [Address]) VALUES (11, N'Atidim', N'Israel', N'Hod Hasharon')
INSERT [dbo].[SchoolTBL] ([SchoolID], [Name], [Country], [Address]) VALUES (12, N'Ramon', N'Israel', N'Hod Hasharon')
INSERT [dbo].[SchoolTBL] ([SchoolID], [Name], [Country], [Address]) VALUES (13, N'Hadarim', N'Israel', N'Hod Hasharon')
SET IDENTITY_INSERT [dbo].[SchoolTBL] OFF
GO
SET IDENTITY_INSERT [dbo].[SubjectTBL] ON 

INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (1, N'Math')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (3, N'English')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (4, N'Computer Science')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (5, N'Physics')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (6, N'History')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (8, N'None')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (11, N'Art')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (13, N'Biology')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (14, N'Literature')
INSERT [dbo].[SubjectTBL] ([SubjectID], [Name]) VALUES (15, N'Chemistry')
SET IDENTITY_INSERT [dbo].[SubjectTBL] OFF
GO
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (17, 11)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (17, 12)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (17, 13)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (22, 11)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (22, 12)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (22, 13)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (27, 12)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (30, 11)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (30, 12)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (30, 13)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (31, 11)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (31, 12)
INSERT [dbo].[UserInSchoolTBL] ([UserID], [SchoolID]) VALUES (31, 13)
GO
SET IDENTITY_INSERT [dbo].[UserTBL] ON 

INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (16, N'Admin', N'Admin', N'Admin', N'admin', CAST(N'2022-12-28' AS Date), N'Ugav3, Hod Hasharon', N'Admin')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (17, N'Itay', N'Broder', N'Itay0170', N'user', CAST(N'2023-05-12' AS Date), N'Ugav 3, Hod Hasharon', N'itaybroder10')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (22, N'Smadar', N'Vechter', N'Itay0170', N'user', CAST(N'2002-07-02' AS Date), N'ugav 3', N'smadar123')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (24, N'User', N'User', N'Itay0170', N'admin', CAST(N'2023-02-01' AS Date), N'ugav 3', N'user')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (25, N'Dudi', N'Azulay', N'dod123', N'user', CAST(N'2023-02-01' AS Date), N'ha etsel 5', N'dudid')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (26, N'Daniel', N'Nitshe', N'dani1234', N'user', CAST(N'2023-02-01' AS Date), N'tel abib', N'danidan')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (27, N'Haim', N'nevve', N'Itay0170', N'user', CAST(N'2023-04-12' AS Date), N'Yafo', N'Haim80')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (29, N'Itay', N'Broder', N'Itay0170', N'user', CAST(N'2005-07-09' AS Date), N'Ugav 3, Hod Hasharon', N'itaybb')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (30, N'Yair', N'Papa', N'Itay0170', N'user', CAST(N'2004-06-08' AS Date), N'magdiel, Hod Hasaron', N'Yair10')
INSERT [dbo].[UserTBL] ([UserID], [FIrstName], [LastName], [Password], [Permission], [Birthday], [Address], [Username]) VALUES (31, N'Jhon', N'Pork', N'Itay0170', N'user', CAST(N'2007-06-27' AS Date), N'Ramatim, Hod Hasaron', N'Jhonpork')
SET IDENTITY_INSERT [dbo].[UserTBL] OFF
GO
ALTER TABLE [dbo].[CommentTBL]  WITH CHECK ADD  CONSTRAINT [FK_CommentTBL_NotebookTBL] FOREIGN KEY([NotebookID])
REFERENCES [dbo].[NotebookTBL] ([NotebookID])
GO
ALTER TABLE [dbo].[CommentTBL] CHECK CONSTRAINT [FK_CommentTBL_NotebookTBL]
GO
ALTER TABLE [dbo].[CommentTBL]  WITH CHECK ADD  CONSTRAINT [FK_CommentTBL_UserTBL] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTBL] ([UserID])
GO
ALTER TABLE [dbo].[CommentTBL] CHECK CONSTRAINT [FK_CommentTBL_UserTBL]
GO
ALTER TABLE [dbo].[LikeTBL]  WITH CHECK ADD  CONSTRAINT [FK_LikeTBL_NotebookTBL] FOREIGN KEY([NotebookID])
REFERENCES [dbo].[NotebookTBL] ([NotebookID])
GO
ALTER TABLE [dbo].[LikeTBL] CHECK CONSTRAINT [FK_LikeTBL_NotebookTBL]
GO
ALTER TABLE [dbo].[LikeTBL]  WITH CHECK ADD  CONSTRAINT [FK_LikeTBL_UserTBL] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTBL] ([UserID])
GO
ALTER TABLE [dbo].[LikeTBL] CHECK CONSTRAINT [FK_LikeTBL_UserTBL]
GO
ALTER TABLE [dbo].[NotebookTBL]  WITH CHECK ADD  CONSTRAINT [FK_NotebookTBL_SchoolTBL] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[SchoolTBL] ([SchoolID])
GO
ALTER TABLE [dbo].[NotebookTBL] CHECK CONSTRAINT [FK_NotebookTBL_SchoolTBL]
GO
ALTER TABLE [dbo].[NotebookTBL]  WITH CHECK ADD  CONSTRAINT [FK_NotebookTBL_SubjectTBL] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[SubjectTBL] ([SubjectID])
GO
ALTER TABLE [dbo].[NotebookTBL] CHECK CONSTRAINT [FK_NotebookTBL_SubjectTBL]
GO
ALTER TABLE [dbo].[NotebookTBL]  WITH CHECK ADD  CONSTRAINT [FK_NotebookTBL_UserTBL] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTBL] ([UserID])
GO
ALTER TABLE [dbo].[NotebookTBL] CHECK CONSTRAINT [FK_NotebookTBL_UserTBL]
GO
ALTER TABLE [dbo].[UserInSchoolTBL]  WITH CHECK ADD  CONSTRAINT [FK_UserInSchoolTBL_SchoolTBL] FOREIGN KEY([SchoolID])
REFERENCES [dbo].[SchoolTBL] ([SchoolID])
GO
ALTER TABLE [dbo].[UserInSchoolTBL] CHECK CONSTRAINT [FK_UserInSchoolTBL_SchoolTBL]
GO
ALTER TABLE [dbo].[UserInSchoolTBL]  WITH CHECK ADD  CONSTRAINT [FK_UserInSchoolTBL_UserTBL] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTBL] ([UserID])
GO
ALTER TABLE [dbo].[UserInSchoolTBL] CHECK CONSTRAINT [FK_UserInSchoolTBL_UserTBL]
GO
USE [master]
GO
ALTER DATABASE [NoteShare] SET  READ_WRITE 
GO
