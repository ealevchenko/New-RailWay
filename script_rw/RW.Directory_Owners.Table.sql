USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[Directory_Owners]    Script Date: 08.11.2018 17:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[Directory_Owners](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[owner_name] [nvarchar](300) NOT NULL,
	[owner_abr] [nvarchar](50) NULL,
	[user_create] [nvarchar](50) NOT NULL,
	[dt_create] [datetime] NOT NULL,
	[user_edit] [nvarchar](50) NULL,
	[dt_edit] [datetime] NULL,
	[id_kis] [int] NULL,
 CONSTRAINT [PK_Directory_Owners] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [RW].[Directory_Owners] ON 

INSERT [RW].[Directory_Owners] ([id], [owner_name], [owner_abr], [user_create], [dt_create], [user_edit], [dt_edit], [id_kis]) VALUES (0, N'Не определён', N'?', N'EUROPE\krr-svc-RailWay', CAST(N'2018-11-08T14:11:41.103' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [RW].[Directory_Owners] OFF
