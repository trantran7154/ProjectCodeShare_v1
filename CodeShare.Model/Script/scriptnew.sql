USE [master]
GO
/****** Object:  Database [DataShareCode]    Script Date: 27/04/2021 12:34:50 CH ******/
CREATE DATABASE [DataShareCode]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataShareCode', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DataShareCode.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataShareCode_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DataShareCode_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
USE [DataShareCode]
GO
/****** Object:  Table [dbo].[Banners]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Bills]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Categorys]    Script Date: 27/04/2021 12:34:51 CH ******/
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
	[category_del] [bit] NULL,
	[category_datecreate] [datetime] NULL,
	[category_dateupdate] [datetime] NULL,
 CONSTRAINT [PK_Categorys] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chats]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Codes]    Script Date: 27/04/2021 12:34:51 CH ******/
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
	[user_id] [int] NULL,
	[code_img] [nvarchar](max) NULL,
	[category_id] [int] NULL,
	[code_key] [nvarchar](max) NULL,
 CONSTRAINT [PK_Codes] PRIMARY KEY CLUSTERED 
(
	[code_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Groups]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Languages]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[News]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Pakages]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Rep]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[TakePrices]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Tools]    Script Date: 27/04/2021 12:34:51 CH ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 27/04/2021 12:34:51 CH ******/
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

