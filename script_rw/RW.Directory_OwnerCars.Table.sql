USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[Directory_OwnerCars]    Script Date: 08.11.2018 17:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[Directory_OwnerCars](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[num] [int] NOT NULL,
	[id_owner] [int] NOT NULL,
	[start_lease] [datetime] NULL,
	[end_lease] [datetime] NULL,
	[id_arrival] [int] NULL,
	[user_create] [nvarchar](50) NOT NULL,
	[dt_create] [datetime] NOT NULL,
	[user_edit] [nvarchar](50) NULL,
	[dt_edit] [datetime] NULL,
 CONSTRAINT [PK_Directory_OwnerCars] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [RW].[Directory_OwnerCars]  WITH CHECK ADD  CONSTRAINT [FK_Directory_OwnerCars_Directory_Cars] FOREIGN KEY([num])
REFERENCES [RW].[Directory_Cars] ([num])
GO
ALTER TABLE [RW].[Directory_OwnerCars] CHECK CONSTRAINT [FK_Directory_OwnerCars_Directory_Cars]
GO
ALTER TABLE [RW].[Directory_OwnerCars]  WITH CHECK ADD  CONSTRAINT [FK_Directory_OwnerCars_Directory_Owners] FOREIGN KEY([id_owner])
REFERENCES [RW].[Directory_Owners] ([id])
GO
ALTER TABLE [RW].[Directory_OwnerCars] CHECK CONSTRAINT [FK_Directory_OwnerCars_Directory_Owners]
GO
