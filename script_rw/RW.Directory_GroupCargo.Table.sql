USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[Directory_GroupCargo]    Script Date: 08.11.2018 17:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[Directory_GroupCargo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group_name_ru] [nvarchar](50) NOT NULL,
	[group_name_en] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Directory_GroupCargo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [RW].[Directory_GroupCargo] ON 

INSERT [RW].[Directory_GroupCargo] ([id], [group_name_ru], [group_name_en]) VALUES (0, N'Не определен', N'Indefined')
INSERT [RW].[Directory_GroupCargo] ([id], [group_name_ru], [group_name_en]) VALUES (1, N'Массовые грузы', N'Bulk goods')
INSERT [RW].[Directory_GroupCargo] ([id], [group_name_ru], [group_name_en]) VALUES (2, N'Одиночные грузы', N'Single loads')
SET IDENTITY_INSERT [RW].[Directory_GroupCargo] OFF
