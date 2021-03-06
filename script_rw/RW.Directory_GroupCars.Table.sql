USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[Directory_GroupCars]    Script Date: 08.11.2018 17:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[Directory_GroupCars](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group_cars_ru] [nvarchar](50) NOT NULL,
	[group_cars_en] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Directory_GroupCars] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [RW].[Directory_GroupCars] ON 

INSERT [RW].[Directory_GroupCars] ([id], [group_cars_ru], [group_cars_en]) VALUES (0, N'Не определена', N'Not determined')
INSERT [RW].[Directory_GroupCars] ([id], [group_cars_ru], [group_cars_en]) VALUES (1, N'Цистерны', N'Tanks')
INSERT [RW].[Directory_GroupCars] ([id], [group_cars_ru], [group_cars_en]) VALUES (2, N'Полувагоны', N'Gondola cars')
INSERT [RW].[Directory_GroupCars] ([id], [group_cars_ru], [group_cars_en]) VALUES (3, N'Хопперы', N'Hoppers')
INSERT [RW].[Directory_GroupCars] ([id], [group_cars_ru], [group_cars_en]) VALUES (4, N'Платформы', N'Platforms')
INSERT [RW].[Directory_GroupCars] ([id], [group_cars_ru], [group_cars_en]) VALUES (5, N'Думпкары', N'Dumpcars')
INSERT [RW].[Directory_GroupCars] ([id], [group_cars_ru], [group_cars_en]) VALUES (6, N'Спец-подвижной состав', N'Special rolling stock')
INSERT [RW].[Directory_GroupCars] ([id], [group_cars_ru], [group_cars_en]) VALUES (7, N'Крытые вагоны', N'Covered wagons')
SET IDENTITY_INSERT [RW].[Directory_GroupCars] OFF
