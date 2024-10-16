USE [EuroleagueDB]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 11-Oct-24 12:28:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[PostCode] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 11-Oct-24 12:28:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[GameId] [int] IDENTITY(1,1) NOT NULL,
	[GameTime] [datetime] NOT NULL,
	[HomeTeamPoints] [int] NOT NULL,
	[AwayTeamPoints] [int] NOT NULL,
	[TeamId1] [int] NOT NULL,
	[TeamId2] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 11-Oct-24 12:28:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Position] [varchar](50) NOT NULL,
	[TeamId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayersStatistics]    Script Date: 11-Oct-24 12:28:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayersStatistics](
	[PlayerId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[PlayersPoints] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC,
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 11-Oct-24 12:28:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 11-Oct-24 12:28:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[EuroleagueChampionsTitles] [int] NOT NULL,
	[Coach] [varchar](50) NOT NULL,
	[Arena] [varchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11-Oct-24 12:28:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Games] ADD  CONSTRAINT [DF_Games_Home Team Points]  DEFAULT ((0)) FOR [HomeTeamPoints]
GO
ALTER TABLE [dbo].[Games] ADD  CONSTRAINT [DF_Games_Away Team Points]  DEFAULT ((0)) FOR [AwayTeamPoints]
GO
ALTER TABLE [dbo].[PlayersStatistics] ADD  DEFAULT ((0)) FOR [PlayersPoints]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_TeamId1_Teams] FOREIGN KEY([TeamId1])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_TeamId1_Teams]
GO
ALTER TABLE [dbo].[Games]  WITH NOCHECK ADD  CONSTRAINT [FK_TeamId2_Teams] FOREIGN KEY([TeamId2])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_TeamId2_Teams]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_TeamId_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_TeamId_Team]
GO
ALTER TABLE [dbo].[PlayersStatistics]  WITH CHECK ADD  CONSTRAINT [FK_GameId_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayersStatistics] CHECK CONSTRAINT [FK_GameId_Games]
GO
ALTER TABLE [dbo].[PlayersStatistics]  WITH CHECK ADD  CONSTRAINT [FK_PlayerId_Players] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Players] ([PlayerId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayersStatistics] CHECK CONSTRAINT [FK_PlayerId_Players]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [Fk_CityId_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [Fk_CityId_Cities]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD CHECK  (([PostCode]>(0)))
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD CHECK  (([TeamId]>(0)))
GO
ALTER TABLE [dbo].[PlayersStatistics]  WITH CHECK ADD CHECK  (([PlayersPoints]>=(0)))
GO
