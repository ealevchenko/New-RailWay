USE [KRR-PA-CNT-Railway]
GO
/****** Object:  Table [RW].[Directory_ExternalStations]    Script Date: 08.11.2018 17:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RW].[Directory_ExternalStations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[station] [nvarchar](50) NOT NULL,
	[internal_railroad] [nvarchar](250) NOT NULL,
	[ir_abbr] [nvarchar](10) NOT NULL,
	[name_network] [nvarchar](250) NOT NULL,
	[nn_abbr] [nvarchar](10) NOT NULL,
	[code_cs] [int] NOT NULL,
 CONSTRAINT [PK_Directory_ExternalStations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
