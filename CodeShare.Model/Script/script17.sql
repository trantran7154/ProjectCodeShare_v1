USE [master]
GO
/****** Object:  Database [DataShareCode]    Script Date: 3/29/2021 11:50:14 PM ******/
CREATE DATABASE [DataShareCode]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataShareCode', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DataShareCode.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DataShareCode_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DataShareCode_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DataShareCode] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataShareCode].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataShareCode] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataShareCode] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataShareCode] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataShareCode] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataShareCode] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataShareCode] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataShareCode] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataShareCode] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataShareCode] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataShareCode] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataShareCode] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataShareCode] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataShareCode] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataShareCode] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataShareCode] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DataShareCode] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataShareCode] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataShareCode] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataShareCode] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataShareCode] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataShareCode] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataShareCode] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataShareCode] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DataShareCode] SET  MULTI_USER 
GO
ALTER DATABASE [DataShareCode] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataShareCode] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataShareCode] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataShareCode] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DataShareCode] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DataShareCode] SET QUERY_STORE = OFF
GO
USE [DataShareCode]
GO
/****** Object:  Table [dbo].[Banners]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banners](
	[banner_id] [int] IDENTITY(1,1) NOT NULL,
	[banner_title] [nvarchar](255) NULL,
	[banner_image] [nvarchar](max) NULL,
	[banner_link] [nvarchar](max) NULL,
	[banner_datecreate] [datetime] NULL,
	[banner_active] [bit] NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[banner_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[bill_id] [int] IDENTITY(1,1) NOT NULL,
	[bill_datecreate] [datetime] NULL,
	[pakege_id] [int] NULL,
	[user_id] [int] NULL,
	[bill_active] [bit] NULL,
	[bill_dealine] [datetime] NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[bill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](max) NULL,
	[category_active] [bit] NULL,
	[category_item] [int] NULL,
	[category_img] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categorys] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chats]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chats](
	[chat_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[chat_content] [nvarchar](max) NULL,
	[chat_datecreate] [datetime] NULL,
	[id_send] [int] NULL,
	[chat_key] [nvarchar](max) NULL,
 CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED 
(
	[chat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Codes]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Codes](
	[code_id] [int] IDENTITY(1,1) NOT NULL,
	[code_title] [nvarchar](400) NULL,
	[code_coin] [int] NULL,
	[code_code] [nvarchar](100) NULL,
	[code_des] [nvarchar](2000) NULL,
	[code_info] [nvarchar](max) NULL,
	[code_setting] [nvarchar](max) NULL,
	[code_view] [int] NULL,
	[code_viewdown] [int] NULL,
	[code_linkdemo] [nvarchar](max) NULL,
	[code_linkdown] [nvarchar](max) NULL,
	[code_datecreate] [datetime] NULL,
	[code_dateupdate] [datetime] NULL,
	[code_active] [int] NULL,
	[code_option] [bit] NULL,
	[code_del] [bit] NULL,
	[code_tag] [nvarchar](max) NULL,
	[code_disk] [int] NULL,
	[code_pass] [nvarchar](max) NULL,
	[category_id] [int] NULL,
	[user_id] [int] NULL,
	[code_img] [nvarchar](max) NULL,
 CONSTRAINT [PK_Codes] PRIMARY KEY CLUSTERED 
(
	[code_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[code_id] [int] NULL,
	[comment_content] [nvarchar](max) NULL,
	[comment_datecreate] [datetime] NULL,
	[news_id] [int] NULL,
	[comment_dateupdate] [datetime] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[group_id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NULL,
	[user_id] [int] NULL,
	[code_id] [int] NULL,
	[language_id] [int] NULL,
	[group_item] [int] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[language_id] [int] IDENTITY(1,1) NOT NULL,
	[language_name] [nvarchar](300) NULL,
	[language_active] [int] NULL,
	[language_img] [nvarchar](max) NULL,
	[language_view] [int] NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[language_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[news_id] [int] IDENTITY(1,1) NOT NULL,
	[news_name] [nvarchar](300) NULL,
	[news_view] [int] NULL,
	[news_content] [nvarchar](max) NULL,
	[news_tag] [nvarchar](max) NULL,
	[user_id] [int] NULL,
	[news_datecreate] [datetime] NULL,
	[news_dateupdate] [datetime] NULL,
	[news_active] [int] NULL,
	[news_option] [bit] NULL,
	[news_del] [bit] NULL,
	[news_img] [nvarchar](max) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[news_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[oder_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[id_coder] [int] NULL,
	[oder_datecreate] [datetime] NULL,
	[code_id] [int] NULL,
 CONSTRAINT [PK_Oders] PRIMARY KEY CLUSTERED 
(
	[oder_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pakages]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pakages](
	[pakege_id] [int] IDENTITY(1,1) NOT NULL,
	[pakage_coin] [int] NULL,
	[pakage_money] [nvarchar](max) NULL,
	[pakage_active] [int] NULL,
 CONSTRAINT [PK_Pakeges] PRIMARY KEY CLUSTERED 
(
	[pakege_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rep]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rep](
	[rep_id] [int] IDENTITY(1,1) NOT NULL,
	[comment_id] [int] NULL,
	[user_id] [int] NULL,
	[rep_content] [nvarchar](max) NULL,
	[rep_datecreate] [datetime] NULL,
	[rep_dateupdate] [datetime] NULL,
 CONSTRAINT [PK_Rep] PRIMARY KEY CLUSTERED 
(
	[rep_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TakePrices]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TakePrices](
	[tp_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[tp_coin] [int] NULL,
	[tp_datecreate] [datetime] NULL,
	[tp_note] [nvarchar](max) NULL,
	[tp_active] [int] NULL,
	[tp_accountnumber] [varchar](50) NULL,
	[tp_customer] [nvarchar](225) NULL,
	[tp_momo] [varchar](15) NULL,
 CONSTRAINT [PK_TakePrices] PRIMARY KEY CLUSTERED 
(
	[tp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tools]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tools](
	[tool_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[code_id] [int] NULL,
	[news_id] [int] NULL,
	[tool_datecreate] [datetime] NULL,
	[tool_item] [bit] NULL,
 CONSTRAINT [PK_Tools] PRIMARY KEY CLUSTERED 
(
	[tool_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_email] [varchar](300) NULL,
	[user_phone] [varchar](14) NULL,
	[user_sex] [bit] NULL,
	[user_birth] [datetime] NULL,
	[user_token] [nvarchar](max) NULL,
	[user_role] [int] NULL,
	[user_name] [nvarchar](400) NULL,
	[user_coin] [int] NULL,
	[user_datecreate] [datetime] NULL,
	[user_dateupdate] [datetime] NULL,
	[user_code] [nvarchar](100) NULL,
	[user_active] [int] NULL,
	[user_option] [bit] NULL,
	[user_del] [bit] NULL,
	[user_fa] [nvarchar](max) NULL,
	[user_none] [nvarchar](max) NULL,
	[user_view] [int] NULL,
	[user_facode] [nvarchar](max) NULL,
	[user_pass] [nvarchar](max) NULL,
	[user_img] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Banners] ON 

INSERT [dbo].[Banners] ([banner_id], [banner_title], [banner_image], [banner_link], [banner_datecreate], [banner_active]) VALUES (1, N'TÌM VÀ CHIA SẺ SOURCE CODE NHANH NHẤT', N'8b35fef55fba1a201c9c7a11d3ec3d64.gif', NULL, CAST(N'2021-03-27T10:00:00.000' AS DateTime), 1)
INSERT [dbo].[Banners] ([banner_id], [banner_title], [banner_image], [banner_link], [banner_datecreate], [banner_active]) VALUES (2, N'BẢO MẬT TỐT SOURCE CODE CÁ NHÂN', N'comp-1_1.gif', NULL, CAST(N'2021-03-27T10:00:00.000' AS DateTime), 1)
INSERT [dbo].[Banners] ([banner_id], [banner_title], [banner_image], [banner_link], [banner_datecreate], [banner_active]) VALUES (3, N'GIAO DỊCH BUÔN BÁN SẢN PHẨM AN TOÀN', N'shot.gif', NULL, CAST(N'2021-03-27T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Banners] OFF
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (1, CAST(N'2021-03-25T19:15:11.553' AS DateTime), 1, 1, 0, CAST(N'2021-03-25T19:15:11.553' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (2, CAST(N'2021-03-25T19:30:18.120' AS DateTime), 3, 1, 0, CAST(N'2021-04-04T19:30:18.120' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (3, CAST(N'2021-03-25T19:32:26.810' AS DateTime), 1, 1, 1, CAST(N'2021-03-25T19:32:26.810' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (4, CAST(N'2021-03-26T21:43:35.273' AS DateTime), 4, 3, 1, CAST(N'2021-03-26T21:43:35.273' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (5, CAST(N'2021-03-29T14:41:48.830' AS DateTime), 7, 6, 1, CAST(N'2021-03-29T14:41:48.830' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (6, CAST(N'2021-03-29T14:42:20.257' AS DateTime), 3, 6, 1, CAST(N'2021-03-29T14:42:20.257' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (7, CAST(N'2021-03-29T14:43:00.350' AS DateTime), 3, 6, 1, CAST(N'2021-03-29T14:43:00.350' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (8, CAST(N'2021-03-29T14:43:30.873' AS DateTime), 7, 6, 1, CAST(N'2021-03-29T14:43:30.873' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img]) VALUES (1, N'Game', 1, 1, NULL)
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img]) VALUES (2, N'Website', 1, 1, NULL)
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img]) VALUES (3, N'Ứng dụng', 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Categorys] OFF
GO
SET IDENTITY_INSERT [dbo].[Chats] ON 

INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (57, 3, N'aaa', CAST(N'2021-03-26T22:47:53.367' AS DateTime), 1, N'1key3huynvuon')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (58, 1, N'bb', CAST(N'2021-03-26T22:49:33.900' AS DateTime), 3, N'3key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (59, 3, N'chào cu', CAST(N'2021-03-26T22:55:17.593' AS DateTime), 1, N'1key3huynvuon')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (60, 1, N'chào gì', CAST(N'2021-03-26T22:55:22.897' AS DateTime), 3, N'3key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (61, 3, N'bạn tên gì', CAST(N'2021-03-26T22:56:34.003' AS DateTime), 1, N'1key3huynvuon')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (62, 1, N'ko biết', CAST(N'2021-03-26T22:56:37.713' AS DateTime), 3, N'3key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (63, 3, N'ok cút', CAST(N'2021-03-26T22:56:41.337' AS DateTime), 1, N'1key3huynvuon')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (64, 1, N'md', CAST(N'2021-03-26T22:56:47.480' AS DateTime), 3, N'3key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (65, 1, N'kk', CAST(N'2021-03-26T22:56:49.787' AS DateTime), 3, N'3key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (66, 1, N'haiz', CAST(N'2021-03-26T22:56:58.173' AS DateTime), 3, N'3key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (67, 3, N'??', CAST(N'2021-03-26T22:57:03.290' AS DateTime), 1, N'1key3huynvuon')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (68, 3, N'@@', CAST(N'2021-03-26T22:57:07.047' AS DateTime), 1, N'1key3huynvuon')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (69, 6, N'2', CAST(N'2021-03-29T15:02:38.560' AS DateTime), 1, N'1key6huynvuon')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (70, 1, N'cc', CAST(N'2021-03-29T15:03:25.500' AS DateTime), 6, N'6key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (71, 6, N'hey''', CAST(N'2021-03-29T15:03:30.247' AS DateTime), 1, N'1key6huynvuon')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (72, 1, N'cc', CAST(N'2021-03-29T15:03:33.347' AS DateTime), 6, N'6key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (73, 1, N'hey''', CAST(N'2021-03-29T15:03:47.960' AS DateTime), 6, N'6key1vuonhuyn')
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate], [id_send], [chat_key]) VALUES (74, 6, N'heycc''', CAST(N'2021-03-29T15:03:51.277' AS DateTime), 1, N'1key6huynvuon')
SET IDENTITY_INSERT [dbo].[Chats] OFF
GO
SET IDENTITY_INSERT [dbo].[Codes] ON 

INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (12, N'[[flutter] - Share code UI Facebook', 50, N'CODE-45501106', N'<p>Bộ ui hoàn thiện giống hoàn toàn như app facebook đang sử dụng, các bạn chỉ cần tải về mở ra và chạy thử. Còn làm gì với nó để thành app của bạn là tùy thuộc vào bạn.</p><p>Xin cảm ơn</p>', N'Giao diện giống như facebook được làm bằng flutter, tương thích IOS, Android và cả web', N'<p>Sử dụng android hoặc bất kỳ công cụ nào bạn dùng để code flutter để mở ra nhé</p>', 2, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:04:31.157' AS DateTime), CAST(N'2021-03-29T13:04:31.157' AS DateTime), 1, 1, 0, N'Android;', 1, N'123', 3, 5, N'7dae2a77-85ca-44be-92e0-dff3ab85f39a.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (13, N'Phần mềm quản lý điểm danh và lịch phân công giảng dạy', 100, N'CODE-1031405846', N'<p>Bài toán đặt ra: Bạn quản lý phân công lịch dạy và điểm danh học sinh Phần mềm giúp bạn nhanh chóng xem được lịch dạy của giáo viên Danh sách điểm danh chi tiết Danh sách học sinh cần làm báo cáo.</p><p>Sử dụng code thuần PHP</p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222817.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222818.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222819.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222820.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222821.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure>', N'Bài toán đặt ra: Bạn quản lý phân công lịch dạy và điểm danh học sinh Phần mềm giúp bạn nhanh chóng xem được lịch dạy của giáo viên Danh sách điểm danh chi tiết Danh sách học sinh cần làm báo cáo', NULL, 0, 0, N'https://semantic-ui.com/', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:07:01.293' AS DateTime), CAST(N'2021-03-29T13:07:01.293' AS DateTime), 1, 1, 0, N'Dữ Liệu;', 1, N'123', 3, 5, N'4adf6c87-582a-4906-b34a-c8ed0cf1dd3c.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (14, N'Full code Website wordpress kinh doanh nhà hàng Oishii phong cách Nhật Bản chuẩn SEO giá rẻ ', 80, N'CODE-923477049', N'<p>Full code Website wordpress kinh doanh nhà hàng Oishii phong cách Nhật Bản chuẩn SEO giá rẻ, sử dụng theme flatsome</p><p>Giải nén và import database từ file trong thư mục Database</p><p>Tài khoản: admin/admin</p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112527.jpg" alt="website kinh doanh nhà hàng,website nhà hàng Nhật Bản,website wordpress,website kinh doanh oishii"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112528.jpg" alt="website kinh doanh nhà hàng,website nhà hàng Nhật Bản,website wordpress,website kinh doanh oishii"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112529.jpg" alt="website kinh doanh nhà hàng,website nhà hàng Nhật Bản,website wordpress,website kinh doanh oishii"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112530.jpg" alt="website kinh doanh nhà hàng,website nhà hàng Nhật Bản,website wordpress,website kinh doanh oishii"></figure><p><br>&nbsp;</p>', N'Full code Website wordpress kinh doanh nhà hàng Oishii phong cách Nhật Bản chuẩn SEO giá rẻ, sử dụng theme flatsome', NULL, 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:10:44.697' AS DateTime), CAST(N'2021-03-29T13:10:44.697' AS DateTime), 1, 1, 0, N'Website WordPress;', 1, NULL, 2, 5, N'41c6aeaa-625b-4f4b-91a8-0ac5e628e865.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (15, N'Source Website mua bán đăng tin bất động sản', 120, N'CODE-993455253', N'<p>Websile mua bán đăng tin bất động sản đẹp đầy đủ chức năng quản lý menu và bài viết dễ dàng</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/website-mua-ban-dang-tin-bat-dong-san-23744.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/source-website-mua-ban-dang-tin-bat-dong-san-105657.jpg" alt="web bất động sản,website bất động sản,bất động sản"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/source-website-mua-ban-dang-tin-bat-dong-san-105836.jpg" alt="web bất động sản,website bất động sản,bất động sản"></figure>', N'Websile mua bán đăng tin bất động sản đẹp đầy đủ chức năng quản lý menu và bài viết dễ dàng', N'<p>các bạn up file lên host và sửa database trong file config mình đã có hình ảnh ở trên<br>Link Quản trị Web:&nbsp;<br>https://www.domain.com/administrator<br><br>ID: admin<br>Pass: 123456</p>', 1, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:13:08.193' AS DateTime), CAST(N'2021-03-29T13:13:08.193' AS DateTime), 1, 1, 0, N'Website;', 1, N'123', 2, 5, N'1bf7245a-7a4f-4e8a-bf25-96b836c7d388.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (16, N'Source code website bán sách online', 50, N'CODE-603249008', N'<p>Các chức năng của website:</p><p>* Chức năng cho người dùng</p><p>&nbsp; &nbsp; &nbsp;- Xem thông tin sách</p><p>&nbsp; &nbsp; &nbsp;- Thêm sách vào giỏ hàng</p><p>&nbsp; &nbsp; &nbsp;- Thực hiện tìm kiếm sách</p><p>* Chức năng cho admin</p><p>&nbsp; &nbsp; &nbsp;- Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ</p><p>&nbsp;</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/source-code-website-ban-sach-online-81146.jpg" alt="web bán sách,Source website,Website bán sách online,code website bán sách online"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/source-code-website-ban-sach-online-81147.jpg" alt="web bán sách,Source website,Website bán sách online,code website bán sách online"></figure>', N'Website bán sách online sử dụng ngôn ngữ java/jsp có các chức năng cơ bản của một trang web bán sách.', N'<p>* Yêu cầu máy đã cài đặt Netbeans và SQL&nbsp; Server</p><p>1. Chạy database trong thư mục database</p><p>2. Mở Netbeans và chạy project</p><p>&nbsp;</p>', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:25:06.463' AS DateTime), CAST(N'2021-03-29T13:25:06.463' AS DateTime), 1, 1, 0, N'Web;', 1, N'123', 2, 5, N'080c7afa-e052-4391-babb-5600cd96cadb.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (17, N'Đăng ký và Tra cứu thông tin sinh viên', 50, N'CODE-525425447', N'<p>Phần mềm giúp đăng ký thông tin sinh viên và tra cứu thông tin chi tiết khi cần thiết với đầy đủ tính năng.</p><p>Ưu điểm :</p><p>+ Giao diện đẹp</p><p>+ Đăng ký thông tin toàn diện (Thêm ảnh, điền thông tin, ...)</p><p>+ Đã tạo các ràng buộc cơ bản đầy đủ</p><p>+ Code đơn giản dễ hiểu, có thể tự mở rộng tính năng hoặc chỉnh sửa cấu trúc</p><p>Nhược điểm :</p><p>- Nền phần mềm được thiết kế sẵn, nên muốn đổi thì cần có hinh nền khác</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/dang-ky-va-tra-cuu-thong-tin-sinh-vien-26293.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/dang-ky-va-tra-cuu-thong-tin-sinh-vien-135314.jpg" alt="tra cứu thông tin,quản lý thông tin sinh viên,thông tin điểm sinh viên,đăng ký thông tin sinh viên,sinh viên,đăng ký"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/dang-ky-va-tra-cuu-thong-tin-sinh-vien-135315.jpg" alt="tra cứu thông tin,quản lý thông tin sinh viên,thông tin điểm sinh viên,đăng ký thông tin sinh viên,sinh viên,đăng ký"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/dang-ky-va-tra-cuu-thong-tin-sinh-vien-135316.jpg" alt="tra cứu thông tin,quản lý thông tin sinh viên,thông tin điểm sinh viên,đăng ký thông tin sinh viên,sinh viên,đăng ký"></figure>', N'Phần mêm giúp đăng ký và tra cứu thông tin chi tiết của sinh viên. Giúp người dùng quản lý thông tin của sinh viên một cách dễ dàng.', N'<p>Lưu ý :</p><p>1. Cần có phầm mêm SQL Sever (Khuyên dùng phiên bản 2017 trở lên)</p><p>2. Cần có phần mềm Visual Studion (Khuyên dùng phiên bản 2017 trở lên và có cài đặt gói ngôn ngữ VB)</p><p>3. Phần mềm đã được tinh chỉnh cấu hình kết nối để chạy được mọi máy đã tạo CSDL (thông qua file .sql) nên không cần chỉnh chuỗi kết nối</p><p>Các bước cài đặt :</p><p>1. Sử dụng file .sql kèm theo để tạo cơ sở dữ liệu cũng như để thêm các mẫu dữ liệu căn bản</p><p>2. Mở project bằng phần mềm Visual Studio và chọn Start/Build</p><p>3. Enjoy</p>', 31, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:27:18.907' AS DateTime), CAST(N'2021-03-29T13:27:18.907' AS DateTime), 1, 1, 0, N'Ứng dụng;', NULL, N'123', 3, 5, N'eeda18fa-8dc4-4235-abc0-a08670a7193a.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (18, N'Đồ án quản lí nhập xuất kho Winform(MVC), entity framework, SQl server', 80, N'CODE-792376133', N'<figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/do-an-quan-li-nhap-xuat-kho-winformmvc-entity-framework-sql-server-code-phan-mem-quan-ly-code-phan-mem-quan-ly-code-phan-mem-quan-ly-94021.jpg" alt="Code quản lý,nhập xuất,nhập xuất kho Winform,Code phần mềm quản lý"></figure>', N'Full code App quản lí xuất nhập kho, winform theo mô hình MVC, sử dụng enity framework', N'<p>có hướng dẫn chi tiết trong file tải</p><p>&nbsp;</p>', 1, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:47:40.967' AS DateTime), CAST(N'2021-03-29T13:47:40.967' AS DateTime), 1, 1, 0, N'C#;', NULL, N'123', 3, 5, N'fd682de8-d206-4db7-9c30-dcd410873efe.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (19, N'Full Teamplate HTML + CSS + Bootstrap 4 - Giao Diện Bán Điện Thoại Hiệu Ứng UI/UX Cực Đỉnh + Đầy Đủ Các Trang + Demo', 80, N'CODE-561269831', N'<p>Teamplate có giao diện cực đẹp và UI cực chất cho mọi người thỏa sức phát triển và sáng tạo. Mời mọi người xem demo để có trải nghiệm tốt nhất.&nbsp;</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/full-teamplate-html-css-bootstrap-4-giao-dien-ban-dien-thoai-hieu-ung-uiux-cuc-dinh-day-du-cac-trang-demo-27695.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-teamplate-html-css-bootstrap-4---giao-dien-ban-dien-thoai-15028.jpg" alt="Template Giao Diện,Bootstrap 4 Admin,Giao diện website bán sách,Giao diện bán điện thoại,Giao diện Bootstrap,Điện thoại"></figure>', N'Đây là teamplate bán điện thoại Hiệu Ứng UI/UX Cực Đỉnh + Đầy Đủ Các Trang + Demo mình sưu tầm được, muốn chia sẻ cho mọi người cùng sử dụng, mời mọi người tham khảo.', N'<p>Tải về, giải nén và tận hưởng thôi</p>', 2, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:53:05.787' AS DateTime), CAST(N'2021-03-29T13:53:05.787' AS DateTime), 1, 1, 0, N'Web;', NULL, N'123', 2, 5, N'2d3b0f12-ac0c-4ff8-89d5-56bf6208af4b.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (20, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 676, N'CODE-200478690', N'<p>hfxfhdxfgmbk,</p>', N'ugtfvg', N'<p>hgc gvvhb&nbsp;</p>', 53, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T14:32:25.420' AS DateTime), CAST(N'2021-03-29T14:32:25.420' AS DateTime), 1, 1, 0, N'fdcgfcfv'';', 10, N'vcf ', 2, 6, N'1bbb2aa2-0b94-467c-bc0f-575e0f605f34.png')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (21, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 0, N'CODE-788815677', N'<p>code</p>', N'code', N'<p>code</p>', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T20:49:00.850' AS DateTime), CAST(N'2021-03-29T20:49:00.850' AS DateTime), 2, 1, 0, N'game C#;', 10, N'123', 1, 6, N'41490282-5a93-44e6-9234-4a095771a4d8.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (22, N'Soure code Quản lý mua bán linh kiện máy tính', 111, N'CODE-15168693', N'<p>code</p>', N'code', N'<p>code</p>', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T21:11:25.320' AS DateTime), CAST(N'2021-03-29T21:11:25.320' AS DateTime), 2, 1, 0, N'web;', 10, N'123', 2, 6, N'197a7f1a-21a5-4a0f-918a-8ce5af9b4b63.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (23, N'Source Code Phần mềm quản lí khách sạn', 12, N'CODE-961474107', N'<p>code</p>', N'code', N'<p>code</p>', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T21:15:22.303' AS DateTime), CAST(N'2021-03-29T21:15:22.303' AS DateTime), 2, 1, 0, N'we;', 12, N'12', 3, 1, N'55d4484a-e439-446f-a0d7-58f9fbf1bcfa.jpg')
SET IDENTITY_INSERT [dbo].[Codes] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (9, NULL, NULL, 12, 2, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (10, NULL, NULL, 12, 3, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (11, NULL, NULL, 13, 4, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (12, NULL, NULL, 13, 7, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (13, NULL, NULL, 13, 10, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (14, NULL, NULL, 14, 5, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (15, NULL, NULL, 15, 6, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (16, NULL, NULL, 15, 13, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (17, NULL, NULL, 16, 7, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (18, NULL, NULL, 16, 8, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (19, NULL, NULL, 16, 9, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (20, NULL, NULL, 17, 7, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (21, NULL, NULL, 17, 10, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (22, NULL, NULL, 17, 12, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (23, NULL, NULL, 18, 7, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (24, NULL, NULL, 18, 10, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (25, NULL, NULL, 19, 13, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (26, NULL, NULL, 20, 2, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (27, NULL, NULL, 20, 3, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (28, NULL, NULL, 20, 4, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (29, NULL, NULL, 20, 5, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (30, NULL, NULL, 21, 1, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (31, NULL, NULL, 21, 2, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (32, NULL, NULL, 21, 3, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (33, NULL, NULL, 21, 11, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (34, NULL, NULL, 14, 11, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (37, NULL, NULL, 22, 5, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (38, NULL, NULL, 22, 6, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (39, NULL, NULL, 23, 7, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (40, NULL, NULL, 23, 8, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (41, NULL, NULL, 23, 10, 1)
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (1, N'Android', 1, N'android.jpg', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (2, N'IOS', 1, N'ios.jpg', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (3, N'Window Phone', 1, N'wf.jpg', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (4, N'PHP & MySQL', 1, N'sql.jpg', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (5, N'Wordpress', 1, N'w.jpg', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (6, N'Joomla', 1, N'R249ac287e648fe4de1f443da6f6632fc.png', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (7, N'Visual C#', 1, N'csharp.jpg', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (8, N'Asp / Asp.net', 1, N'asp.net_.png', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (9, N'Java / JSP', 1, N'Comentarios-header.png', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (10, N'Visual Basic', 1, N'1200px-VB.NET_Logo.svg.png', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (11, N'Unity', 1, N'unnamed.jpg', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (12, N'C++', 1, N'0_ZpjhBs0gR5oSd3Il.png', 0)
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (13, N'HTML + Template', 1, N'html-la-gi-1280x720.jpg', 0)
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([oder_id], [user_id], [id_coder], [oder_datecreate], [code_id]) VALUES (12, 6, 5, CAST(N'2021-03-29T14:44:25.437' AS DateTime), 18)
INSERT [dbo].[Orders] ([oder_id], [user_id], [id_coder], [oder_datecreate], [code_id]) VALUES (13, 6, 5, CAST(N'2021-03-29T14:45:12.273' AS DateTime), 18)
INSERT [dbo].[Orders] ([oder_id], [user_id], [id_coder], [oder_datecreate], [code_id]) VALUES (15, 6, 5, CAST(N'2021-03-29T14:57:05.280' AS DateTime), 15)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Pakages] ON 

INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (1, 20, NULL, 1)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (2, 50, NULL, 1)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (3, 100, NULL, 1)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (4, 200, NULL, 1)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (5, 300, NULL, 1)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (6, 400, NULL, 1)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (7, 500, NULL, 1)
SET IDENTITY_INSERT [dbo].[Pakages] OFF
GO
SET IDENTITY_INSERT [dbo].[TakePrices] ON 

INSERT [dbo].[TakePrices] ([tp_id], [user_id], [tp_coin], [tp_datecreate], [tp_note], [tp_active], [tp_accountnumber], [tp_customer], [tp_momo]) VALUES (11, 3, 68, CAST(N'2021-03-29T22:40:45.227' AS DateTime), NULL, 2, NULL, NULL, N'0924404019')
INSERT [dbo].[TakePrices] ([tp_id], [user_id], [tp_coin], [tp_datecreate], [tp_note], [tp_active], [tp_accountnumber], [tp_customer], [tp_momo]) VALUES (12, 3, 68, CAST(N'2021-03-29T22:47:31.983' AS DateTime), NULL, 2, N'323232323232', N'asasafsaf', NULL)
SET IDENTITY_INSERT [dbo].[TakePrices] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (1, N'huynhminhtan4019@gmail.com', N'0924404019', 0, CAST(N'2021-03-25T16:29:11.193' AS DateTime), N'338aa56e-9786-4784-9902-64ca046432e6', 2, N'Tấn huỳnh', 327, CAST(N'2021-03-25T16:29:11.193' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'0924404019', N'c2e91d27-3660-40ad-8e8a-0e043b973399LDR6AWn.png')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (2, N'tran@gmail.com', NULL, 1, CAST(N'2021-03-25T16:29:11.193' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'123456', NULL)
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (3, N'vuongbaot1905@gmail.com', N'0924404019', 0, CAST(N'2021-03-25T16:29:11.193' AS DateTime), N'f9558345-42c1-43f7-9cdd-38c67986ec91', 2, N'aaaa', 68, CAST(N'2021-03-26T19:13:22.103' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, N'Tôi thích code webste', NULL, 0, NULL, N'0924404019', N'04f5d6d3-bca9-41e9-b892-427f528f61a2.jpg')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (4, NULL, NULL, NULL, NULL, N'f162cba9-8303-47d1-b40e-b0b7eaaebeb6', 2, NULL, 0, CAST(N'2021-03-29T11:52:01.557' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'123456', NULL)
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (5, N'trantran@gmail.com', NULL, NULL, NULL, N'87032592-0d90-44d8-bef3-5e45f34e4927', 2, N'Trân', 296, CAST(N'2021-03-29T11:53:00.933' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'123456', NULL)
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (6, N'vuongbaotran@gmail.com', NULL, NULL, NULL, N'a0e1db71-8a5f-46f6-a197-3bdf3821b0b4', 2, N'Trân', 890, CAST(N'2021-03-29T13:54:05.687' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'123456', N'6fda6015-d4b0-46ff-8c7f-99456c0e9ace[[flutter]---share-code-ui-facebook-152717.jpg')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (7, N'tranvuong@gmail.com', NULL, NULL, NULL, N'd2a25e84-65c3-4e97-b726-77751b432032', 2, N'Tran Vuong', 0, CAST(N'2021-03-29T14:00:46.530' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'123456', NULL)
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (8, N'th@gmail.com', NULL, NULL, NULL, N'c01ab575-79cb-4b07-b055-0af41780392a', 2, N'Tan Heo', 0, CAST(N'2021-03-29T14:23:17.610' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'123456', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Pakeges] FOREIGN KEY([pakege_id])
REFERENCES [dbo].[Pakages] ([pakege_id])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Pakeges]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Users]
GO
ALTER TABLE [dbo].[Codes]  WITH CHECK ADD  CONSTRAINT [FK_Codes_Categorys] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categorys] ([category_id])
GO
ALTER TABLE [dbo].[Codes] CHECK CONSTRAINT [FK_Codes_Categorys]
GO
ALTER TABLE [dbo].[Codes]  WITH CHECK ADD  CONSTRAINT [FK_Codes_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Codes] CHECK CONSTRAINT [FK_Codes_Users]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Codes] FOREIGN KEY([code_id])
REFERENCES [dbo].[Codes] ([code_id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Codes]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_News] FOREIGN KEY([news_id])
REFERENCES [dbo].[News] ([news_id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_News]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Users]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Categorys] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categorys] ([category_id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Categorys]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Codes] FOREIGN KEY([code_id])
REFERENCES [dbo].[Codes] ([code_id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Codes]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Languages] FOREIGN KEY([language_id])
REFERENCES [dbo].[Languages] ([language_id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Languages]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Users]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Users]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Oders_Codes] FOREIGN KEY([code_id])
REFERENCES [dbo].[Codes] ([code_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Oders_Codes]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Oders_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Oders_Users]
GO
ALTER TABLE [dbo].[Rep]  WITH CHECK ADD  CONSTRAINT [FK_Rep_Comment] FOREIGN KEY([comment_id])
REFERENCES [dbo].[Comment] ([comment_id])
GO
ALTER TABLE [dbo].[Rep] CHECK CONSTRAINT [FK_Rep_Comment]
GO
ALTER TABLE [dbo].[Rep]  WITH CHECK ADD  CONSTRAINT [FK_Rep_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Rep] CHECK CONSTRAINT [FK_Rep_Users]
GO
ALTER TABLE [dbo].[TakePrices]  WITH CHECK ADD  CONSTRAINT [FK_TakePrices_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[TakePrices] CHECK CONSTRAINT [FK_TakePrices_Users]
GO
ALTER TABLE [dbo].[Tools]  WITH CHECK ADD  CONSTRAINT [FK_Tools_Codes] FOREIGN KEY([code_id])
REFERENCES [dbo].[Codes] ([code_id])
GO
ALTER TABLE [dbo].[Tools] CHECK CONSTRAINT [FK_Tools_Codes]
GO
ALTER TABLE [dbo].[Tools]  WITH CHECK ADD  CONSTRAINT [FK_Tools_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Tools] CHECK CONSTRAINT [FK_Tools_Users]
GO
/****** Object:  StoredProcedure [dbo].[SqlQueryNotificationStoredProcedure-873337c4-0214-4de6-8584-e8d27a238687]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SqlQueryNotificationStoredProcedure-873337c4-0214-4de6-8584-e8d27a238687] AS BEGIN BEGIN TRANSACTION; RECEIVE TOP(0) conversation_handle FROM [SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687]; IF (SELECT COUNT(*) FROM [SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687] WHERE message_type_name = 'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer') > 0 BEGIN if ((SELECT COUNT(*) FROM sys.services WHERE name = 'SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687') > 0)   DROP SERVICE [SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687]; if (OBJECT_ID('SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687', 'SQ') IS NOT NULL)   DROP QUEUE [SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687]; DROP PROCEDURE [SqlQueryNotificationStoredProcedure-873337c4-0214-4de6-8584-e8d27a238687]; END COMMIT TRANSACTION; END
GO
/****** Object:  StoredProcedure [dbo].[SqlQueryNotificationStoredProcedure-a277350c-b0d7-4300-9f22-0f4a0bac414b]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SqlQueryNotificationStoredProcedure-a277350c-b0d7-4300-9f22-0f4a0bac414b] AS BEGIN BEGIN TRANSACTION; RECEIVE TOP(0) conversation_handle FROM [SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b]; IF (SELECT COUNT(*) FROM [SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b] WHERE message_type_name = 'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer') > 0 BEGIN if ((SELECT COUNT(*) FROM sys.services WHERE name = 'SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b') > 0)   DROP SERVICE [SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b]; if (OBJECT_ID('SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b', 'SQ') IS NOT NULL)   DROP QUEUE [SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b]; DROP PROCEDURE [SqlQueryNotificationStoredProcedure-a277350c-b0d7-4300-9f22-0f4a0bac414b]; END COMMIT TRANSACTION; END
GO
/****** Object:  StoredProcedure [dbo].[SqlQueryNotificationStoredProcedure-f44eb6df-c4a9-4773-8ef5-7519475227fb]    Script Date: 3/29/2021 11:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SqlQueryNotificationStoredProcedure-f44eb6df-c4a9-4773-8ef5-7519475227fb] AS BEGIN BEGIN TRANSACTION; RECEIVE TOP(0) conversation_handle FROM [SqlQueryNotificationService-f44eb6df-c4a9-4773-8ef5-7519475227fb]; IF (SELECT COUNT(*) FROM [SqlQueryNotificationService-f44eb6df-c4a9-4773-8ef5-7519475227fb] WHERE message_type_name = 'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer') > 0 BEGIN if ((SELECT COUNT(*) FROM sys.services WHERE name = 'SqlQueryNotificationService-f44eb6df-c4a9-4773-8ef5-7519475227fb') > 0)   DROP SERVICE [SqlQueryNotificationService-f44eb6df-c4a9-4773-8ef5-7519475227fb]; if (OBJECT_ID('SqlQueryNotificationService-f44eb6df-c4a9-4773-8ef5-7519475227fb', 'SQ') IS NOT NULL)   DROP QUEUE [SqlQueryNotificationService-f44eb6df-c4a9-4773-8ef5-7519475227fb]; DROP PROCEDURE [SqlQueryNotificationStoredProcedure-f44eb6df-c4a9-4773-8ef5-7519475227fb]; END COMMIT TRANSACTION; END
GO
USE [master]
GO
ALTER DATABASE [DataShareCode] SET  READ_WRITE 
GO
