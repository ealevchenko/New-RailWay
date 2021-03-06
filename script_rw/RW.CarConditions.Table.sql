USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[CarConditions]    Script Date: 08.11.2018 17:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[CarConditions](
	[id] [int] NOT NULL,
	[name_ru] [nvarchar](50) NOT NULL,
	[name_en] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CarConditions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (0, N'экспорт', N'export')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (1, N'годен', N'valid')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (2, N'катанка', N'wire rod')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (3, N'чугун', N'cast iron')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (4, N'сыпучие', N'bulk')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (5, N'сталь', N'steel')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (6, N'мр(тормоза)', N'mr(brakes)')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (7, N'мелкий ремонт', N'minor repairs')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (15, N'неисправная с-ма выгрузки', N'defective unloading system')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (21, N'мр/ст', N'мр/ст')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (22, N'мрт/ст', N'мрт/ст')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (23, N'мр/сс', N'мр/сс')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (24, N'мрт/сс', N'мрт/сс')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (25, N'ст/сс', N'ст/сс')
INSERT [RW].[CarConditions] ([id], [name_ru], [name_en]) VALUES (99, N'смерзш. грузы', N'frozen cargo')
