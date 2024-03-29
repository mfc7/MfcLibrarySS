CREATE DATABASE [LibraryDb]
 
USE [LibraryDb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](250) NULL,
	[Author] [nvarchar](250) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[IsLoaned] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lending]    Script Date: 19.03.2024 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lending](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NULL,
	[BorrowerName] [nvarchar](250) NULL,
	[LoanDate] [datetime] NULL,
	[GiveBackDate] [datetime] NULL,
 CONSTRAINT [PK_Lending] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [BookName], [Author], [ImageUrl], [IsLoaned], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, N'İlk Kitap', N'İlk Yazar', N'https://im.haberturk.com/l/2023/07/06/ver1688710460/3605272/jpg/640x360', 0, 1, CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-03-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Book] ([ID], [BookName], [Author], [ImageUrl], [IsLoaned], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (50, N'LOTR', N'Tolkien', N'https://static.nadirkitap.com/fotograf/784771/18/Kitap_202006020011547847718.jpg', 1, 1, CAST(N'2024-03-19T06:39:29.030' AS DateTime), CAST(N'2024-03-19T06:39:29.030' AS DateTime))
INSERT [dbo].[Book] ([ID], [BookName], [Author], [ImageUrl], [IsLoaned], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (51, N'Satranç', N'Stefan Zweig', N'https://m.media-amazon.com/images/I/61ialm+EQ2L._SL1500_.jpg', 1, 1, CAST(N'2024-03-19T06:46:54.437' AS DateTime), CAST(N'2024-03-19T06:46:54.437' AS DateTime))
INSERT [dbo].[Book] ([ID], [BookName], [Author], [ImageUrl], [IsLoaned], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (52, N'Dune', N'Frank Herbert', N'https://cdn03.ciceksepeti.com/cicek/kc8469080-1/XL/dune---ithaki-bilim-kurgu-klasikleri-1-kc8469080-1-c05de17add97460c9cf6b5c7925cca52.jpg', 1, 1, CAST(N'2024-03-19T06:49:15.723' AS DateTime), CAST(N'2024-03-19T06:49:15.723' AS DateTime))
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Lending] ON 

INSERT [dbo].[Lending] ([ID], [BookID], [BorrowerName], [LoanDate], [GiveBackDate]) VALUES (39, 50, N'Fatih ÇATAL', CAST(N'2024-03-19T06:44:10.857' AS DateTime), CAST(N'2024-03-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Lending] ([ID], [BookID], [BorrowerName], [LoanDate], [GiveBackDate]) VALUES (40, 51, N'Elon Musk', CAST(N'2024-03-19T06:47:49.880' AS DateTime), CAST(N'2024-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Lending] ([ID], [BookID], [BorrowerName], [LoanDate], [GiveBackDate]) VALUES (41, 52, N'Enes Fırat', CAST(N'2024-03-19T06:51:23.150' AS DateTime), CAST(N'2024-03-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Lending] ([ID], [BookID], [BorrowerName], [LoanDate], [GiveBackDate]) VALUES (42, 52, N'Kadir Usta', CAST(N'2024-03-19T06:54:24.727' AS DateTime), CAST(N'2025-05-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lending] OFF
GO
ALTER TABLE [dbo].[Lending]  WITH CHECK ADD  CONSTRAINT [FK_Lending_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[Lending] CHECK CONSTRAINT [FK_Lending_Book]
GO
USE [master]
GO
ALTER DATABASE [LibraryDb] SET  READ_WRITE 
GO
