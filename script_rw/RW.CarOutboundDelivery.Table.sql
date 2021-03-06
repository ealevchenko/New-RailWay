USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[CarOutboundDelivery]    Script Date: 08.11.2018 17:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[CarOutboundDelivery](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_car_internal] [int] NOT NULL,
	[num_nakl_sap] [nvarchar](35) NULL,
	[id_tupik] [int] NULL,
	[id_country_out] [int] NULL,
	[id_station_out] [int] NULL,
	[note] [nvarchar](500) NULL,
	[cargo_code] [int] NULL,
	[id_cargo] [int] NULL,
	[weight_cargo] [numeric](18, 3) NULL,
	[num_doc_reweighing_sap] [int] NULL,
	[dt_doc_reweighing_sap] [datetime] NULL,
	[weight_reweighing_sap] [numeric](18, 3) NULL,
	[dt_reweighing_sap] [datetime] NULL,
	[post_reweighing_sap] [int] NULL,
 CONSTRAINT [PK_CarOutboundDelivery] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [RW].[CarOutboundDelivery]  WITH CHECK ADD  CONSTRAINT [FK_CarOutboundDelivery_CarsInternal] FOREIGN KEY([id_car_internal])
REFERENCES [RW].[CarsInternal] ([id])
GO
ALTER TABLE [RW].[CarOutboundDelivery] CHECK CONSTRAINT [FK_CarOutboundDelivery_CarsInternal]
GO
ALTER TABLE [RW].[CarOutboundDelivery]  WITH CHECK ADD  CONSTRAINT [FK_CarOutboundDelivery_Directory_Cargo] FOREIGN KEY([id_cargo])
REFERENCES [RW].[Directory_Cargo] ([id])
GO
ALTER TABLE [RW].[CarOutboundDelivery] CHECK CONSTRAINT [FK_CarOutboundDelivery_Directory_Cargo]
GO
ALTER TABLE [RW].[CarOutboundDelivery]  WITH CHECK ADD  CONSTRAINT [FK_CarOutboundDelivery_Directory_Country] FOREIGN KEY([id_country_out])
REFERENCES [RW].[Directory_Country] ([id])
GO
ALTER TABLE [RW].[CarOutboundDelivery] CHECK CONSTRAINT [FK_CarOutboundDelivery_Directory_Country]
GO
ALTER TABLE [RW].[CarOutboundDelivery]  WITH CHECK ADD  CONSTRAINT [FK_CarOutboundDelivery_Directory_ExternalStations] FOREIGN KEY([id_station_out])
REFERENCES [RW].[Directory_ExternalStations] ([id])
GO
ALTER TABLE [RW].[CarOutboundDelivery] CHECK CONSTRAINT [FK_CarOutboundDelivery_Directory_ExternalStations]
GO
