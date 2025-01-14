﻿Create database BookDB7New
USE BookDB7New
GO
/****** Object: Table [dbo].[Book] Script Date: 2/23/2023 1:21:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Title] [nvarchar](150) NOT NULL,
[Author] [nvarchar](150) NULL,
[Price] [decimal](18, 0) NULL,
[Description] [nvarchar](max) NULL,
[Image] [nvarchar](100) NULL,
[CategoryId] [int] NULL,
CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object: Table [dbo].[Category] Script Date: 2/23/2023 1:21:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
[CategoryId] [int] IDENTITY(1,1) NOT NULL,
[CategoryName] [nvarchar](50) NOT NULL,
CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED
(
[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON
GO
INSERT [dbo].[Book] ([Id], [Title], [Author], [Price], [Description], [Image], [CategoryId]) VALUES (1, N'Cho
tôi xin một vé đi tuoi tho', N'Nguyễn Nhật Ánh', CAST(56000 AS Decimal(18, 0)), N'Kể về cái thời thơ ấu ngây
ngô tinh nghịch xen lẫn hài hước của 4 đứa nhóc 8 tuổi (trong đó có tác giả) về cuộc sống dưới quê hằng ngày,
về một xíu học tập, một chút tình yêu trẻ con đáng yêu và hôn nhân', N'cho-toi-xin-1-ve-di-tuoi-tho.jpg', 1)
GO
INSERT [dbo].[Book] ([Id], [Title], [Author], [Price], [Description], [Image], [CategoryId]) VALUES (2, N'Lập

trình C', N'TS. Lê Xuân Việt', CAST(96000 AS Decimal(18, 0)), N'Học lập trình C ....', N'lap-trinh-co-ban-
1.jpg', 2)

GO
INSERT [dbo].[Book] ([Id], [Title], [Author], [Price], [Description], [Image], [CategoryId]) VALUES (3,
N'Core Java: Fundamentals, Volume 1 (Oracle Press Java)', N'Cay Horstmann ', CAST(200000 AS Decimal(18, 0)),
N'Core Java, Volume I: Fundamentals, Twelfth Edition, is the definitive guide to writing robust, maintainable
code. Whatever version of Java you are using---up to and including Java 17---this book will help you achieve
a deep and practical understanding of the language and APIs. With hundreds of realistic examples, Cay S.
Horstmann reveals the most powerful and effective ways to get the job done.', N'lap-trinh-java-1.jpg', 2)
GO
INSERT [dbo].[Book] ([Id], [Title], [Author], [Price], [Description], [Image], [CategoryId]) VALUES (4,
N'Cuộc Sống Rất Giống Cuộc Đời', N'Hải Dớ', CAST(61000 AS Decimal(18, 0)), N'Đàn ông tuổi 15 mơ ước thành đàn
ông tuổi 20, đàn ông tuổi 20 mơ ước thành đàn ông tuổi 30, đàn ông tuổi 30 mơ ước được trở thành đàn ông tuổi
40 và đàn ông tuổi 40 lại mơ ước đặt chân lên cỗ máy thời gian để quay lại tuổi 30 với toàn bộ tài sản của
mình! Vậy đấy!', N'cuoc-song-giong-cuoc-doi.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Cuộc sống')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Lập trình')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Sức Khỏe')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
ALTER TABLE [dbo].[Book] WITH CHECK ADD CONSTRAINT [FK_Book_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Category]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderNo] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[isComplete] [nvarchar](150) NOT NULL,
	[isPaid] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 25/03/2023 11:31:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderNo] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Book]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderNo])
REFERENCES [dbo].[Order] ([OrderNo])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]