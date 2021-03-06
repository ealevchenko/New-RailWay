USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[Directory_Overturn]    Script Date: 08.11.2018 17:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[Directory_Overturn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name_ru] [nvarchar](250) NOT NULL,
	[name_en] [nvarchar](250) NOT NULL,
	[user_create] [nvarchar](50) NOT NULL,
	[dt_create] [datetime] NOT NULL,
	[user_edit] [nvarchar](50) NULL,
	[dt_edit] [datetime] NULL,
 CONSTRAINT [PK_Directory_Overturn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [RW].[Directory_Overturn] ON 

INSERT [RW].[Directory_Overturn] ([id], [name_ru], [name_en], [user_create], [dt_create], [user_edit], [dt_edit]) VALUES (1, N'Угольный левый', N'Coal left', N'EUROPE\krr-svc-RailWay', CAST(N'2018-11-08T17:10:57.223' AS DateTime), NULL, NULL)
INSERT [RW].[Directory_Overturn] ([id], [name_ru], [name_en], [user_create], [dt_create], [user_edit], [dt_edit]) VALUES (2, N'Угольный правый', N'Coal right', N'EUROPE\krr-svc-RailWay', CAST(N'2018-11-08T17:10:57.227' AS DateTime), NULL, NULL)
INSERT [RW].[Directory_Overturn] ([id], [name_ru], [name_en], [user_create], [dt_create], [user_edit], [dt_edit]) VALUES (3, N'Флюсовый', N'Fluxes', N'EUROPE\krr-svc-RailWay', CAST(N'2018-11-08T17:10:57.230' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [RW].[Directory_Overturn] OFF
