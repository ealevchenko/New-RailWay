USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[CarOperations]    Script Date: 08.11.2018 17:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[CarOperations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_car_internal] [int] NOT NULL,
	[id_car_conditions] [int] NULL,
	[id_car_status] [int] NULL,
	[dt_inp] [datetime] NULL,
	[dt_out] [datetime] NULL,
	[id_way] [int] NULL,
	[position] [int] NULL,
	[train1] [int] NULL,
	[train2] [int] NULL,
	[side] [int] NULL,
	[user_create] [nvarchar](50) NOT NULL,
	[dt_create] [datetime] NOT NULL,
	[user_edit] [nvarchar](50) NULL,
	[dt_edit] [datetime] NULL,
	[parent_id] [int] NULL,
 CONSTRAINT [PK_CarOperations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [RW].[CarOperations]  WITH CHECK ADD  CONSTRAINT [FK_CarOperations_CarConditions] FOREIGN KEY([id_car_conditions])
REFERENCES [RW].[CarConditions] ([id])
GO
ALTER TABLE [RW].[CarOperations] CHECK CONSTRAINT [FK_CarOperations_CarConditions]
GO
ALTER TABLE [RW].[CarOperations]  WITH CHECK ADD  CONSTRAINT [FK_CarOperations_CarOperations] FOREIGN KEY([parent_id])
REFERENCES [RW].[CarOperations] ([id])
GO
ALTER TABLE [RW].[CarOperations] CHECK CONSTRAINT [FK_CarOperations_CarOperations]
GO
ALTER TABLE [RW].[CarOperations]  WITH CHECK ADD  CONSTRAINT [FK_CarOperations_CarsInternal] FOREIGN KEY([id_car_internal])
REFERENCES [RW].[CarsInternal] ([id])
GO
ALTER TABLE [RW].[CarOperations] CHECK CONSTRAINT [FK_CarOperations_CarsInternal]
GO
ALTER TABLE [RW].[CarOperations]  WITH CHECK ADD  CONSTRAINT [FK_CarOperations_CarStatus] FOREIGN KEY([id_car_status])
REFERENCES [RW].[CarStatus] ([id])
GO
ALTER TABLE [RW].[CarOperations] CHECK CONSTRAINT [FK_CarOperations_CarStatus]
GO
ALTER TABLE [RW].[CarOperations]  WITH CHECK ADD  CONSTRAINT [FK_CarOperations_Directory_Ways] FOREIGN KEY([id_way])
REFERENCES [RW].[Directory_Ways] ([id])
GO
ALTER TABLE [RW].[CarOperations] CHECK CONSTRAINT [FK_CarOperations_Directory_Ways]
GO
