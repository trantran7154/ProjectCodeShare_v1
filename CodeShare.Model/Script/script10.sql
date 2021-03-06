USE [master]
GO
/****** Object:  Database [DataShareCode]    Script Date: 3/26/2021 2:22:29 PM ******/
CREATE DATABASE [DataShareCode]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataShareCode', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DataShareCode.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DataShareCode_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DataShareCode_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DataShareCode] SET COMPATIBILITY_LEVEL = 140
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
/****** Object:  Table [dbo].[Bills]    Script Date: 3/26/2021 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[Categorys]    Script Date: 3/26/2021 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[Chats]    Script Date: 3/26/2021 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chats](
	[chat_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[chat_content] [nvarchar](max) NULL,
	[chat_datecreate] [datetime] NULL,
 CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED 
(
	[chat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Codes]    Script Date: 3/26/2021 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[Groups]    Script Date: 3/26/2021 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[Languages]    Script Date: 3/26/2021 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[News]    Script Date: 3/26/2021 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[Pakages]    Script Date: 3/26/2021 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[TakePrices]    Script Date: 3/26/2021 2:22:29 PM ******/
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
	[tp_customer] [nvarchar](225) NULL,
	[tp_accountnumber] [varchar](50) NULL,
 CONSTRAINT [PK_TakePrices] PRIMARY KEY CLUSTERED 
(
	[tp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tools]    Script Date: 3/26/2021 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 3/26/2021 2:22:29 PM ******/
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
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (1, CAST(N'2021-03-25T19:15:11.553' AS DateTime), 1, 1, 0, CAST(N'2021-03-25T19:15:11.553' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (2, CAST(N'2021-03-25T19:30:18.120' AS DateTime), 3, 1, 0, CAST(N'2021-04-04T19:30:18.120' AS DateTime))
INSERT [dbo].[Bills] ([bill_id], [bill_datecreate], [pakege_id], [user_id], [bill_active], [bill_dealine]) VALUES (3, CAST(N'2021-03-25T19:32:26.810' AS DateTime), 1, 1, 1, CAST(N'2021-03-25T19:32:26.810' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img]) VALUES (1, N'Game', 1, 1, NULL)
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img]) VALUES (2, N'Website', 1, 1, NULL)
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item], [category_img]) VALUES (3, N'Ứng dụng', 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Categorys] OFF
GO
SET IDENTITY_INSERT [dbo].[Chats] ON 

INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (1, 1, N'a', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (18, 1, N'b', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (19, 1, N'c', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (20, 1, N'd', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (21, 1, N'e', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (22, 1, N'f', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (23, 1, N'g', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (24, 1, N'h', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (25, 1, N'z', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (26, NULL, N'd', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (27, NULL, N'd', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (28, NULL, N'd', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (29, NULL, N'd', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (30, NULL, N'd', NULL)
INSERT [dbo].[Chats] ([chat_id], [user_id], [chat_content], [chat_datecreate]) VALUES (31, NULL, N'd', NULL)
SET IDENTITY_INSERT [dbo].[Chats] OFF
GO
SET IDENTITY_INSERT [dbo].[Codes] ON 

INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (1, N'Source code website bán sách online', 10, N'CODE-1', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25T00:00:00.000' AS DateTime), CAST(N'2021-03-25T00:00:00.000' AS DateTime), 1, 1, 0, NULL, 20, N'123', 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (5, N'Source code website bán sách online', 10, N'CODE-5', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25T00:00:00.000' AS DateTime), CAST(N'2021-03-25T00:00:00.000' AS DateTime), 1, 1, 0, NULL, 30, NULL, 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (6, N'Source code website bán sách online', 10, N'CODE-6', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25T00:00:00.000' AS DateTime), CAST(N'2021-03-25T00:00:00.000' AS DateTime), 1, 1, 0, NULL, 40, N'123', 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (7, N'Source code website bán sách online', 10, N'CODE-7', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25T00:00:00.000' AS DateTime), CAST(N'2021-03-25T00:00:00.000' AS DateTime), 1, 1, 0, NULL, 50, NULL, 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (8, N'Source code website bán sách online', 10, N'CODE-8', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25T00:00:00.000' AS DateTime), CAST(N'2021-03-25T00:00:00.000' AS DateTime), 1, 1, 0, NULL, 60, N'123', 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
SET IDENTITY_INSERT [dbo].[Codes] OFF
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
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass]) VALUES (1, N'huynhminhtan4019@gmail.com', NULL, NULL, NULL, N'338aa56e-9786-4784-9902-64ca046432e6', 2, N'Tấn huỳnh', 20, CAST(N'2021-03-25T16:29:11.193' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'0924404019')
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
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Categorys] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categorys] ([category_id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Categorys]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Languages] FOREIGN KEY([language_id])
REFERENCES [dbo].[Languages] ([language_id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Languages]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Users]
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
/****** Object:  StoredProcedure [dbo].[SqlQueryNotificationStoredProcedure-db3f9b18-f50f-4426-bb3b-aff843ec2e9b]    Script Date: 3/26/2021 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SqlQueryNotificationStoredProcedure-db3f9b18-f50f-4426-bb3b-aff843ec2e9b] AS BEGIN BEGIN TRANSACTION; RECEIVE TOP(0) conversation_handle FROM [SqlQueryNotificationService-db3f9b18-f50f-4426-bb3b-aff843ec2e9b]; IF (SELECT COUNT(*) FROM [SqlQueryNotificationService-db3f9b18-f50f-4426-bb3b-aff843ec2e9b] WHERE message_type_name = 'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer') > 0 BEGIN if ((SELECT COUNT(*) FROM sys.services WHERE name = 'SqlQueryNotificationService-db3f9b18-f50f-4426-bb3b-aff843ec2e9b') > 0)   DROP SERVICE [SqlQueryNotificationService-db3f9b18-f50f-4426-bb3b-aff843ec2e9b]; if (OBJECT_ID('SqlQueryNotificationService-db3f9b18-f50f-4426-bb3b-aff843ec2e9b', 'SQ') IS NOT NULL)   DROP QUEUE [SqlQueryNotificationService-db3f9b18-f50f-4426-bb3b-aff843ec2e9b]; DROP PROCEDURE [SqlQueryNotificationStoredProcedure-db3f9b18-f50f-4426-bb3b-aff843ec2e9b]; END COMMIT TRANSACTION; END
GO
USE [master]
GO
ALTER DATABASE [DataShareCode] SET  READ_WRITE 
GO
