USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[Directory_TypeWays]    Script Date: 08.11.2018 17:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[Directory_TypeWays](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_way_ru] [nvarchar](50) NOT NULL,
	[type_way_en] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Directory_TypeWays] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [RW].[Directory_TypeWays] ON 

INSERT [RW].[Directory_TypeWays] ([id], [type_way_ru], [type_way_en]) VALUES (0, N'До выяснения', N'Until clarification')
INSERT [RW].[Directory_TypeWays] ([id], [type_way_ru], [type_way_en]) VALUES (1, N'Станционный', N'Station')
INSERT [RW].[Directory_TypeWays] ([id], [type_way_ru], [type_way_en]) VALUES (2, N'Перегон ', N'Перегон ')
INSERT [RW].[Directory_TypeWays] ([id], [type_way_ru], [type_way_en]) VALUES (3, N'Тупик ', N'Deadlock ')
INSERT [RW].[Directory_TypeWays] ([id], [type_way_ru], [type_way_en]) VALUES (4, N'Вагоноопрокид ', N'Tipping ')
INSERT [RW].[Directory_TypeWays] ([id], [type_way_ru], [type_way_en]) VALUES (5, N'ПТО ', N'Service Point ')
SET IDENTITY_INSERT [RW].[Directory_TypeWays] OFF
