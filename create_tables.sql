USE [theObjects]
GO
/****** Object:  Table [dbo].[Circle]    Script Date: 28/05/2024 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Circle](
	[ID] [uniqueidentifier] NOT NULL,
	[PositionID] [uniqueidentifier] NULL,
	[Diameter] [float] NOT NULL,
	[Area] [float] NOT NULL,
	[Perimeter] [float] NOT NULL,
 CONSTRAINT [PK_Circle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Line]    Script Date: 28/05/2024 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Line](
	[ID] [uniqueidentifier] NOT NULL,
	[StartPositionID] [uniqueidentifier] NULL,
	[EndPositionID] [uniqueidentifier] NULL,
	[Area] [float] NOT NULL,
	[Perimeter] [float] NOT NULL,
 CONSTRAINT [PK_Line] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Point]    Script Date: 28/05/2024 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Point](
	[ID] [uniqueidentifier] NOT NULL,
	[X] [int] NOT NULL,
	[Y] [int] NOT NULL,
	[Area] [float] NOT NULL,
	[Perimeter] [float] NOT NULL,
 CONSTRAINT [PK_Point] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rectangle]    Script Date: 28/05/2024 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rectangle](
	[ID] [uniqueidentifier] NOT NULL,
	[PositionID] [uniqueidentifier] NULL,
	[Width] [float] NOT NULL,
	[Lenght] [float] NOT NULL,
	[Area] [float] NOT NULL,
	[Perimeter] [float] NOT NULL,
 CONSTRAINT [PK_Rectangle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Square]    Script Date: 28/05/2024 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Square](
	[ID] [uniqueidentifier] NOT NULL,
	[PositionID] [uniqueidentifier] NULL,
	[Side] [float] NOT NULL,
	[Area] [float] NOT NULL,
	[Perimeter] [float] NOT NULL,
 CONSTRAINT [PK_Square] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Circle] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Area]
GO
ALTER TABLE [dbo].[Circle] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Perimeter]
GO
ALTER TABLE [dbo].[Line] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Area]
GO
ALTER TABLE [dbo].[Line] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Perimeter]
GO
ALTER TABLE [dbo].[Point] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Area]
GO
ALTER TABLE [dbo].[Point] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Perimeter]
GO
ALTER TABLE [dbo].[Rectangle] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Area]
GO
ALTER TABLE [dbo].[Rectangle] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Perimeter]
GO
ALTER TABLE [dbo].[Square] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Area]
GO
ALTER TABLE [dbo].[Square] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Perimeter]
GO
ALTER TABLE [dbo].[Circle]  WITH CHECK ADD  CONSTRAINT [FK_Circle_Point_PositionID] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Point] ([ID])
GO
ALTER TABLE [dbo].[Circle] CHECK CONSTRAINT [FK_Circle_Point_PositionID]
GO
ALTER TABLE [dbo].[Line]  WITH CHECK ADD  CONSTRAINT [FK_Line_Point_EndPositionID] FOREIGN KEY([EndPositionID])
REFERENCES [dbo].[Point] ([ID])
GO
ALTER TABLE [dbo].[Line] CHECK CONSTRAINT [FK_Line_Point_EndPositionID]
GO
ALTER TABLE [dbo].[Line]  WITH CHECK ADD  CONSTRAINT [FK_Line_Point_StartPositionID] FOREIGN KEY([StartPositionID])
REFERENCES [dbo].[Point] ([ID])
GO
ALTER TABLE [dbo].[Line] CHECK CONSTRAINT [FK_Line_Point_StartPositionID]
GO
ALTER TABLE [dbo].[Rectangle]  WITH CHECK ADD  CONSTRAINT [FK_Rectangle_Point_PositionID] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Point] ([ID])
GO
ALTER TABLE [dbo].[Rectangle] CHECK CONSTRAINT [FK_Rectangle_Point_PositionID]
GO
ALTER TABLE [dbo].[Square]  WITH CHECK ADD  CONSTRAINT [FK_Square_Point_PositionID] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Point] ([ID])
GO
ALTER TABLE [dbo].[Square] CHECK CONSTRAINT [FK_Square_Point_PositionID]
GO