INSERT [dbo].[Banners] ([banner_id], [banner_title], [banner_image], [banner_link], [banner_datecreate], [banner_active]) VALUES (1, N'TÌM VÀ CHIA SẺ SOURCE CODE NHANH NHẤT', N'8b35fef55fba1a201c9c7a11d3ec3d64.gif', N'https://semantic-ui.com/', CAST(N'2021-03-27T10:00:00.000' AS DateTime), 1)
INSERT [dbo].[Banners] ([banner_id], [banner_title], [banner_image], [banner_link], [banner_datecreate], [banner_active]) VALUES (2, N'BẢO MẬT TỐT SOURCE CODE CÁ NHÂN', N'comp-1_1.gif', N'https://semantic-ui.com/', CAST(N'2021-03-27T10:00:00.000' AS DateTime), 1)
INSERT [dbo].[Banners] ([banner_id], [banner_title], [banner_image], [banner_link], [banner_datecreate], [banner_active]) VALUES (3, N'GIAO DỊCH BUÔN BÁN SẢN PHẨM AN TOÀN', N'shot.gif', N'https://semantic-ui.com/', CAST(N'2021-03-27T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Banners] ([banner_id], [banner_title], [banner_image], [banner_link], [banner_datecreate], [banner_active]) VALUES (4, N'Ứng dụng mới', N'879142837-huong-dan-sao-chep-worpress-san- ten- mien-tren- cung-1- hosting.jpg', N'https://semantic-ui.com/', CAST(N'2021-04-20T15:10:56.017' AS DateTime), 0)
INSERT [dbo].[Banners] ([banner_id], [banner_title], [banner_image], [banner_link], [banner_datecreate], [banner_active]) VALUES (5, N'Ứng dụng mới1', N'582223424-Thiet-ke-website.png', N'https://semantic-ui.com/', CAST(N'2021-04-20T15:13:08.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Banners] OFF
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (1, CAST(N'2021-03-25T19:15:11.553' AS DateTime), 1, 15, 0, CAST(N'2021-03-25T19:15:11.553' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (2, CAST(N'2021-03-25T19:30:18.120' AS DateTime), 3, 15, 0, CAST(N'2021-04-04T19:30:18.120' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (3, CAST(N'2021-03-25T19:32:26.810' AS DateTime), 1, 1, 0, CAST(N'2021-03-25T19:32:26.810' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (4, CAST(N'2021-03-26T21:43:35.273' AS DateTime), 4, 3, 1, CAST(N'2021-03-26T21:43:35.273' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (5, CAST(N'2021-03-29T14:41:48.830' AS DateTime), 7, 6, 1, CAST(N'2021-03-29T14:41:48.830' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (6, CAST(N'2021-03-29T14:42:20.257' AS DateTime), 3, 6, 1, CAST(N'2021-03-29T14:42:20.257' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (7, CAST(N'2021-03-29T14:43:00.000' AS DateTime), 2, 20, 1, CAST(N'2021-03-29T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img], [category_del], [category_datecreate], [category_dateupdate]) VALUES (1, N'Game', 1, 2, N'373[serverclient]-vo-lam-truyen-ky-mobile-19-phai-day-du-web-api-214535.jpg', 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), CAST(N'2021-04-15T20:07:30.317' AS DateTime))
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img], [category_del], [category_datecreate], [category_dateupdate]) VALUES (2, N'Website', 1, 1, N'276[[flutter]---share-code-ui-facebook-152717.jpg', 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), CAST(N'2021-04-10T21:53:16.150' AS DateTime))
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img], [category_del], [category_datecreate], [category_dateupdate]) VALUES (3, N'Ứng dụng', 1, 1, N'705[serverclient]-vo-lam-truyen-ky-mobile-19-phai-day-du-web-api-214535.jpg', 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), CAST(N'2021-04-15T20:04:59.817' AS DateTime))
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img], [category_del], [category_datecreate], [category_dateupdate]) VALUES (4, N'Khác', 1, 1, N'34do-an-quan-li-nhap-xuat-kho-winformmvc-entity-framework-sql-server-code-phan-mem-quan-ly-code-phan-mem-quan-ly-code-phan-mem-quan-ly-94018.jpg', 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), CAST(N'2021-04-15T20:04:59.817' AS DateTime))
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img], [category_del], [category_datecreate], [category_dateupdate]) VALUES (5, N'Test', 1, 1, N'835bg-info.jpg', 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), CAST(N'2021-04-15T20:04:59.817' AS DateTime))
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img], [category_del], [category_datecreate], [category_dateupdate]) VALUES (6, N'Code', 1, 1, N'888bg.jpg', 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), CAST(N'2021-04-10T21:50:25.033' AS DateTime))
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img], [category_del], [category_datecreate], [category_dateupdate]) VALUES (7, N'Codes', 1, 1, N'982[[flutter]---share-code-ui-facebook-152717.jpg', 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), CAST(N'2021-04-15T20:07:07.377' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categorys] OFF
GO
SET IDENTITY_INSERT [dbo].[Codes] ON 

INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (12, N'[[flutter] - Share code UI Facebook', 50, N'CODE-45501106', N'<p>Bộ ui hoàn thiện giống hoàn toàn như app facebook đang sử dụng, các bạn chỉ cần tải về mở ra và chạy thử. Còn làm gì với nó để thành app của bạn là tùy thuộc vào bạn.</p><p>Xin cảm ơn</p>', N'Giao diện giống như facebook được làm bằng flutter, tương thích IOS, Android và cả web', N'<p>Sử dụng android hoặc bất kỳ công cụ nào bạn dùng để code flutter để mở ra nhé</p>', 2, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:04:31.000' AS DateTime), CAST(N'2021-03-29T13:04:31.000' AS DateTime), 1, 1, 0, N'Android;', 1, N'123', 5, N'7dae2a77-85ca-44be-92e0-dff3ab85f39a.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (13, N'Phần mềm quản lý điểm danh và lịch phân công giảng dạy', 100, N'CODE-1031405846', N'<p>Bài toán đặt ra: Bạn quản lý phân công lịch dạy và điểm danh học sinh Phần mềm giúp bạn nhanh chóng xem được lịch dạy của giáo viên Danh sách điểm danh chi tiết Danh sách học sinh cần làm báo cáo.</p><p>Sử dụng code thuần PHP</p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222817.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222818.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222819.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222820.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/phan-mem-quan-ly-diem-danh-va-lich-phan-cong-giang-day-222821.jpg" alt="phân mềm quản lý,quản lý điểm danh,phân công công việc,Code quản lý điểm danh"></figure>', N'Bài toán đặt ra: Bạn quản lý phân công lịch dạy và điểm danh học sinh Phần mềm giúp bạn nhanh chóng xem được lịch dạy của giáo viên Danh sách điểm danh chi tiết Danh sách học sinh cần làm báo cáo', NULL, 0, 0, N'https://semantic-ui.com/', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:07:01.293' AS DateTime), CAST(N'2021-03-29T13:07:01.293' AS DateTime), 1, 1, 0, N'Dữ Liệu;', 1, N'123', 5, N'4adf6c87-582a-4906-b34a-c8ed0cf1dd3c.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (14, N'Full code Website wordpress kinh doanh nhà hàng Oishii phong cách Nhật Bản chuẩn SEO giá rẻ ', 80, N'CODE-923477049', N'<p>Full code Website wordpress kinh doanh nhà hàng Oishii phong cách Nhật Bản chuẩn SEO giá rẻ, sử dụng theme flatsome</p><p>Giải nén và import database từ file trong thư mục Database</p><p>Tài khoản: admin/admin</p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112527.jpg" alt="website kinh doanh nhà hàng,website nhà hàng Nhật Bản,website wordpress,website kinh doanh oishii"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112528.jpg" alt="website kinh doanh nhà hàng,website nhà hàng Nhật Bản,website wordpress,website kinh doanh oishii"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112529.jpg" alt="website kinh doanh nhà hàng,website nhà hàng Nhật Bản,website wordpress,website kinh doanh oishii"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112530.jpg" alt="website kinh doanh nhà hàng,website nhà hàng Nhật Bản,website wordpress,website kinh doanh oishii"></figure><p><br>&nbsp;</p>', N'Full code Website wordpress kinh doanh nhà hàng Oishii phong cách Nhật Bản chuẩn SEO giá rẻ, sử dụng theme flatsome', NULL, 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:10:44.697' AS DateTime), CAST(N'2021-03-29T13:10:44.697' AS DateTime), 1, 1, 0, N'Website WordPress;', 1, NULL, 5, N'41c6aeaa-625b-4f4b-91a8-0ac5e628e865.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (15, N'Source Website mua bán đăng tin bất động sản', 120, N'CODE-993455253', N'<p>Websile mua bán đăng tin bất động sản đẹp đầy đủ chức năng quản lý menu và bài viết dễ dàng</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/website-mua-ban-dang-tin-bat-dong-san-23744.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/source-website-mua-ban-dang-tin-bat-dong-san-105657.jpg" alt="web bất động sản,website bất động sản,bất động sản"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/source-website-mua-ban-dang-tin-bat-dong-san-105836.jpg" alt="web bất động sản,website bất động sản,bất động sản"></figure>', N'Websile mua bán đăng tin bất động sản đẹp đầy đủ chức năng quản lý menu và bài viết dễ dàng', N'<p>các bạn up file lên host và sửa database trong file config mình đã có hình ảnh ở trên<br>Link Quản trị Web:&nbsp;<br>https://www.domain.com/administrator<br><br>ID: admin<br>Pass: 123456</p>', 1, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:13:08.193' AS DateTime), CAST(N'2021-03-29T13:13:08.193' AS DateTime), 1, 1, 0, N'Website;', 1, N'123', 5, N'1bf7245a-7a4f-4e8a-bf25-96b836c7d388.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (16, N'Source code website bán sách online', 50, N'CODE-603249008', N'<p>Các chức năng của website:</p><p>* Chức năng cho người dùng</p><p>&nbsp; &nbsp; &nbsp;- Xem thông tin sách</p><p>&nbsp; &nbsp; &nbsp;- Thêm sách vào giỏ hàng</p><p>&nbsp; &nbsp; &nbsp;- Thực hiện tìm kiếm sách</p><p>* Chức năng cho admin</p><p>&nbsp; &nbsp; &nbsp;- Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ</p><p>&nbsp;</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/source-code-website-ban-sach-online-81146.jpg" alt="web bán sách,Source website,Website bán sách online,code website bán sách online"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/source-code-website-ban-sach-online-81147.jpg" alt="web bán sách,Source website,Website bán sách online,code website bán sách online"></figure>', N'Website bán sách online sử dụng ngôn ngữ java/jsp có các chức năng cơ bản của một trang web bán sách.', N'<p>* Yêu cầu máy đã cài đặt Netbeans và SQL&nbsp; Server</p><p>1. Chạy database trong thư mục database</p><p>2. Mở Netbeans và chạy project</p><p>&nbsp;</p>', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:25:06.463' AS DateTime), CAST(N'2021-03-29T13:25:06.463' AS DateTime), 1, 1, 0, N'Web;', 1, N'123', 5, N'080c7afa-e052-4391-babb-5600cd96cadb.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (17, N'Đăng ký và Tra cứu thông tin sinh viên', 50, N'CODE-525425447', N'<p>Phần mềm giúp đăng ký thông tin sinh viên và tra cứu thông tin chi tiết khi cần thiết với đầy đủ tính năng.</p><p>Ưu điểm :</p><p>+ Giao diện đẹp</p><p>+ Đăng ký thông tin toàn diện (Thêm ảnh, điền thông tin, ...)</p><p>+ Đã tạo các ràng buộc cơ bản đầy đủ</p><p>+ Code đơn giản dễ hiểu, có thể tự mở rộng tính năng hoặc chỉnh sửa cấu trúc</p><p>Nhược điểm :</p><p>- Nền phần mềm được thiết kế sẵn, nên muốn đổi thì cần có hinh nền khác</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/dang-ky-va-tra-cuu-thong-tin-sinh-vien-26293.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/dang-ky-va-tra-cuu-thong-tin-sinh-vien-135314.jpg" alt="tra cứu thông tin,quản lý thông tin sinh viên,thông tin điểm sinh viên,đăng ký thông tin sinh viên,sinh viên,đăng ký"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/dang-ky-va-tra-cuu-thong-tin-sinh-vien-135315.jpg" alt="tra cứu thông tin,quản lý thông tin sinh viên,thông tin điểm sinh viên,đăng ký thông tin sinh viên,sinh viên,đăng ký"></figure><p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/dang-ky-va-tra-cuu-thong-tin-sinh-vien-135316.jpg" alt="tra cứu thông tin,quản lý thông tin sinh viên,thông tin điểm sinh viên,đăng ký thông tin sinh viên,sinh viên,đăng ký"></figure>', N'Phần mêm giúp đăng ký và tra cứu thông tin chi tiết của sinh viên. Giúp người dùng quản lý thông tin của sinh viên một cách dễ dàng.', N'<p>Lưu ý :</p><p>1. Cần có phầm mêm SQL Sever (Khuyên dùng phiên bản 2017 trở lên)</p><p>2. Cần có phần mềm Visual Studion (Khuyên dùng phiên bản 2017 trở lên và có cài đặt gói ngôn ngữ VB)</p><p>3. Phần mềm đã được tinh chỉnh cấu hình kết nối để chạy được mọi máy đã tạo CSDL (thông qua file .sql) nên không cần chỉnh chuỗi kết nối</p><p>Các bước cài đặt :</p><p>1. Sử dụng file .sql kèm theo để tạo cơ sở dữ liệu cũng như để thêm các mẫu dữ liệu căn bản</p><p>2. Mở project bằng phần mềm Visual Studio và chọn Start/Build</p><p>3. Enjoy</p>', 31, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:27:18.907' AS DateTime), CAST(N'2021-03-29T13:27:18.907' AS DateTime), 1, 1, 0, N'Ứng dụng;', NULL, N'123', 5, N'eeda18fa-8dc4-4235-abc0-a08670a7193a.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (18, N'Đồ án quản lí nhập xuất kho Winform(MVC), entity framework, SQl server', 80, N'CODE-792376133', N'<figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/do-an-quan-li-nhap-xuat-kho-winformmvc-entity-framework-sql-server-code-phan-mem-quan-ly-code-phan-mem-quan-ly-code-phan-mem-quan-ly-94021.jpg" alt="Code quản lý,nhập xuất,nhập xuất kho Winform,Code phần mềm quản lý"></figure>', N'Full code App quản lí xuất nhập kho, winform theo mô hình MVC, sử dụng enity framework', N'<p>có hướng dẫn chi tiết trong file tải</p><p>&nbsp;</p>', 2, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:47:40.967' AS DateTime), CAST(N'2021-03-29T13:47:40.967' AS DateTime), 1, 1, 0, N'C#;', NULL, N'123', 5, N'fd682de8-d206-4db7-9c30-dcd410873efe.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (19, N'Full Teamplate HTML + CSS + Bootstrap 4 - Giao Diện Bán Điện Thoại Hiệu Ứng UI/UX Cực Đỉnh + Đầy Đủ Các Trang + Demo', 80, N'CODE-561269831', N'<p>Teamplate có giao diện cực đẹp và UI cực chất cho mọi người thỏa sức phát triển và sáng tạo. Mời mọi người xem demo để có trải nghiệm tốt nhất.&nbsp;</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/full-teamplate-html-css-bootstrap-4-giao-dien-ban-dien-thoai-hieu-ung-uiux-cuc-dinh-day-du-cac-trang-demo-27695.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/full-teamplate-html-css-bootstrap-4---giao-dien-ban-dien-thoai-15028.jpg" alt="Template Giao Diện,Bootstrap 4 Admin,Giao diện website bán sách,Giao diện bán điện thoại,Giao diện Bootstrap,Điện thoại"></figure>', N'Đây là teamplate bán điện thoại Hiệu Ứng UI/UX Cực Đỉnh + Đầy Đủ Các Trang + Demo mình sưu tầm được, muốn chia sẻ cho mọi người cùng sử dụng, mời mọi người tham khảo.', N'<p>Tải về, giải nén và tận hưởng thôi</p>', 2, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T13:53:05.787' AS DateTime), CAST(N'2021-03-29T13:53:05.787' AS DateTime), 1, 1, 0, N'Web;', NULL, N'123', 5, N'2d3b0f12-ac0c-4ff8-89d5-56bf6208af4b.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (20, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 676, N'CODE-200478690', N'<p>hfxfhdxfgmbk,</p>', N'ugtfvg', N'<p>hgc gvvhb&nbsp;</p>', 53, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T14:32:25.420' AS DateTime), CAST(N'2021-03-29T14:32:25.420' AS DateTime), 1, 1, 0, N'fdcgfcfv'';', 10, N'vcf ', 6, N'1bbb2aa2-0b94-467c-bc0f-575e0f605f34.png', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (21, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 0, N'CODE-788815677', N'<p>code</p>', N'code', N'<p>code</p>', 2, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T20:49:00.000' AS DateTime), CAST(N'2021-03-29T20:49:00.000' AS DateTime), 1, 1, 0, N'game C#;', 10, N'123', 6, N'41490282-5a93-44e6-9234-4a095771a4d8.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (22, N'Soure code Quản lý mua bán linh kiện máy tính', 111, N'CODE-15168693', N'<p>code</p>', N'code', N'<p>code</p>', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T21:11:25.000' AS DateTime), CAST(N'2021-03-29T21:11:25.000' AS DateTime), 1, 0, 0, N'web;', 10, N'123', 6, N'197a7f1a-21a5-4a0f-918a-8ce5af9b4b63.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (23, N'Source Code Phần mềm quản lí khách sạn', 12, N'CODE-961474107', N'<p>code</p>', N'code', N'<p>code</p>', 27, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-29T21:15:22.000' AS DateTime), CAST(N'2021-03-29T21:15:22.000' AS DateTime), 1, 1, 0, N'we;', 12, N'12', 1, N'55d4484a-e439-446f-a0d7-58f9fbf1bcfa.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (24, N'Auto Chess Unity Game Template', 190, N'CODE-1748325225', N'<p>- Code dùng để học tập nghiên cứu</p><p>- Có thể dùng làm bài tập lớn</p><p>- Có thể làm đồ án tốt nghiệp</p><p>- Có thể tiếp tục phát triển để đẩy lên Store</p><p><br>XEM THÊM ==&gt; <a href="https://sharecode.vn/source-code/auto-chess-unity-game-template-27897.htm#huong-dan-cai-dat">Hướng dẫn cài đặt chi tiết</a></p><p>&nbsp;</p><p><strong>HÌNH ẢNH DEMO</strong><br><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/CodeUpload/auto-chess-unity-game-template-18415.jpg" alt="Game,Template,Unity Template,Auto Chess,Proroty"></figure>', N'Code dùng để học tập nghiên cứu, có thể tiếp tục phát triển - Code dễ đọc, dễ hiểu', N'<p>- Video hướng dẫn cài đặt trong Project</p><p>- Link apk:</p><p>https://drive.google.com/file/d/1SBH0d8O8KgoxCs-5492K5FhpWhPv3b6b/view?usp=sharing</p><p>&nbsp;</p>', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-03-30T07:54:44.727' AS DateTime), CAST(N'2021-03-30T07:54:44.727' AS DateTime), 1, 1, 1, NULL, 11, N'11', 6, N'334f276a-4dc8-45a2-ab69-b698b302e5c1.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (27, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 300, N'CODE-1381905589', N'code', N'code', N'code', 0, 0, N'https://semantic-ui.com/', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-04-08T13:16:55.170' AS DateTime), CAST(N'2021-04-08T13:16:55.170' AS DateTime), 2, 1, 1, NULL, 10, N'vcf ', 1, N'643template-blogger-ban-hang-laptop---dien-thoai---ipad-172042.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (28, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 300, N'CODE-1436725144', N'code', N'code', N'code', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-04-08T13:47:56.843' AS DateTime), CAST(N'2021-04-08T13:47:56.843' AS DateTime), 2, 1, 1, NULL, 10, N'123', 1, N'669102941-chuyen-host-doi-domain-duplicator 1.png', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (29, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 100, N'CODE-822964324', N'code', N'code', N'code', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-04-08T13:52:58.000' AS DateTime), CAST(N'2021-04-08T20:38:39.410' AS DateTime), 1, 1, 1, NULL, 10, N'123', 1, N'448[[flutter]---share-code-ui-facebook-152717.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (30, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 100, N'CODE-822964324', N'code', N'code', N'code', 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-04-08T19:19:37.000' AS DateTime), CAST(N'2021-04-08T20:51:54.677' AS DateTime), 1, 1, 1, NULL, 10, N'123', 1, N'383full-code-website-wordpress-kinh-doanh-nha-hang-oishii-phong-cach-nhat-ban-chuan-seo-gia-re-112527.jpg', 3, NULL)
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (31, N'[Server+Client] Võ Lâm Truyền Kỳ Mobile 19 phái đầy đủ Web, API', 100, N'CODE-1522030753', N'<p>code</p>', N'Template Website thực phẩm sạch dùng cho các bạn sinh viên tham khảo và nghiên cứu.', NULL, 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-04-26T13:22:36.277' AS DateTime), NULL, 2, 1, 0, NULL, 10, N'123', NULL, N'708template-website-website-gioi-thieu-thuc-pham-website-thuc-pham-sach-152030.jpg', 2, N'7d8b37e3-9db2-4e9c-b76c-7dedd611edf9')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (32, N'Template Website thực phẩm sạch', 100, N'CODE-854428716', N'<p>code</p>', N'Template Website thực phẩm sạch dùng cho các bạn sinh viên tham khảo và nghiên cứu.', NULL, 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-04-26T13:49:09.393' AS DateTime), NULL, 2, 1, 0, NULL, 10, N'123', NULL, N'397template-website-website-gioi-thieu-thuc-pham-website-thuc-pham-sach-152030.jpg', 2, N'4cac5d9b-24f1-496f-b5cd-54da54381b4b')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (33, N'Template Website thực phẩm sạch', 100, N'CODE-1619956199', N'<p>code</p>', N'Template Website thực phẩm sạch dùng cho các bạn sinh viên tham khảo và nghiên cứu.', NULL, 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-04-26T13:59:12.407' AS DateTime), NULL, 2, 1, 0, NULL, 10, N'123', NULL, N'754template-website-website-gioi-thieu-thuc-pham-website-thuc-pham-sach-152030.jpg', 2, N'db4a94da-38eb-4478-86cd-82c514be6d08')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [user_id], [code_img], [category_id], [code_key]) VALUES (34, N'Chia sẻ template blogspot tin tức load siêu nhanh', 100, N'CODE-1696699658', N'<p>Template có điểm Google PageSpeed Insights dao động từ 96 đến 100.</p><p>Với tốc độ load nhanh và điểm Google PageSpeed Insights gần như tối đa, đây là một template có khả năng SEO rất tốt, được google chú ý đặt cách hơn.</p>', N'Đây là một blogger template miễn phí với ưu điểm là sử dụng css và html thuần túy, không sử dụng javascript.', NULL, 0, 0, N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', N'https://sharecode.vn/source-code/template-blogger-ban-hang-laptop-dien-thoai-ipad-27975.htm', CAST(N'2021-04-26T14:16:40.167' AS DateTime), NULL, 2, 1, 0, NULL, 10, N'123', NULL, N'790template-blogspot-tin-tuc-load-sieu-nhanh-113053.jpg', 2, N'e7c1a714-140c-46c6-8c93-d37267fc0da6')
SET IDENTITY_INSERT [dbo].[Codes] OFF
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([comment_id], [user_id], [code_id], [comment_content], [comment_datecreate], [news_id], [comment_dateupdate]) VALUES (1, 6, 23, N'hay', CAST(N'2021-03-30T08:02:56.390' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Comment] OFF
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
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (42, NULL, NULL, 24, 11, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (43, NULL, NULL, 27, 1, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (44, NULL, NULL, 27, 2, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (45, NULL, NULL, 27, 3, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (46, NULL, NULL, 27, 7, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (47, NULL, NULL, 27, 8, 1)
INSERT [dbo].[Groups] ([group_id], [category_id], [user_id], [code_id], [language_id], [group_item]) VALUES (48, NULL, NULL, 31, 8, 1)
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
INSERT [dbo].[Languages] ([language_id], [language_name], [language_active], [language_img], [language_view]) VALUES (14, N'Test', 1, N'290[[flutter]---share-code-ui-facebook-152717.jpg', 0)
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (1, N'An toàn thông tin', 0, N'<p>Tin tức công nghệ nè</p>', N'#news', 5, CAST(N'2021-04-24T19:13:01.000' AS DateTime), CAST(N'2021-04-24T19:50:30.843' AS DateTime), 1, 0, 1, N'557142837-huong-dan-sao-chep-worpress-san- ten- mien-tren- cung-1- hosting.jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (2, N'Tin tức công nghệ', 0, N'<p>Tin tức công nghệ</p>', N'#news', 9, CAST(N'2021-04-24T19:25:58.310' AS DateTime), NULL, 2, 1, 1, N'813102941-chuyen-host-doi-domain-duplicator 1.png')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (3, N'Google cuối cùng cũng đã khai tử CAPTCHA', 0, N'<p>Sau CAPTCHA và reCAPTCHA, Google đã tiến đến một công cụ mới có tên Invisible CAPTCHA. Với công cụ này, bạn không cần nhập mã CAPTCHA cũng không cần chứng minh "Tôi không phải là robot" nữa.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/captcha%20chinh%20thuc%20khai%20tu%20(1).jpg" alt="google,captcha,recaptcha"></figure><p>CAPTCHA là một thứ bất tiện nhưng cần thiết. Hệ thống để xác minh liệu một người dùng có phải là con người thật hay không này đã được đưa vào sử dụng suốt một thời gian khá dài và ngày càng&nbsp;phát triển hơn lên. Thế nhưng, với những tiến bộ mới nhất, Google cho biết bạn sẽ không còn phải nhập bất cứ thứ gì để chứng minh mình là con người nữa.</p><p>Invisible CAPTCHA là bước phát triển mới nhất trong phép thử Turing công cộng hoàn toàn tự động (Completely Automated Public Turing test) để phân biệt giữa máy tính và con người. Google đã mua lại reCaptcha vào năm 2009. Hệ thống này được cập nhật trong năm 2013 và từ đó&nbsp;ô "Tôi không phải là robot" đã xuất hiện khắp mọi nơi trên Internet. Phiên bản này hoạt động&nbsp;bằng cách xác định đối tượng ngồi trước màn hình có phải là con người hay không thông qua cách họ nhấp chuột. Nếu việc nhấp chuột có vẻ đáng nghi ngờ, một bài kiểm tra phức tạp hơn sẽ được đưa ra. Nhưng Invisible CAPTCHA có thể nhận ra người dùng không phải là một bot chỉ đơn giản bằng cách phân tích hành vi duyệt web của họ.</p><p>Trong video, công ty giải thích rằng: "Sức mạnh đằng sau những tiến bộ này là sự kết hợp giữa công nghệ học máy và phân tích rủi ro tiên tiến thích ứng với các nguy cơ mới và đang xuất hiện". Nhưng nó có ích gì đối với Google?</p><p>Khi gã khổng lồ tìm kiếm bước đầu mua lại reCaptcha, công ty thực sự hướng tới việc kết hợp nó vào dự án scan sách khổng lồ của mình. Công nghệ này rất phù hợp để số hóa các cuốn sách viết bằng các&nbsp;loại chữ khó đọc cho hệ thống phiên mã của Google. Nhưng không rõ Google thu được những gì khi tiếp tục cải tiến phần mềm.</p><p>Shuman Ghosemajumder, cựu nhân viên của Google, chia sẻ với trang Popular Science: "Google nói chung, và đây chắc chắn là một triết lý mà chúng tôi tôn trọng hồi&nbsp;tôi còn làm việc ở đó, cho rằng bất cứ điều gì tốt cho internet thì đều tốt cho Google". Trong trường hợp này, một mạng Internet "không có cản trở" tốt cho tất cả mọi người.</p>', N'#news', 6, CAST(N'2021-04-25T21:11:16.677' AS DateTime), NULL, 1, 1, 0, N'808captcha chinh thuc khai tu (1).jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (4, N'Robot Moro, đối thủ lớn của Amazon Echo và Google Home', 0, N'<p>Những trợ lý trong nhà như Amazon Echo và Google Home ngày càng được người dùng ưa chuộng nhưng tính năng của chúng vẫn có những giới hạn. Chúng có thể báo cho bạn biết cách thức tìm được một ly soda trong nhà nhưng lại không thể mang chúng đến cho bạn. Và đó chính là nơi Moro thể hiện.&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/robot-moro-doi-thu-lon-cua-amazon-echo-va-google-chome%201.jpg" alt="robot,amzon,google"></figure><p>Theo&nbsp;<i>Engadget</i>, hãng robot Ewaybot đã tạo ra Moro, một trợ lý hình người hiện tại chỉ phục vụ cho các phòng thí nghiệm nghiên cứu và các trường đại học ở Trung Quốc.</p><p>Moro cao khoảng 1,2m, nặng khoảng 35kg và mỗi cánh tay có hệ thống "xúc tu" giúp cầm nắm mọi thứ: từ những chiếc khăn giấy mỏng manh đến cả những đồ vật nặng hơn. Robot sẽ phản hồi lại những giao tiếp bằng giọng nói thông qua một trợ lý ảo tương tự Amazon Echo.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/robot-moro-doi-thu-lon-cua-amazon-echo-va-google-chome%202.jpg" alt="robot,amzon,google"></figure><p>Moro sử dụng hệ thống máy ảnh RealSense của Intel để tránh các chướng ngại vật, thêm vào đó là công nghệ siêu âm và các cảm biến hồng ngoại. Chú robot này có giá khoảng 30.000 USD, mức chi phí được cho là phù hợp với các phòng thí nghiệm và các trường đại học. Tuy nhiên, đây không phải là điểm đến duy nhất của chú robot này.</p><p>Ewaybot muốn đưa Moro hiện diện trên các hộ gia đình trên khắp thế giới để hỗ trợ các hoạt động kinh doanh và trợ giúp trong nhà. Hãng đã sẵn sàng cho các phiên bản này của Moro, với mức giá thấp hơn nhiều so với mốc 30.000 USD.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/robot-moro-doi-thu-lon-cua-amazon-echo-va-google-chome%203.jpg" alt="robot,amzon,google"></figure><p>Sau CES 2017 tại Las Vegas, chú robot này sẽ thực hiện tour lưu diễn khắp các trường đại học của Mỹ, mở đầu tại đại học Harvard và Carnegie Mellon.</p>', N'#news', 6, CAST(N'2021-04-25T21:12:45.723' AS DateTime), NULL, 1, 1, 0, N'431robot-moro-doi-thu-lon-cua-amazon-echo-va-google-chome 1.jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (5, N'Internet of things IOT là gì?', 0, N'<p><strong>Gần đây thuật ngữ IOT (Internet of things) xuất hiện khá nhiều trên các phương thiện thông tin đại chúng và thu hút không ít sự quan tâm chú ý của thế giới công nghệ. Vậy IOT là gì, có liên quan gì đến Internet?</strong></p><p>Internet of things (IOT) đã manh nha từ nhiều thập kỷ&nbsp;trước nhưng mãi đến năm 1999 cụm từ IOT mới được đưa ra bởi Kevin Ashton.&nbsp;Ông là một nhà khoa học đã sáng lập ra Trung tâm Auto-ID ở Đại học MIT, nơi thiết lập các quy chuẩn toàn cầu cho RFID (một phương thức giao tiếp không dây dùng sóng radio) cũng như một số loại cảm biến khác.</p><p>&nbsp;</p><h3><strong>Vậy Internet of things là gì?</strong></h3><p>Theo&nbsp;<i>Wikipedia</i>,&nbsp;Internet of things có nghĩa là mạng lưới mà mọi thiết bị, vật thể&nbsp;được cung cấp một định danh của riêng mình, và tất cả có khả năng&nbsp;truyền tải, trao đổi&nbsp;thông tin,&nbsp;dữ liệu&nbsp;qua một mạng (máy tính/internet)&nbsp;duy nhất mà không cần đến sự&nbsp;tương tác trực tiếp (tiếp xúc) giữa người với người, hay người với&nbsp;máy tính hoặc người với thiết bị. IOT đã phát triển từ sự hội tụ của&nbsp;công nghệ không dây, công nghệ vi cơ điện tử và Internet. Nói đơn giản là một&nbsp;tập hợp&nbsp;các&nbsp;thiết bị&nbsp;có khả năng&nbsp;kết nối&nbsp;với nhau, với&nbsp;Internet&nbsp;và với&nbsp;thế giới bên ngoài&nbsp;để thực hiện một công việc nào đó.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/internet-of-things-la-gi.png" alt="internet,of things,IOT"></figure><p>Hiểu nôm na một cách đơn giản IOT là tất cả các thiết bị có thể kết nối với nhau thông qua Internet. Việc kết nối thì có thể thực hiện qua&nbsp;Wi-Fi, mạng viễn thông băng rộng (3G,&nbsp;4G), Bluetooth, ZigBee, hồng ngoại… Các thiết bị có thể là điện thoại thông minh, máy pha cafe, máy giặt, tai nghe, bóng đèn, và nhiều thiết bị khác.</p><p>Theo Cisco, nhà cung cấp giải pháp và thiết bị mạng hàng đầu hiện nay dự báo: Đến năm 2020, sẽ có khoảng 50 tỉ&nbsp;thiết bị kết nối vào Internet, thậm chí con số này còn gia tăng nhiều hơn nữa. IOT sẽ là mạng khổng lồ kết nối tất cả mọi thứ, bao gồm cả con người và sẽ tồn tại các mối quan hệ giữa người và người, người và thiết bị, thiết bị và thiết bị. Một mạng lưới IOT có thể chứa đến 50 đến 100 nghìn tỉ đối tượng được kết nối và mạng lưới này có thể theo dõi sự di chuyển của từng đối tượng. Một con người sống trong thành thị có thể bị bao bọc xung quanh bởi 1.000 đến 5.000 đối tượng có khả năng theo dõi và kết nối.</p><h3><strong>Ứng dụng của IOT</strong></h3><p>IOT có ứng dụng rộng rãi và bao quát mọi lĩnh vực đời sống, một số ứng dụng lớn như sau:</p><p>o&nbsp;&nbsp;&nbsp; Quản lý&nbsp;chất thải</p><p>o&nbsp;&nbsp;&nbsp; Quản lý&nbsp;và lập kế hoạch quản lý&nbsp;đô thị</p><p>o&nbsp;&nbsp;&nbsp; Quản lý&nbsp;môi trường</p><p>o&nbsp;&nbsp;&nbsp; Phản hồi trong các tình huống khẩn cấp</p><p>o&nbsp;&nbsp;&nbsp; Mua sắm thông minh</p><p>o&nbsp;&nbsp;&nbsp; Quản lý&nbsp;các thiết bị cá nhân</p><p>o&nbsp;&nbsp;&nbsp; Đồng hồ đo thông minh</p><p>o&nbsp;&nbsp;&nbsp; Tự động hóa&nbsp;ngôi nhà</p><p>Ứng dụng IOT rất đa dạng, trên tất cả&nbsp;các lĩnh vực đời sống: quản lý hạ tầng, y tế, xây dựng và tự động hóa, giao thông…&nbsp;Cụ thể trong lĩnh vực y tế, IOT có thể được sử dụng trên các thiết bị&nbsp;theo dõi sức khỏe từ xa và&nbsp;hệ thống thông báo khẩn cấp. Các thiết bị theo dõi huyết áp&nbsp;và&nbsp;nhịp tim, thiết bị&nbsp;giám sát được cấy ghép vào cơ thể, máy điều hòa nhịp tim, máy trợ thính thông qua các&nbsp;cảm biến đặc biệt gửi tín hiệu đến trung tâm điều khiển nhằm cảnh báo sớm, giám sát bệnh án.&nbsp;</p><p>Một ứng dụng khác là nhà thông minh, các thiết bị có thể tự động báo thức, mở cửa khi trời sáng, dùng các cảm biến để quét số lượng người trong phòng, nếu không có ai sẽ tự tắt. Tự động kiểm tra đèn, thiết bị điện tử, van gas và tự động tắt đi khi không có ai trong nhà. Ngoài ra, bạn còn có thể giám sát chiếc điện thoại, xe của mình thông qua GPS và phần mềm để quản lý, chống mất trộm...</p><h3><strong>IOT trong tương lai</strong></h3><p>Cisco, Intel, và Qualcomm đang đẩy mạnh tài trợ cho các startup&nbsp;IOT&nbsp;không chỉ vì lý do họ là những sản xuất hạ tầng cho các thiết bị IOT&nbsp;mà còn từ tiềm năng và lợi nhuận to lớn trong từ Internet of Things như Intel&nbsp;hơn 2 tỉ&nbsp;USD trong năm 2014.</p><h3><strong>Dự đoán Internet of Things đến năm 2020</strong></h3><p>+ 4 tỉ&nbsp;người kết nối với nhau</p><p>+ 4 ngàn tỉ&nbsp;USD doanh thu</p><p>+ Hơn 25 triệu ứng dụng</p><p>+ Hơn 25 tỉ&nbsp;hệ thống nhúng và hệ thống thông minh</p><p>+ 50 ngàn tỉ&nbsp;Gigabytes dữ liệu</p><p>Do đó có thể nói Internet of Things không phải chỉ đơn giản là một trào lưu, xu hướng mà Internet of Things chính là tương lai. Bằng cách này hay cách khác IOT sẽ dần hiện diện trong cuộc sống chúng ta như một phần nhu cầu tất yếu.</p>', N'#news', 5, CAST(N'2021-04-25T21:13:36.907' AS DateTime), NULL, 1, 1, 0, N'816internet-of-things-la-gi.png')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (6, N'Cách lấy ảnh từ file Word cho chất lượng tốt nhất', 0, N'<p><strong>ó khá nhiều cách giúp bạn lấy ảnh từ file Word ra, tuy nhiên, những thử nghiệm cho thấy chỉ có phương pháp xuất file Word ra file PDF là giúp ảnh có chất lượng tốt nhất.</strong></p><p>Lấy ảnh từ file Word (và giữ được chất lượng ảnh) từ trước tới nay chưa bao giờ là một việc dễ dàng. Đó là bởi Word sử dụng công nghệ nén hình ảnh (đôi khi mức nén xuống tới 72 dpi) để tiết kiệm bộ nhớ lưu trữ và giảm kích thước file. Nếu là chủ sở hữu file Word, bạn có thể vô hiệu hoá tính năng tự động nén ảnh, tuy nhiên, bước này phải được thực hiện trước khi ảnh được chèn.</p><p>Một ví dụ như bạn không thể copy rồi dán từ Word sang các chương trình khác như Photoshop hay Paint Shop Pro mà không làm giảm chất lượng ảnh. Một số mẹo để làm được điều này thì cho ra kết quả là ảnh bị mờ, giảm độ phân giải. Hầu hết các giải pháp dưới đây, tuy nhiên, sẽ cho ra kết quả chấp nhận được. Đặc biệt, cách cuối cùng sẽ giúp bạn có được bức ảnh với chất lượng gần như tương đương ảnh gốc.&nbsp;</p><p>Để thực hiện, bạn mở một tài liệu Word mới, sau đó chọn&nbsp;<i>Insert &gt; Picture</i>, rồi điều hướng tới 1 thư mục có chứa ảnh trên máy tính. Bạn chọn 1 hình ảnh phù hợp (cỡ khoảng trên 2 MB), rồi click&nbsp;<i>Insert</i>. Bạn cần nhớ kích thước ảnh gốc để so sánh chất lượng về sau. Ảnh gốc trong hướng dẫn dưới đây có dung lượng 6,85 MB.</p><p><strong>Lưu ảnh bằng Save As Picture</strong></p><p>Cách phổ biến nhất để lấy ảnh từ file Word là click chuột phải vào ảnh, chọn&nbsp;<i>Save as Pictures</i>. Tuy nhiên, bạn hãy xem ảnh gốc đã bị thay đổi như thế nào khi được lưu bằng phương pháp này.&nbsp;</p><figure class="table"><table><tbody><tr><td><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat%203.png" alt="file Word,file PDF,lấy ảnh"></figure></td></tr><tr><td><i>Rất dễ để trích xuất ảnh từ Word bằng lệnh Save as Picture, tuy nhiên, ảnh được trích xuất sẽ có kích thước file nhỏ hơn so với ảnh gốc.&nbsp;</i></td></tr></tbody></table></figure><p>Sau khi chọn&nbsp;<i>Save as Picture</i>, bạn chọn nơi lưu ảnh mới, điền tên rồi click&nbsp;<i>Save</i>.&nbsp;</p><p>Mở 1 ứng dụng đồ hoạ, ví dụ như Photoshop, và mở ảnh gốc bạn chèn vào file Word. Tiếp theo, bạn mở ảnh được trích xuất từ file Word ra.&nbsp;</p><p>Ảnh gốc có độ phân giải là 300 dpi, và kích thước file (như đã nói trên) là 6,85 MB. Kích cỡ ảnh là 8,16 x 10,88 inch.&nbsp;</p><figure class="table"><table><tbody><tr><td><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat%204.png" alt="file Word,file PDF,lấy ảnh"></figure></td></tr><tr><td><i>Ảnh gốc có kích thước file và kích thước ảnh lớn hơn</i></td></tr></tbody></table></figure><p>Ảnh được chèn vào Word, sau đó được trích xuất ra bằng lệnh&nbsp;<i>Save as&nbsp;Picture</i>, cũng có độ phân giải 300 dpi, nhưng kích cỡ file đã bị giảm xuống còn 1,36 MB, và kích thước ảnh là 5,983 x 7,98 inch.</p><figure class="table"><table><tbody><tr><td><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat%205.png" alt="file Word,file PDF,lấy ảnh"></figure></td></tr><tr><td><i>Phiên bản ảnh lưu bằng lệnh Save as Picture nhỏ hơn về cả kích thước ảnh lẫn kích thước file, nhưng độ phân giải thì được giữ nguyên so với ảnh gốc.&nbsp;</i></td></tr></tbody></table></figure><p>Như vậy, cách này giúp bạn giữ nguyên độ phân giải ảnh, tuy nhiên, kích thước file và ảnh đã bị giảm. Nếu bạn cần trích xuất ảnh từ Word và giữ nguyên kích thước gốc, bạn sẽ phải dùng cách khác.&nbsp;</p><p><strong>Lưu tài liệu dưới dạng website&nbsp;</strong></p><p>Chèn ảnh gốc 6,85 MB vào một tài liệu Word mới như trên. &nbsp;</p><p>Chọn&nbsp;<i>File &gt; Save As</i>. Bên dưới ô&nbsp;<i>Save As Type</i>, bạn chọn&nbsp;<i>Web Page (*.htm; *.html)</i>. Bạn lưu ý không chọn&nbsp;<i>Web Page, Filterer (*.htm; *.html)</i>&nbsp;bởi nó sẽ cho ra ảnh độ phân giải thấp. Tuỳ chọn&nbsp;<i>Web Page</i>&nbsp;sẽ giúp xuất ảnh gốc cùng phiên bản thu nhỏ của ảnh đó.&nbsp;</p><figure class="table"><table><tbody><tr><td><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat%206.png" alt="file Word,file PDF,lấy ảnh"></figure></td></tr><tr><td><i>Bạn chú ý lưu file .docx dưới dạng Web Page, không lưu dạng Web Page Filtered, nếu không chất lượng ảnh cho ra thậm chí còn tệ hơn.</i></td></tr></tbody></table></figure><p>Hệ thống sẽ lưu trang web ở 1 thư mục riêng (ví dụ như thư mục có tên Doc3_Files). Bạn mở thư mục này để xem toàn bộ các file trang web.&nbsp;</p><p>Image001.jpg là bức ảnh bạn chèn, còn tập tin Image002.jpg là phiên bản thumbnail của cùng ảnh đó.&nbsp;</p><p>Bây giờ, file ảnh chỉ còn kích thước 1.722 KB.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat%207.png" alt="file Word,file PDF,lấy ảnh"></figure><p>Kích cỡ ảnh cho trang web này là 5,983 x 7,98 inch.&nbsp;</p><p><strong>Giải pháp đổi đuôi .docx sang .zip</strong></p><p>Do bản thân định dạng doc.x của Word đã là file nén, bạn có thể đổi tên&nbsp;thành file mới có phần mở rộng .zip để trích xuất ảnh hay các thành phần khác. Lưu ý rằng phương pháp này không có tác dụng với hầu hết các định dạng file khác. &nbsp;</p><p>Sau khi chèn ảnh gốc 6,85 MB, bạn lưu file với tên DocAsZip.docx. Tiếp theo bạn đổi tên file từ DocAsZip.docx sang DocAsZip.zip.</p><p>Bạn click đúp vào DocAsZip.zip để mở file này cùng toàn bộ thư mục, thư mục phụ, và file được nén cùng nhau.&nbsp;</p><figure class="table"><table><tbody><tr><td><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat%208.png" alt="file Word,file PDF,lấy ảnh"></figure></td></tr><tr><td><i>Nếu đổi tên file .docx sang file .zip, bạn có thể trích xuất ảnh. Tuy nhiên, ảnh được trích xuất cũng bị giảm chất lượng so với ảnh gốc</i></td></tr></tbody></table></figure><p>Click vào thư mục&nbsp;<i>Media</i>. Tập tin có tên image.jpg (trong thư mục Media) chính là ảnh được trích xuất ra. Kích cỡ file lúc này là 2,43 MB, lớn hơn kích cỡ file trích xuất bằng lệnh&nbsp;<i>Save as Picture</i>. Tuy nhiên, kích cỡ ảnh lúc này lại nhỏ hơn, chỉ 4,763 x 6,35 inch. Độ phân giải vẫn được giữ nguyên 300 dpi. &nbsp;</p><figure class="table"><table><tbody><tr><td><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat%209.png" alt="file Word,file PDF,lấy ảnh"></figure></td></tr><tr><td><i>&nbsp;Phiên bản ảnh được trích xuất từ file .zip nhỏ hơn (so với ảnh gốc) ở cả kích cỡ file và kích cỡ ảnh, nhưng kích cỡ file của nó lớn hơn các cách nói trên.</i></td></tr></tbody></table></figure><p>Như vậy, cách này giúp bạn giữ được độ phân giải ảnh, tuy nhiên, kích cỡ ảnh và kích cỡ file bị giảm đi đáng kể. Để có được ảnh xuất ra gần tương đương kích cỡ gốc, bạn phải thử cách khác.&nbsp;</p><p>Tới đây, chúng ta thử tổng kết những gì vừa làm:&nbsp;</p><p>File ảnh gốc nặng 6,85 MB và độ phân giải 300 dpi cùng kích cỡ ảnh thực là 8,16 x 10,88 inch.</p><p>Phiên bản trích xuất từ lệnh&nbsp;<i>Save as Picture</i>&nbsp;giữ lại độ phân giải 300 dpi, nhưng kích thước ảnh giảm chỉ còn 5,983 x 7,98 inch, và kích cỡ file chỉ còn là 1,36 MB.</p><p>Khi lưu dưới dạng trang web, ảnh cho độ phân giải 300 dpi và kích thước ảnh là 5,983 x 7,98 inch, tuy nhiên, kích thước file nhỏ chỉ còn 1,722 KB.&nbsp;</p><p>Cuối cùng, file Zip (cũng giữ lại độ phân giải 300 dpi) cho kích cỡ ảnh nhỏ nhất (chỉ 4,763 x 6,35 inch) nhưng cho ra kích thước file lớn nhất trong 3 phương pháp với 2,43 MB. Dạng file Zip có thể cho ra kích cỡ ảnh nhỏ, nhưng kích cỡ file cho thấy chất lượng hình ảnh là tốt nhất.&nbsp;</p><p>Bạn cũng cần lưu ý rằng, file .JPG sử dụng thuật toán nén "tổn hao", có nghĩa là chất lượng ảnh bị giảm trong quá trình nén. Nói cách khác, mỗi lần file bị biến đổi hay chỉnh lại kích cỡ rồi được lưu lại, chất lượng ảnh sẽ giảm. Đó là lý do vì sao các phương pháp trích xuất ảnh khác nhau ở trên sẽ cho ra các kết quả khác nhau.&nbsp;</p><p><strong>Phương pháp copy và dán (paste)&nbsp;</strong></p><p>Cách này cho ra kết quả tệ nhất trong các cách trích xuất ảnh từ file Word. Dưới đây sẽ là giải thích sơ qua nếu bạn quan tâm, hoặc nếu không, bạn đơn giản chỉ cần nhớ là không dùng nó.&nbsp;</p><p>Sau khi chèn ảnh gốc vào file Word, bạn chọn vào ảnh rồi nhấn Ctrl + C để copy.&nbsp;</p><p>Mở 1 phần mềm đồ hoạ rồi nhấn Ctrl + V để dán.&nbsp;</p><p>Nhìn vào ảnh vừa dán bạn sẽ thấy, ở độ phân giải 300 dpi, kích cỡ ảnh bị giảm còn 2,08 x 2,773 inch, và kích cỡ file chỉ là 586 KB.&nbsp;</p><p><strong>Cách tốt nhất: Xuất ra file PDF</strong></p><p>Cách cuối cùng và cũng là tốt nhất để lấy ảnh từ file Word: Xuất (Export) file Word ra thành file PDF. Để làm điều này, bạn cần thực hiện theo các bước:&nbsp;</p><p>Tạo cỡ trang trong tài liệu Word là 1 inch hoặc lớn hơn (ở tất cả các bên), sau đó nhập/chèn ảnh. Ví dụ, với ảnh 8 x 10 inch, bạn hãy tạo tài liệu có kích cỡ 9 x 11 inch hoặc 10 x 12 inch. Tiếp theo, bạn thiết lập phần biên (margin) thành .5 cho tất cả các bên. Lưu ý rằng nếu bạn muốn trích xuất ảnh từ file Word mà người khác gửi cho mình, hãy bỏ qua bước này bởi bạn không thể can thiệp được vào các thiết lập như vừa nêu.&nbsp;</p><p>Chọn&nbsp;<i>File &gt; Export &gt; Create PDF</i>&nbsp;và click vào nút&nbsp;<i>Create PDF.</i></p><p>Word cung cấp cho bạn 1 tên file nhưng bạn có thể chọn tên khác theo ý mình. Sau khi điền tên, bạn click nút&nbsp;<i>Publish</i>.&nbsp;</p><figure class="table"><table><tbody><tr><td><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat%2010.png" alt="file Word,file PDF,lấy ảnh"></figure></td></tr><tr><td><i>Xuất file Word sang PDF để có được ảnh chất lượng tốt hơn.</i></td></tr></tbody></table></figure><p>Bây giờ bạn mở file PDF bằng 1 ứng dụng đồ hoạ như&nbsp;Adobe Photoshop, Corel PaintShop Pro, Corel Paint, hay thậm chí là Microsoft Paint.</p><p>Sau khi bạn chọn File &gt; Open và chọn file&nbsp;PDF, hầu hết các chương trình (như&nbsp;Photoshop) hiển thị 1&nbsp;dialog cho biết kích cỡ file ảnh (30,9 MB) và bề rộng (10 inch), chiều cao (12 inch), độ phân giải (300 pixels/inch), chế độ (RGB Color), và các thông tin khác. Bạn cần thiết lập độ phân giải thành 300, đổi Mode sang RGB color giúp tạo file có kích cỡ nhỏ hơn so với chế độ CMYK.</p>', N'#news', 5, CAST(N'2021-04-25T21:14:50.027' AS DateTime), NULL, 1, 1, 0, N'167cach-lay-anh-tu-file-word-cho-chat-luong-tot-nhat 3.png')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (7, N'Hướng dẫn xây dựng và dùng thư viện trong lập trình Android', 0, N'<p>Chào các bạn, việc các bạn tự tay code một dự án Android hoàn chính là khá khó nên việc dùng thêm những thư viện ở ngoài được một nhóm hay một người nào đó code sẵn là rất cần thiết. Sau khi tìm hiểu rõ về thư viện đó thì ta chỉ việc đưa vào rồi thực hiện theo code có sẵn là xong, đây là một công việc rất khuyến khích.</p><p>Bởi vì thủ thuật xử lý thư viện nhà một kĩ năng lập trình loại bậc cao, cũng có khá là ít tài liệu nhắc tới vấn đề này, do vậy sau đây mình sẽ tổng hợp một số kỹ năng xử lý thư viện do chính mình sưu tập được trong quá trình tìm hiểu về Android rất mong các bạn góp ý thêm.</p><p>&nbsp;</p><p><strong>1. Thư viện là gì?</strong></p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Thư viện (library) là một thuật ngữ gần hơn framework, &nbsp;nó là tập hợp những đoạn code do team nào đó hay ai đó đã viết sẵn ra với mục đích là thực hiện sẵn công việc dài dòng phức tạp để đạt kết quả như mong muốn.</p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ngày nay để viết ra được 1 ứng dụng có đầy đủ các chức năng thì bạn cần tìm hiểu thật nhiều thư viện khác nhau và gom chúng vào để đưa ra những gì mà bạn cảm thấy cần thiết vào ứng dụng của riêng mình.</p><p><strong>2. Các thủ thuật khi sử dụng thư viện trong&nbsp;lập trình android:</strong></p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Khởi tạo 1 thư viện</p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kiểm tra xem project hiện tại có phải là library hay không</p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Build Project là thư viện hiện tại thành 1 tập tin&nbsp;<i>.jar&nbsp;</i>để dùng nó trên các project khác</p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cách add 1 thư viện hiện tại vào 1 thư viện khác để kiểm tra kết quả.</p><p><strong>3. Chú ý:</strong></p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Vấn đề vi phạm bản quyền</p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nếu có thời gian khởi tạo 1 thư viện cho riêng mình thì hay đảm bảo nó bao gồm nhưng class java thôi nha, nếu có file XML thì sẽ hỏng đấy.</p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Code cần đơn giản và chính xác, tham khảo những người đi trước để rút ra kinh nghiệm.</p><p><strong>4. Video hướng dẫn:</strong></p><p>&lt;iframe width="870" height="150" src="https://www.youtube.com/embed/QNu-icI8hwQ" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen&gt;&lt;/iframe&gt;</p>', N'#news', 5, CAST(N'2021-04-25T21:16:36.767' AS DateTime), NULL, 1, 1, 0, N'7119_37_10_huong-dan-xay-dung-va-dung-thu-vien-trong-lap-trinh-android.jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (8, N'Làm thế nào để trở thành một lập trình viên Android', 0, N'<p><br>&nbsp;</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/hoc-lap-trinh-android-kiem-viec-lam-tot.jpg" alt="lập trình viên,android,làm gì"></figure><p>Tôi cần làm gì để trở thành lập trình viên Android?</p><p>Khi các ứng dụng di động ngày càng được sử dụng rộng rãi và cho phép người dùng có thể kết nối với nhau theo nhiều cách, thì công việc của các nhà phát triển ứng dụng ngày càng trở nên quan trọng trong một nền kinh tế toàn cầu. Các ứng dụng di động chúng ta sử dụng hàng ngày đã thay đổi cách chúng ta tiến hành kinh doanh, giao tiếp, giải trí và học thêm những điều mới. Bạn sẽ không sai nếu nghĩ rằng phát triển ứng dụng di động là một trong những ngành nghề thú vị nhất tại thời điểm này.</p><p>Vậy làm thế nào để bạn trở thành một nhà phát triển ứng dụng di động? Đây là một khung sườn kế hoạch: trước tiên bạn chọn một nền tảng - chẳng hạn&nbsp;Android,&nbsp;iOS, hoặc Windows Mobile - sau đó học các kỹ năng kỹ thuật, bổ sung thêm các kỹ năng mềm, và thế là đủ.</p><p>Nhưng chúng ta hãy đi vào một chi tiết nhỏ hơn. Ở đây, chúng ta sẽ bàn về cách để trở thành một nhà phát triển ứng dụng Android.</p><p>Tại sao lại chọn Android?</p><p>Android là hệ điều hành dẫn đầu không thể tranh cãi của thị phần smartphone toàn cầu. Nhờ sự tăng trưởng tại các thị trường mới nổi như Mexico, Thổ Nhĩ Kỳ và Brazil, sự thống trị này sẽ không suy giảm trong thời gian tới.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/hoc-lap-trinh-android-co-ban-den-nang-cao-24042016.jpg" alt="lập trình viên,android,làm gì"></figure><p>Việc dẫn đầu thị trường giúp đảm bảo số lượng công việc rất dồi dào cho các nhà phát triển ứng dụng Android.</p><p>Hơn nữa, nền tảng Android là mã nguồn mở (toàn bộ mã nguồn Android có thể xem&nbsp;tại đây, mặc dù có một số phần mềm độc quyền như Google Play), tạo ra một hệ sinh thái các nhà phát triển năng động. Các nhà phát triển Android chia sẻ lời khuyên, thủ thuật và hướng dẫn trên cộng đồng Android, và kể từ khi Google giúp các nhà phát triển bằng cách xây dựng các công cụ như&nbsp;Google Play Services&nbsp;cho những tác vụ ứng dụng phổ biến như đăng nhập, xác thực, vị trí (location) và lưu trữ, các nhà phát triển Android có thể tập trung vào việc xây dựng các chức năng cốt lõi cho ứng dụng của họ.</p><p>Về cơ bản, đây là một thời điểm đặc biệt thú vị để bắt đầu một sự nghiệp trong phát triển ứng dụng Android. Có một nguồn cung công việc rất dồi dào, nhu cầu đối với các ứng dụng Android hứa hẹn sẽ tăng cao trong tương lai, và công nghệ - bao gồm cả các ứng dụng wearable và ứng dụng cho TV - là rất hấp dẫn.</p><p>Nếu bạn muốn&nbsp;lập trình Android để kiếm tiền, hãy tham gia khóa học&nbsp;"Lập trình Android qua 10 ứng dụng thực tế"&nbsp;từ chuyên gia Nguyễn Bá Thành, CEO WePlay.,JSC - 5 năm khởi nghiệp lập trình mobile - Nổi tiếng với game Bắt Chữ (10 triệu lượt tải - 2014), Ứng dụng Lịch số 1 Việt Nam: Lịch Vạn Niên (5 triệu lượt tải).</p><p>Kỹ năng cứng: Nên học gì?</p><p>Trước tiên: bạn cần học các kỹ năng kỹ thuật. Việc phát triển Android có thể thực hiện trên máy tính Mac, Windows PC, hoặc Linux. Bạn cũng sẽ cần một thiết bị Android (bạn có thể sử dụng một emulator như&nbsp;Genymotion&nbsp;trong quá trình phát triển, nhưng cuối cùng bạn sẽ muốn test ứng dụng của mình trên một thiết bị thực). Dưới đây là danh sách ngắn các công cụ cần biết để trở thành một nhà phát triển Android.</p><p>Java<br>Kiến thức cơ bản nhất để phát triển ứng dụng Android là ngôn ngữ lập trình Java. Để trở thành một lập trình viên Android thành công, bạn sẽ cần phải quen thuộc với các khái niệm trong Java như vòng lặp, danh sách, biến và các cấu trúc điều khiển. Java là một trong những ngôn ngữ lập trình phổ biến nhất được sử dụng bởi các nhà phát triển phần mềm hiện nay, vì vậy việc thông thạo nó sẽ giúp bạn hoàn thành tốt công việc, thậm chí vượt ra ngoài nền tảng Android.</p><p>SQL<br>Bạn cũng sẽ cần phải tìm hiểu những kiến thức cơ bản của SQL để tổ chức cơ sở dữ liệu trong các ứng dụng Android. SQL là một ngôn ngữ để thực hiện các truy vấn lấy thông tin từ cơ sở dữ liệu. Một khi bạn có thể viết nó, thì sẽ không có bất kỳ câu hỏi nào mà bạn không thể truy vấn trong dữ liệu của mình.</p><p>Android Software Development Kit (SDK) và Android Studio<br>Một trong những phần hay nhất về phát triển cho Android đó là các công cụ cần thiết đều miễn phí và dễ dàng để có được.&nbsp;Android SDK&nbsp;có sẵn để bạn tải về miễn phí, cũng như&nbsp;Android Studio, môi trường phát triển tích hợp (IDE) chính thức cho việc phát triển ứng dụng Android. Android Studio là chương trình chính, nơi mà các nhà phát triển viết code và lắp ráp các ứng dụng của họ từ các gói và thư viện khác nhau. Android SDK bao gồm các đoạn code ví dụ, thư viện phần mềm, công cụ lập trình tiện dụng, và nhiều hơn nữa để giúp bạn xây dựng, kiểm thử, và gỡ lỗi các ứng dụng Android.</p><p>Một điểm nổi bật khác trong phát triển cho Android là sự dễ dàng của quá trình submit các ứng dụng. Một khi bạn đã sẵn sàng để submit ứng dụng của mình lên Google Play store, hãy đăng ký một tài khoản Google Play publisher (trong đó bao gồm một khoản lệ phí $25 đô-la qua Google Wallet), tuân theo&nbsp;Android’s launch checklist, submit thông qua Google Play Developer Console, chờ đợi Google phê duyệt, và thấy nó xuất hiện trên chợ ứng dụng. Thật đơn giản và thỏa mãn.</p><p>XML<br>Các lập trình viên sử dụng XML để mô tả dữ liệu. Những kiến thức cơ bản về cú pháp XML sẽ rất hữu ích trong cuộc hành trình của bạn để trở thành một nhà phát triển Android khi làm những công việc như thiết kế giao diện người dùng (UI) và phân tích dữ liệu lấy từ internet. Phần lớn những gì bạn cần làm với XML đều có thể được thực hiện thông qua Android Studio, nhưng nó tạo cho bạn nền tảng kiến thức về ngôn ngữ đánh dấu.</p><p>Kỹ năng cứng: Học như thế nào và cách tìm kiếm cơ hội việc làm</p><p>Tiếp xúc với các lập trình viên Android khác và các nhà tuyển dụng thông qua các buổi meetup, hội nghị như&nbsp;droidcon, và các mạng lưới như&nbsp;LinkedIn groups,&nbsp;Twitter chats, và&nbsp;Quora feeds.&nbsp;Bạn chẳng bao giờ biết được mình sẽ học được những gì, hoặc những người bạn sẽ gặp.</p><p>Kỹ năng mềm</p><p>Cũng như đối với bất kỳ công việc nào, việc chỉ có những năng lực về kỹ thuật là chưa đủ. Bạn phải nâng cao các kỹ năng giao tiếp của mình nhiều nhất có thể.</p><p>Kiên trì<br>Hãy thực hành cho thật hoàn hảo đến khi có thể phát triển ứng dụng thực sự. Chắc chắn bạn sẽ gặp phải những khó khăn trong quá trình phát triển, đặc biệt là khi mới bắt đầu. Bạn sẽ cần luyện cho mình một đức tính kiên trì để có thể vượt qua những giai đoạn nản lòng. May mắn thay, kể từ khi Android trở thành mã nguồn mở, các lập trình viên Android có thể tận dụng lợi thế của các thư viện và framework được tạo ra bởi cộng đồng đăng trên các trang web như&nbsp;GitHub.</p><p>Hợp tác<br>Hợp tác có tầm quan trọng sống còn đối với hầu hết công việc của các nhà phát triển. Ngay cả khi bạn đang làm việc một mình trên một dự án, bạn sẽ không tránh khỏi phải hợp tác với các designer, marketer, hoặc những người quản lý ở cấp cao hơn. Hãy cảm thấy thoải mái với việc chấp nhận phản hồi về công việc của bạn, ảnh hưởng với các đồng nghiệp, và hợp tác với những người khác để tạo ra sản phẩm đặc biệt.</p><p>Khao khát kiến thức<br>Tất cả các lập trình viên giỏi, dù cho trong lĩnh vực di động hay lĩnh vực khác, đều cam kết học tập suốt đời. Đặc biệt là trong bối cảnh phát triển nhanh chóng của các ứng dụng di động như hiện nay: cùng với sự ra đời của các thiết bị wearable, các ứng dụng TV, các ứng dụng tự động, và nhiều hơn nữa, các nhà phát triển di động phải luôn cập nhật những thay đổi và công nghệ mới cũng như các best practice. Không quan trọng việc bạn nhận được bao nhiêu, đừng bao giờ ngừng việc nghiên cứu, khám phá, vọc vậy, và đặt câu hỏi.</p><p>Kết luận</p><p>Ứng dụng di động đang có nhu cầu lớn hơn bao giờ hết, bởi vậy lúc này là thời điểm tuyệt vời nhất để phát triển sự nghiệp của bạn trở thành một lập trình viên Android. Và Android cũng ngày càng mở rộng vượt ra ngoài không gian truyền thống của người tiêu dùng trong lĩnh vực việc làm và giáo dục. Bạn còn chần chừ gì nữa? Chúc bạn thành công với quyết định của mình.</p>', N'#news', 5, CAST(N'2021-04-25T21:17:27.437' AS DateTime), NULL, 1, 1, 0, N'469_30_17_hoc-lap-trinh-android-co-ban-den-nang-cao-24042016.jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (9, N'Cách khắc phục khi có thông báo "Screen overlay detected"', 0, N'<p>Khi đang sử dụng điện thoại&nbsp;Android, đôi khi bạn thấy thông báo như sau "Screen overlay detected". Thông báo này xuất hiện chủ yếu khi bạn đang nhấn chấp thuận permission hay khi chuẩn bị cài file APK thủ công. Hướng dẫn trên thông báo lại quá sơ sài nên phần lớn chúng ta không biết phải làm gì tiếp theo. Đừng lo, cách làm ngay bên dưới, và cũng không phức tạp gì cả.<br><br>Ý nghĩa của thông báo này:<br><br>Trong Android, Google hỗ trợ một chức năng tên là&nbsp;Screen Overlay. Nó cho phép một app xuất hiện bên trong những app khác. Ví dụ, nút Chat Head của Facebook sử dụng Screen Overlay để có thể trôi nổi trên màn hình dù cho bạn có đang mở app nào đi nữa. Các app trên Play Store hoặc phần mềm cài sẵn từ các hãng sản xuất có tính năng thu nhỏ cửa sổ cũng dùng Screen Overlay để hoạt động, chẳng hạn như Multi View của Samsung.<br><br>Tính năng này hay, nhưng Google lo ngại rằng nó có thể bị kẻ xấu lợi dụng để lén chấp thuận permission hoặc lén cài app mà bạn không chú ý. Do đó, Android sẽ hiển thị một thông báo cảnh báo lên cho bạn biết và bạn cần vô hiệu hóa Screen Overlay để có thể tiếp tục cài app mong muốn.<br><br>Cách vô hiệu hóa Screen Overlay:</p><ol><li>Vào Settings &gt; Apps</li><li>Nhấn vào biểu tượng&nbsp;bánh răng&nbsp;ở góc trên bên phải, hoặc nếu không có thì ấn biểu tượng&nbsp;ba dấu chấm&nbsp;&gt; Configure Apps</li><li>Chọn vào "Draw over other apps" (nếu không thấy, bạn có thể chọn Advanced &gt; Draw over other apps)</li><li>Ở đây bạn sẽ có một danh sách các app có thể xuất hiện bên trên những app khác, chính là tính năng Screen Overlay đấy.</li><li>Tạm thời tắt những ứng dụng nào mà bạn nghi ngờ là thủ phạm. App đó thường được chạy lên trước khi bạn cài file APK hay chấp thuận permission nên cũng dễ xác định. Ví dụ: trước khi mình cho phép permission truy cập vào ổ cứng mình đã chạy Facebook Messenger. Vậy thì tắt Screen Overlay của Messenger đi.</li><li>Quay trở lại làm cho xong việc khi nãy của bạn rồi bật lại Screen Overlay cho Messenger.</li></ol><p>Từ những lần sau trở đi, bạn có thể lưu ý tắt app Screen Overlay này trước khi cho phép permission hay cài file APK là sẽ không còn bị nữa.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Tat_screen_overlay_Android.jpg" alt="thủ thuật,android,screen overlay"></figure>', N'#news', 5, CAST(N'2021-04-25T21:18:07.437' AS DateTime), NULL, 1, 1, 0, N'599_23_44_Tat_screen_overlay_Android.jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (10, N'Sự thực về tin đồn Windows 10 sắp tới sẽ chặn game thủ dùng crack', 0, N'<h2><strong>Có vẻ sau nhiều năm “đường ai nấy đi” thì Microsoft đã “quay lại đi theo” Apple ở bản cập nhật lớn sắp tới của Windows 10.</strong></h2><p>Ngay sau khi Microsoft tung ra phiên bản Windows 10 Insider Build 15046 vào ngày hôm qua thì trên một số trang tin công nghệ đã xuất hiện "tin đồn" về việc Microsoft sẽ thiết lập Windows 10 ngăn chặn hoàn toàn việc cài đặt và khởi chạy các phần mềm được xây dựng trên nền tảng Win32.</p><p>Điều này đã làm cho cộng đồng người dùng, nhất là các game thủ đam mê các tựa game "bom tấn" nhưng không có khả năng chi trả bản quyền game hay người dùng "lậu" phần mềm thường dùng đến các công cụ bẻ khóa (crack - vốn thường được xây dụng trên nền tảng Win32) phải hoang mang.</p><p><strong>Tuy nhiên, theo tìm hiểu thì đây chỉ là một lựa chọn mới cho phép người dùng ngăn chặn việc cài đặt các phần mềm Win32 trên hệ thống, bạn có thể tắt nó đi nếu muốn.</strong></p><p><strong>Nói một cách dễ hiểu thì trong bản cập nhật Windows 10 sắp tới, đây là hệ thống giám sát chặt chẽ hơn việc tải và cài đặt các ứng dụng từ bên ngoài, và nếu xác định các ứng dụng phần mềm này là của "nhà phát triển không xác định", hệ thống sẽ ngăn chặn việc cài đặt và khởi chạy chúng.</strong></p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/su-thuc-ve-tin-don-windows-10-sap-toi-se-chan-game-thu-dung-crack(1).jpg" alt="windown 10,thủ thuật,win10 chặn crack"></figure><p>Thông báo ngăn chặn việc cài đặt phần mềm trên Windows 10 Insider Preview Build 15046.</p><p>Cụ thể, khi được kích hoạt, tính năng này sẽ hiển thị thông báo có nội dung rằng người dùng chỉ có thể cài đặt ứng dụng được cung cấp thông qua Windows Store, kèm theo đó là nhắc nhở việc hạn chế việc cài đặt ứng dụng từ bên ngoài sẽ giúp máy tính của bạn an toàn và đáng tin cậy hơn. Nhưng bên cạnh đó, hệ thống cũng cung cấp cho người dùng lựa chọn đi đến việc thay đổi thiết lập trong System &gt; Apps &amp; features với 3 lựa chọn sau, trong đó có lựa chọn cho phép người dùng cài đặt và sử dụng ứng dụng phần mềm Win32 từ bên ngoài.</p><p>- Allow apps from anywhere. (Cho phép cài đặt và sử dụng ứng dụng từ bên ngoài).</p><p>- Prefer apps from the Store but allow apps from anywhere (prompt with install anyway). (Ưu tiên ứng dụng từ Store nhưng vẫn cho phép cài đặt và sử dụng ứng dụng từ bên ngoài - mỗi lần cài phải xác nhận lại).</p><p>- Allow apps from the Store only. (Chỉ cho phép cài đặt và sử dụng ứng dụng từ Store).</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/su-thuc-ve-tin-don-windows-10-sap-toi-se-chan-game-thu-dung-crack.jpg" alt="windown 10,thủ thuật,win10 chặn crack"></figure><p>Tuy nhiên, có một điều cần lưu ý là tính năng này chỉ mới được thêm vào trong phiên bản Windows 10 Insider Build 15046. Do đó, chưa thể xác định được sự hiện diện của tính năng này ở bản cập nhật chính thức được phát hành vào tháng 04/2017 tới. Thêm nữa, mặc định tính năng sẽ không được kích hoạt, nên không có lí do gì rõ ràng vì sao Microsoft lại bổ sung nó vào bản cập nhật chính thức sắp tới.</p><p>Mặc dù vậy, có thể thấy đây là một tính năng khá hay vì nó cho phép quản trị viên hệ thống có thể ngăn chặn việc người dùng “lỡ” cài đặt phải phần mềm độc hại, gây ảnh hưởng khả năng bảo mật dữ liệu của hệ thống.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/su-thuc-ve-tin-don-windows-10-sap-toi-se-chan-game-thu-dung-crack%203.jpg" alt="windown 10,thủ thuật,win10 chặn crack"></figure><p>Ở&nbsp;bài viết nói về Windows 10 Cloud&nbsp;trước đó, chúng ta cũng đã nói qua về việc Microsoft đã ngăn chặn hoàn toàn việc cài đặt và khởi chạy các ứng dụng bên ngoài Windows Store. Tuy nhiên, hãng cũng cung cấp cho người dùng 2 lựa chọn để có thể sử dụng các ứng dụng Universal, đó là “Allow apps from the Store only” (chỉ đồng ý cho phép sử dụng các ứng dụng từ Store) và “Allow apps from anywhere” (cho phép sử dụng các ứng dụng từ bên ngoài), thể hiện việc Microsoft sẽ “mở cửa” cho các nhà phát triển ứng dụng “tha hồ” cài đặt và khởi chạy các ứng dụng “chợ đen” trên Windows 10 Cloud.</p><p>Tóm lại, việc thêm hay không thêm lựa chọn này vào bản cập nhật sắp tới cũng không ảnh hưởng nhiều đến việc người dùng “tự do” trong việc cài đặt và sử dụng phần mềm từ bên ngoài (hay còn gọi là các phần mềm Win32).</p><p>Nhưng có thể thấy Microsoft đã bắt đầu quan tâm đến “hướng đi” của Apple đã xác định cho macOS, cụ thể là việc kiểm soát các ứng dụng cài đặt trên hệ thống.</p><p>Chúng ta hãy cùng chờ xem tiếp những thay đổi nào sắp xuất hiện trên Windows 10 Creators Update ở các bản Insider Build sắp tới nhé.</p>', N'#news', 5, CAST(N'2021-04-25T21:19:35.727' AS DateTime), NULL, 1, 1, 0, N'647su-thuc-ve-tin-don-windows-10-sap-toi-se-chan-game-thu-dung-crack(1).jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (11, N'Hướng dẫn chèn Facebook Author Tag trong WordPress', 0, N'<p>Cùng với nhiều dịch vụ tiện ích mà Facebook cho phép chúng ta nhúng vào website như Comment, Likebox hay đơn giản như nút Share hoặc like bài viết, thì gần đây Facebook lại cung cấp thêm dịch vụ Author Tag. Đây không phải là một tính năng mới gì, nhưng gần đây nó được cập nhật cho phép Facebook &nbsp;tag bài viết được chia sẻ trên mạng xã hội này với thông tin author’s Facebook profile.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Huong%20dan%20chen%20Facebook%20Author%20Tag%20trong%20WordPress%201.jpg" alt="Author Tag, wordpress tips, thu thuat wordpress, wordpress tips, wordpress"></figure><p>Để bắt đầu, chúng ta sẽ cần chèn thêm một thẻ input cho phép tác giả chèn thêm đường dẫn Facebook profile URL.<br>Mở file&nbsp;<strong>functions.php</strong>&nbsp;của theme mà các bạn đang dùng, rồi chèn thêm đoạn code sau.</p><p>function facebook_profile_url($profile_fields) {

 &nbsp; &nbsp;$profile_fields[''facebook_url''] = ''Facebook URL'';

 &nbsp; &nbsp;return $profile_fields;

}

add_filter(''user_contactmethods'', ''facebook_profile_url'');</p><p>Đoạn code trên sẽ chèn thêm một trường nhập liệu vào bên dưới &nbsp;“Contact Info”. Giờ thì các bạn chỉ cần nhập thêm facebook URL là được, ví dụ như&nbsp;<strong>https://www.facebook.com/zuck</strong>&nbsp;.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Huong%20dan%20chen%20Facebook%20Author%20Tag%20trong%20WordPress%202.jpg" alt="Author Tag, wordpress tips, thu thuat wordpress, wordpress tips, wordpress"></figure><p>Bây giờ, chúng ta sẽ cần xuất URL ra bên ngoài bên trong thẻ head của theme. Để làm được điều này, thì các bạn chèn thêm đoạn code sau bên trong file&nbsp;<strong>functions.php</strong>&nbsp;.</p><p>function facebook_author_tag() {

 &nbsp; &nbsp;if ( is_single() ) {

 &nbsp; &nbsp; &nbsp; &nbsp;global $post;

 &nbsp; &nbsp; &nbsp; &nbsp;$author = (int) $post-&gt;post_author;

 &nbsp; &nbsp; &nbsp; &nbsp;$facebook_url = get_the_author_meta( ''facebook_url'', $author );

 &nbsp; &nbsp; &nbsp; &nbsp;if ( ! empty( $facebook_url ) ) {

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;echo ''&lt;meta property="article:author" content="''. $facebook_url .''" /&gt;'';

 &nbsp; &nbsp; &nbsp; &nbsp;}

 &nbsp; &nbsp;}

}

add_action( ''wp_head'', ''facebook_author_tag'', 8 );</p><p>Nếu thành công, các bạn sẽ thấy thông tin URL xuất hiện như thế này.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Huong%20dan%20chen%20Facebook%20Author%20Tag%20trong%20WordPress%203.jpg" alt="Author Tag, wordpress tips, thu thuat wordpress, wordpress tips, wordpress"></figure><p>&nbsp;Nếu các bạn không hiểu gì về code thì có thể sử dụng plugin&nbsp; <strong>Yoast SEO</strong>.&nbsp;Đây là một plugin giúp các bạn tối ưu hóa website của các bạn cả về tìm kiếm trên Google cũng như trên mạng xã hội Facebook. Ngay khi các bạn cài đặt plugin này xong , thì các bạn sẽ thấy có một dòng input như &nbsp;“<strong>Facebook Profile URL</strong>” và chèn đường dẫn vào là xong.</p>', N'#news', 5, CAST(N'2021-04-25T21:20:35.587' AS DateTime), NULL, 1, 1, 0, N'667Huong dan chen Facebook Author Tag trong WordPress 1.jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (12, N'Phát hiện địa chỉ người dùng với PHP', 0, N'<p>Các bạn sử dụng đoạn script sau sẽ có thể lấy chính xác địa chỉ thành phố mà người dùng truy cập vào website hay blog của các bạn. Tùy theo mục đích sử dụng mà đoạn script này sẽ rất hữu ích cho các bạn.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Phat%20hien%20dia%20chi%20nguoi%20dung%20voi%20PHP%201.jpg" alt="code Snipppets, php code, thu thuat php, hoc php, php co ban"></figure><p>function detect_city($ip) {

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp; &nbsp; &nbsp;$default = ''UNKNOWN'';



 &nbsp; &nbsp; &nbsp; &nbsp;$curlopt_useragent = ''Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2) Gecko/20100115 Firefox/3.6 (.NET CLR 3.5.30729)'';

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp; &nbsp; &nbsp;$url = ''http://ipinfodb.com/ip_locator.php?ip='' . urlencode($ip);

 &nbsp; &nbsp; &nbsp; &nbsp;$ch = curl_init();

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp; &nbsp; &nbsp;$curl_opt = array(

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CURLOPT_FOLLOWLOCATION &nbsp;=&gt; 1,

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CURLOPT_HEADER &nbsp; &nbsp; &nbsp;=&gt; 0,

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CURLOPT_RETURNTRANSFER &nbsp;=&gt; 1,

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CURLOPT_USERAGENT &nbsp; =&gt; $curlopt_useragent,

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CURLOPT_URL &nbsp; &nbsp; &nbsp; =&gt; $url,

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CURLOPT_TIMEOUT &nbsp; &nbsp; &nbsp; &nbsp; =&gt; 1,

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CURLOPT_REFERER &nbsp; &nbsp; &nbsp; &nbsp; =&gt; ''http://'' . $_SERVER[''HTTP_HOST''],

 &nbsp; &nbsp; &nbsp; &nbsp;);

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp; &nbsp; &nbsp;curl_setopt_array($ch, $curl_opt);

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp; &nbsp; &nbsp;$content = curl_exec($ch);

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp; &nbsp; &nbsp;if (!is_null($curl_info)) {

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$curl_info = curl_getinfo($ch);

 &nbsp; &nbsp; &nbsp; &nbsp;}

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp; &nbsp; &nbsp;curl_close($ch);

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp; &nbsp; &nbsp;if ( preg_match(''{



&lt;li&gt;City : ([^&lt;]*)&lt;/li&gt;





}i'', $content, $regs) ) &nbsp;{

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$city = $regs[1];

 &nbsp; &nbsp; &nbsp; &nbsp;}

 &nbsp; &nbsp; &nbsp; &nbsp;if ( preg_match(''{



&lt;li&gt;State/Province : ([^&lt;]*)&lt;/li&gt;





}i'', $content, $regs) ) &nbsp;{

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$state = $regs[1];

 &nbsp; &nbsp; &nbsp; &nbsp;}



 &nbsp; &nbsp; &nbsp; &nbsp;if( $city!='''' &amp;&amp; $state!='''' ){

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$location = $city . '', '' . $state;

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return $location;

 &nbsp; &nbsp; &nbsp; &nbsp;}else{

 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return $default;

 &nbsp; &nbsp; &nbsp; &nbsp;}

 &nbsp; &nbsp; &nbsp; &nbsp; 

 &nbsp; &nbsp;}</p><p>Và để sử dụng, các bạn chỉ cần viết thêm đoạn code như sau:</p><p>&lt;?php $ip = $_SERVER[''REMOTE_ADDR'']; $city = detect_city($ip); echo $city; ?&gt;</p>', N'#news', 5, CAST(N'2021-04-25T21:21:39.563' AS DateTime), NULL, 1, 1, 0, N'528Phat hien dia chi nguoi dung voi PHP 1.jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (13, N'Bí quyết hiển thị ảnh đại diện lên kết quả tìm kiếm của google', 0, N'<p>Sau khi google xóa bỏ ảnh tác giả trên kết quả tìm kiếm, rất nhiều người đã cảm thấy “nuối tiếc” nhưng để bù đắp “mất mát” đó google lại cho phép hiển thị ảnh mô tả của bài viết .</p><h2>Dưới đây mình xin chia sẻ với các bạn cách để hiển thị hình ảnh trên kết quả tìm kiếm của google</h2><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Bi%20quyet%20hien%20thi%20anh%20dai%20dien%20len%20ket%20qua%20tim%20kiem%20cua%20google%201.jpg" alt="ky thuat SEO, hoc SEO, SEO tips, cai thien website, Twitter"></figure><p><br><i>Ảnh đại diện có sức hấp dẫn không kém ảnh tác giả</i></p><p>Trong kết quả này có 2 thông tin mà mình có thể hiển thị được:&nbsp;<strong>ảnh đại diện và phiếu đánh giá</strong>.Để hiển thị ảnh đại diện bạn hoàn toàn có thể làm được trên bất cứ website nào , còn phiếu đánh cần có sự can thiệp vào code từ người&nbsp;<strong>thiết kế website</strong></p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Đăng nhập&nbsp;<a href="https://www.google.com/webmasters/"><strong>webmaster tools</strong></a></p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; “<i>Giao diện tìm kiếm</i>”</p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; “<i>Công cụ đánh dấu dữ liệu</i>&nbsp;“</p><p>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; “<i>Bắt đầu đánh dấu dữ liệu</i>”</p><h3>Bước 1 . Đánh dẫu dữ liệu</h3><p>Bạn nhập url cần đánh dấu , lựa chọn loại dữ liệu : bài viết , sự kiện , sản phẩm ...cho phù hợp .</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Bi%20quyet%20hien%20thi%20anh%20dai%20dien%20len%20ket%20qua%20tim%20kiem%20cua%20google%202.jpg" alt="ky thuat SEO, hoc SEO, SEO tips, cai thien website, Twitter"></figure><p><br><i>Bắt đầu đánh dấu dữ liệu</i></p><p>Url mình đang đánh dấu là Sự Kiện ( Lưu ý những loại dữ liệu khác cũng làm tương tự )Ở 2 ô lựa chọn bên dưới, nên&nbsp;<strong>chọn cái mặc định đầu tiên</strong>&nbsp;để Google sẽ lấy đó làm mẫu, tự động gắn thẻ cho các page tương tự mà nó tìm được. Nhấn ok, sau đó sẽ được như thế này:</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Bi%20quyet%20hien%20thi%20anh%20dai%20dien%20len%20ket%20qua%20tim%20kiem%20cua%20google%203(1).jpg" alt="ky thuat SEO, hoc SEO, SEO tips, cai thien website, Twitter"></figure><p><i>Các thuộc tính của kiểu dữ liệu</i></p><p>&nbsp; Ở đây có một số các thuộc tính như : Tên sự kiện , thời điểm bắt đầu , kết thúc ,…. Để đánh dấu được bạn chỉ cần bôi đen giá trị của thuộc tính ,nhả chuột ra sẽ tự nó hiện lên bảng mục cần đánh giá.</p><p>Sau khi hoàn thành các thuộc tính bạn sẽ chuyển đến bước 2</p><h3>Bước 2: Tạo nhóm trang</h3><p>Bước này là “<strong>gắn thẻ cho trang mẫu khác</strong>”, Có nghĩa là những page nào có cùng cấu trúc sẽ được đánh dấu tương tự như Page trên bạn vừa đánh dấu .Nếu không có page nào có cấu trúc tương tự , thì việc đánh dấu sẽ hoàn thành.</p><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Bi%20quyet%20hien%20thi%20anh%20dai%20dien%20len%20ket%20qua%20tim%20kiem%20cua%20google%204.jpg" alt="ky thuat SEO, hoc SEO, SEO tips, cai thien website, Twitter"></figure><p><i>Nhóm trang có cùng cấu trúc</i></p><p>Sau bước này đến bước cuối là “<strong>xuất bản</strong>”,hoàn thành xuất bản , bạn chỉ việc ngồi chờ GOOGLE update.</p>', N'#news', 5, CAST(N'2021-04-25T21:22:59.690' AS DateTime), NULL, 1, 1, 0, N'857Bi quyet hien thi anh dai dien len ket qua tim kiem cua google 1.jpg')
INSERT [dbo].[News] ([news_id], [news_name], [news_view], [news_content], [news_tag], [user_id], [news_datecreate], [news_dateupdate], [news_active], [news_option], [news_del], [news_img]) VALUES (14, N'Tăng cường Seo website của bạn với Google+', 0, N'<p>Bảng xếp hạng tìm kiếm rất quan trọng với sự thành công của bất cứ website nào. Có rất nhiều cách để giúp website của bạn bay lên top của các công cụ tìm kiếm. Tuy nhiên rất nhiều người đã bỏ qua tầm quan trọng của&nbsp;<strong>Google Plus</strong>. Khi bạn sở hữu một doanh nghiệp nhỏ có website riêng hoặc Blog và bạn muốn trang web của mình hiển thị đầu trên các trang tìm kiếm và Google&nbsp;+ sẽ giúp bạn cải thiện thứ hạng của bạn nhanh chóng.&nbsp;</p><p>Danh sách những điều cần phải làm để đảm bảo rằng bạn tận dụng tối đa tính năng của trang google+.</p><h2><strong>&nbsp;Google&nbsp;+ dành cho tìm kiếm.</strong></h2><figure class="image"><img src="https://sharecode.vn/FilesUpload/News/images/Tang%20cuong%20Seo%20website%20cua%20ban%20voi%20Google%201.jpg" alt="ky thuat SEO, hoc SEO, cai thien website, Google+, SEO tips"></figure><p><i>Lợi ích từ Google+ cho website</i></p><p>Google&nbsp;+ là một công cụ mạnh để giúp bạn tối ưu hoá công cụ tìm kiếm của bạn, là một công cụ tuyệt vời cho&nbsp;<strong>Seo</strong>&nbsp;là do liên kết DoFollow cực kỳ chất lượng.&nbsp;</p><p><strong>- Tối ưu thông tin</strong>.</p><p>Bạn phải đảm bảo rằng đã tối ưu hoá thông tin của bạn từ Google&nbsp;+. Dưới đây là 5 cách giúp bạn chỉnh sửa hồ sơ và trang web kinh doanh để xây dựng một chiến lược Seo mạnh mẽ.</p><p><strong>+ Tiêu đề</strong>: nên là tên công ty bạn nếu bạn đang có nhồi nhét từ khoá vào đây thì sẽ không có giá trị gì vì nó không có giá trị gì cho Seo cả.</p><p><strong>+ Tuỳ chỉnh URL</strong>: Bạn có thể thiết lập Url riêng cho bạn. Cũng như tạo các liên kết đến từ khoá của bạn. Đây chính là cơ hội để bạn chèn từ khoá và kiến những link Dofolow chất lượng cho website của mình.&nbsp;</p><p><strong>+ Mô tả</strong>: Sau khẩu hiệu của doanh nghiệp thì phần mô tả rất quan trọng. Đây là nơi bạn nên sử dụng các từ khoá có liên quan đến doanh nghiệp của bạn trong nội dung chia sẻ. Google+ giúp bạn có thể thoả thích chia sẻ giới thiệu về doanh nghiệp cũng như chèn các từ khoá quan trọng trong website của mình. Vì thế đừng bỏ qua những tiện ích mở mà Google+ mang lại cho Seo.</p><p><strong>+ Content</strong>: Sau khi trang Google của bạn được tối ưu và các liên kết đến website đã được thiết lập hoàn hảo thì bạn có thể gửi nội dung chia sẻ lên trên đó.&nbsp;</p><p>Chia sẻ nội dung lên 1 cách ngắn gọn và súc tích cùng với các liên kết về trang website của bạn và hãy nhớ luôn đặt các liên kết trong khu vực đính kèm các liên kết nhé,bạn sẽ thấy lợi ích mà nó đem lại.</p><p><strong>+ Theo dõi thống kê:</strong>&nbsp;Sau khi tối ưu tất cả về bản thân doanh nghiệp, chia sẻ những nội dung chất lượng. Bạn có thể chỉ định một liên kết tùy chỉnh cho mỗi URL và theo dõi các số liệu thống kê của trang cụ thể.&nbsp;Bạn có thể mở rộng phân tích và đo lường kết quả với nhiều công cụ mà Google+ cung cấp.</p><p>Google+ là một công cụ tuyệt vời để sử dụng cho SEO. Tối ưu hóa trang hồ sơ của bạn và gửi những nội dung chất lượng, cuối cùng là theo dõi và đánh giá kết quả đạt được. Những biện pháp này chắc chắn sẽ giúp bạn nâng cao thứ hạng SEO của bạn.</p><p>&nbsp;Để hiểu rõ hơn về quá trình làm và thực hành trên Google + bạn có thể tham gia các&nbsp;<strong>khoa hoc seo</strong>&nbsp;tại iNET để giúp quá trình Seo website của bạn hiệu quả hơn.&nbsp;</p>', N'#news', 5, CAST(N'2021-04-25T21:24:20.707' AS DateTime), NULL, 1, 1, 0, N'666Tang cuong Seo website cua ban voi Google 1.jpg')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([oder_id], [user_id], [id_coder], [oder_datecreate], [code_id]) VALUES (12, 6, 5, CAST(N'2021-03-29T14:44:25.437' AS DateTime), 18)
INSERT [dbo].[Orders] ([oder_id], [user_id], [id_coder], [oder_datecreate], [code_id]) VALUES (13, 6, 5, CAST(N'2021-03-29T14:45:12.273' AS DateTime), 18)
INSERT [dbo].[Orders] ([oder_id], [user_id], [id_coder], [oder_datecreate], [code_id]) VALUES (15, 6, 5, CAST(N'2021-03-29T14:57:05.280' AS DateTime), 15)
INSERT [dbo].[Orders] ([oder_id], [user_id], [id_coder], [oder_datecreate], [code_id]) VALUES (16, 6, 1, CAST(N'2021-03-30T08:25:32.497' AS DateTime), 23)
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
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (8, 120, NULL, 2)
SET IDENTITY_INSERT [dbo].[Pakages] OFF
GO
SET IDENTITY_INSERT [dbo].[TakePrices] ON 

INSERT [dbo].[TakePrices] ([tp_id], [user_id], [tp_coin], [tp_datecreate], [tp_note], [tp_active], [tp_accountnumber], [tp_customer], [tp_momo]) VALUES (11, 3, 68, CAST(N'2021-03-29T22:40:45.227' AS DateTime), NULL, 2, N'111', N'aqs', N'0924404019')
INSERT [dbo].[TakePrices] ([tp_id], [user_id], [tp_coin], [tp_datecreate], [tp_note], [tp_active], [tp_accountnumber], [tp_customer], [tp_momo]) VALUES (12, 3, 68, CAST(N'2021-03-29T22:47:31.983' AS DateTime), NULL, 2, N'323232323232', N'asasafsaf', N'0924404019')
INSERT [dbo].[TakePrices] ([tp_id], [user_id], [tp_coin], [tp_datecreate], [tp_note], [tp_active], [tp_accountnumber], [tp_customer], [tp_momo]) VALUES (13, 6, 200, CAST(N'2021-03-30T07:22:26.690' AS DateTime), NULL, 1, N'323232323232', N'qsas', N'0929273009')
SET IDENTITY_INSERT [dbo].[TakePrices] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (1, N'huynhminhtan4019@gmail.com', N'0924404019', 0, CAST(N'2021-03-25T16:29:11.193' AS DateTime), N'338aa56e-9786-4784-9902-64ca046432e6', 2, N'Tấn huỳnh', 339, CAST(N'2021-03-25T16:29:11.193' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'0924404019', N'c2e91d27-3660-40ad-8e8a-0e043b973399LDR6AWn.png')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (3, N'vuongbaot@gmail.com', N'0924404019', 0, CAST(N'2021-03-25T16:29:11.193' AS DateTime), N'f9558345-42c1-43f7-9cdd-38c67986ec91', 2, N'aaaa', 68, CAST(N'2021-03-26T19:13:22.103' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, N'Tôi thích code webste', NULL, 0, NULL, N'123456', N'04f5d6d3-bca9-41e9-b892-427f528f61a2.jpg')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (5, N'trantran@gmail.com', N'0929273009', 1, CAST(N'1999-11-11T00:00:00.000' AS DateTime), N'87032592-0d90-44d8-bef3-5e45f34e4927', 2, N'Trân', 296, CAST(N'2021-03-29T11:53:00.000' AS DateTime), CAST(N'2021-04-09T21:47:12.080' AS DateTime), N'#Music_Admin', 1, 1, 0, N'chơi', NULL, 0, NULL, N'123456', N'470bg-tab.png')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (6, N'vuongbaotran@gmail.com', NULL, NULL, NULL, N'a0e1db71-8a5f-46f6-a197-3bdf3821b0b4', 2, N'Trân', 878, CAST(N'2021-03-29T13:54:05.687' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'123456', N'6fda6015-d4b0-46ff-8c7f-99456c0e9ace[[flutter]---share-code-ui-facebook-152717.jpg')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (7, N'tranvuong@gmail.com', NULL, NULL, NULL, N'd2a25e84-65c3-4e97-b726-77751b432032', 2, N'Tran Vuong', 0, CAST(N'2021-03-29T14:00:46.530' AS DateTime), NULL, N'#Music_Admin', 1, 1, 1, NULL, NULL, 0, NULL, N'123456', NULL)
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (8, N'th@gmail.com', NULL, NULL, NULL, N'c01ab575-79cb-4b07-b055-0af41780392a', 2, N'Tan Heo', 0, CAST(N'2021-03-29T14:23:17.610' AS DateTime), NULL, N'#Music_Admin', 2, 0, 1, NULL, NULL, 0, NULL, N'123456', NULL)
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (9, N'vuongbaot1905@gmail.com', N'0869139879', 0, CAST(N'1999-07-02T00:00:00.000' AS DateTime), N'e4a9a1a8-43ce-4deb-afbd-e6091d238193', 2, N'Vương Bảo Trân', 0, CAST(N'2021-04-09T20:06:13.930' AS DateTime), NULL, N'#admin', 1, 1, 1, N'code dạo', NULL, 0, NULL, N'123456', NULL)
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (11, N'tran@gmail.com', N'+84869139879', 0, CAST(N'1999-07-02T00:00:00.000' AS DateTime), N'ac44cea0-a615-4d02-8cad-69cb2e0adf67', 1, N'Trân', 0, CAST(N'2021-04-09T20:14:34.333' AS DateTime), NULL, N'#admin123', 1, 1, 0, N'coder', NULL, 0, NULL, N'1234567', N'877bg.jpg')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (14, N'trantran@gmail.com', N'0929273009', 0, CAST(N'1999-12-02T00:00:00.000' AS DateTime), N'1d88414b-de7d-43e8-8357-44fc597e6e29', 2, N'Trân', 0, CAST(N'2021-04-09T21:05:25.313' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'123456', N'653bg-tab.png')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (15, N'trantran@gmail.com', N'0929273009', 0, CAST(N'1999-11-11T00:00:00.000' AS DateTime), N'8f29fce3-0b05-43ff-a4c2-81ea753b86b0', 2, N'Trân Vương', 22, CAST(N'2021-04-09T21:07:37.000' AS DateTime), CAST(N'2021-04-09T21:46:25.387' AS DateTime), N'@code', 1, 1, 0, N'code', NULL, 0, NULL, N'123456', N'337bg-info.jpg')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (18, N'a@gmail.com', N'0929273009', 1, CAST(N'1999-11-11T00:00:00.000' AS DateTime), N'5e4b823e-fcf1-4b78-ba09-977a14b7ff44', 1, N'Vuong Bao Tran', 22, CAST(N'2021-04-09T21:13:27.607' AS DateTime), NULL, N'#admin', 1, 1, 1, N'code dạo', NULL, 0, NULL, N'1234567', N'616do-an-quan-li-nhap-xuat-kho-winformmvc-entity-framework-sql-server-code-phan-mem-quan-ly-code-phan-mem-quan-ly-code-phan-mem-quan-ly-94018.jpg')
INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass], [user_img]) VALUES (20, N'trantran@gmail.com', N'0929273009', 0, CAST(N'2010-02-22T00:00:00.000' AS DateTime), N'13798663-ac25-411a-9700-b27ae0fc4d8d', 2, N'Trân Vương', 0, CAST(N'2021-04-09T21:36:40.313' AS DateTime), NULL, N'#Music_Admin', 1, 1, 1, N'coder', NULL, 0, NULL, N'123456', N'333auto-chess-unity-game-template-18415.jpg')
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
/****** Object:  StoredProcedure [dbo].[SqlQueryNotificationStoredProcedure-873337c4-0214-4de6-8584-e8d27a238687]    Script Date: 27/04/2021 12:34:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SqlQueryNotificationStoredProcedure-873337c4-0214-4de6-8584-e8d27a238687] AS BEGIN BEGIN TRANSACTION; RECEIVE TOP(0) conversation_handle FROM [SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687]; IF (SELECT COUNT(*) FROM [SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687] WHERE message_type_name = 'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer') > 0 BEGIN if ((SELECT COUNT(*) FROM sys.services WHERE name = 'SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687') > 0)   DROP SERVICE [SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687]; if (OBJECT_ID('SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687', 'SQ') IS NOT NULL)   DROP QUEUE [SqlQueryNotificationService-873337c4-0214-4de6-8584-e8d27a238687]; DROP PROCEDURE [SqlQueryNotificationStoredProcedure-873337c4-0214-4de6-8584-e8d27a238687]; END COMMIT TRANSACTION; END
GO
/****** Object:  StoredProcedure [dbo].[SqlQueryNotificationStoredProcedure-a277350c-b0d7-4300-9f22-0f4a0bac414b]    Script Date: 27/04/2021 12:34:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SqlQueryNotificationStoredProcedure-a277350c-b0d7-4300-9f22-0f4a0bac414b] AS BEGIN BEGIN TRANSACTION; RECEIVE TOP(0) conversation_handle FROM [SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b]; IF (SELECT COUNT(*) FROM [SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b] WHERE message_type_name = 'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer') > 0 BEGIN if ((SELECT COUNT(*) FROM sys.services WHERE name = 'SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b') > 0)   DROP SERVICE [SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b]; if (OBJECT_ID('SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b', 'SQ') IS NOT NULL)   DROP QUEUE [SqlQueryNotificationService-a277350c-b0d7-4300-9f22-0f4a0bac414b]; DROP PROCEDURE [SqlQueryNotificationStoredProcedure-a277350c-b0d7-4300-9f22-0f4a0bac414b]; END COMMIT TRANSACTION; END
GO
/****** Object:  StoredProcedure [dbo].[SqlQueryNotificationStoredProcedure-f44eb6df-c4a9-4773-8ef5-7519475227fb]    Script Date: 27/04/2021 12:34:51 CH ******/
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
