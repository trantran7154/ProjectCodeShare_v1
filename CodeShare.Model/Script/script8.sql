USE [master]
GO
/****** Object:  Database [DataShareCode]    Script Date: 25-Mar-21 7:52:28 PM ******/
CREATE DATABASE [DataShareCode]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataShareCode', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\DataShareCode.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DataShareCode_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\DataShareCode_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DataShareCode] SET COMPATIBILITY_LEVEL = 120
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
ALTER DATABASE [DataShareCode] SET  DISABLE_BROKER 
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
USE [DataShareCode]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 25-Mar-21 7:52:28 PM ******/
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
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[bill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 25-Mar-21 7:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](max) NULL,
	[category_active] [bit] NULL,
	[category_item] [int] NULL,
 CONSTRAINT [PK_Categorys] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Codes]    Script Date: 25-Mar-21 7:52:28 PM ******/
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
/****** Object:  Table [dbo].[Comments]    Script Date: 25-Mar-21 7:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[code_id] [int] NULL,
	[news_id] [int] NULL,
	[comment_content] [nvarchar](max) NULL,
	[comment_datecreate] [datetime] NULL,
	[comment_dateupdate] [datetime] NULL,
	[comment_active] [bit] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 25-Mar-21 7:52:28 PM ******/
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
/****** Object:  Table [dbo].[Languages]    Script Date: 25-Mar-21 7:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[language_id] [int] IDENTITY(1,1) NOT NULL,
	[language_name] [nvarchar](300) NULL,
	[language_active] [int] NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[language_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 25-Mar-21 7:52:28 PM ******/
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
/****** Object:  Table [dbo].[Pakages]    Script Date: 25-Mar-21 7:52:28 PM ******/
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
/****** Object:  Table [dbo].[Rep]    Script Date: 25-Mar-21 7:52:28 PM ******/
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
	[rep_active] [bit] NULL,
 CONSTRAINT [PK_Rep] PRIMARY KEY CLUSTERED 
(
	[rep_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TakePrices]    Script Date: 25-Mar-21 7:52:28 PM ******/
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
 CONSTRAINT [PK_TakePrices] PRIMARY KEY CLUSTERED 
(
	[tp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tools]    Script Date: 25-Mar-21 7:52:28 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 25-Mar-21 7:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item]) VALUES (1, N'Game', 1, 1)
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item]) VALUES (2, N'Website', 1, 1)
INSERT [dbo].[Categorys] ([category_id], [category_name], [category_active], [category_item]) VALUES (3, N'Ứng dụng', 1, 1)
SET IDENTITY_INSERT [dbo].[Categorys] OFF
SET IDENTITY_INSERT [dbo].[Codes] ON 

INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (1, N'Source code website bán sách online', 10, N'CODE-1', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25 00:00:00.000' AS DateTime), CAST(N'2021-03-25 00:00:00.000' AS DateTime), 1, 1, 0, NULL, 20, N'123', 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (5, N'Source code website bán sách online', 10, N'CODE-5', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25 00:00:00.000' AS DateTime), CAST(N'2021-03-25 00:00:00.000' AS DateTime), 1, 1, 0, NULL, 30, NULL, 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (6, N'Source code website bán sách online', 10, N'CODE-6', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25 00:00:00.000' AS DateTime), CAST(N'2021-03-25 00:00:00.000' AS DateTime), 1, 1, 0, NULL, 40, N'123', 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (7, N'Source code website bán sách online', 10, N'CODE-7', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25 00:00:00.000' AS DateTime), CAST(N'2021-03-25 00:00:00.000' AS DateTime), 1, 1, 0, NULL, 50, NULL, 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
INSERT [dbo].[Codes] ([code_id], [code_title], [code_coin], [code_code], [code_des], [code_info], [code_setting], [code_view], [code_viewdown], [code_linkdemo], [code_linkdown], [code_datecreate], [code_dateupdate], [code_active], [code_option], [code_del], [code_tag], [code_disk], [code_pass], [category_id], [user_id], [code_img]) VALUES (8, N'Source code website bán sách online', 10, N'CODE-8', N'Source code website bán sách online', N'Các chức năng của website:

* Chức năng cho người dùng

     - Xem thông tin sách

     - Thêm sách vào giỏ hàng

     - Thực hiện tìm kiếm sách

* Chức năng cho admin

     - Xem, chỉnh sửa, xóa tất cả các thông tin về người dùng, sách, hóa đơn, liên hệ', N'* Yêu cầu máy đã cài đặt Netbeans và SQL  Server

1. Chạy database trong thư mục database

2. Mở Netbeans và chạy project', 1, 1, N'https://www.youtube.com/watch?v=_Wah73E_JlY', N'https://sharecode.vn/source-code/source-code-website-ban-sach-online-27953.htm#Download', CAST(N'2021-03-25 00:00:00.000' AS DateTime), CAST(N'2021-03-25 00:00:00.000' AS DateTime), 1, 1, 0, NULL, 60, N'123', 2, 1, N'52edcade-c48c-440d-91d0-29501e648b1adh2.jpg')
SET IDENTITY_INSERT [dbo].[Codes] OFF
SET IDENTITY_INSERT [dbo].[Pakages] ON 

INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (1, 20, NULL, NULL)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (2, 50, NULL, NULL)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (3, 100, NULL, NULL)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (4, 200, NULL, NULL)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (5, 300, NULL, NULL)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (6, 400, NULL, NULL)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (7, 500, NULL, NULL)
INSERT [dbo].[Pakages] ([pakege_id], [pakage_coin], [pakage_money], [pakage_active]) VALUES (8, 1000000, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Pakages] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [user_email], [user_phone], [user_sex], [user_birth], [user_token], [user_role], [user_name], [user_coin], [user_datecreate], [user_dateupdate], [user_code], [user_active], [user_option], [user_del], [user_fa], [user_none], [user_view], [user_facode], [user_pass]) VALUES (1, N'tanhuynh@gmail.com', NULL, NULL, NULL, N'f9b0f29a-a7db-45ee-972f-ac8e57cc9727', 2, N'Tan', 0, CAST(N'2021-03-25 16:20:59.410' AS DateTime), NULL, N'#Music_Admin', 1, 1, 0, NULL, NULL, 0, NULL, N'tanhuynhga')
SET IDENTITY_INSERT [dbo].[Users] OFF
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
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Codes] FOREIGN KEY([code_id])
REFERENCES [dbo].[Codes] ([code_id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Codes]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_News] FOREIGN KEY([news_id])
REFERENCES [dbo].[News] ([news_id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_News]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
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
ALTER TABLE [dbo].[Rep]  WITH CHECK ADD  CONSTRAINT [FK_Rep_Comments] FOREIGN KEY([comment_id])
REFERENCES [dbo].[Comments] ([comment_id])
GO
ALTER TABLE [dbo].[Rep] CHECK CONSTRAINT [FK_Rep_Comments]
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
USE [master]
GO
ALTER DATABASE [DataShareCode] SET  READ_WRITE 
GO
