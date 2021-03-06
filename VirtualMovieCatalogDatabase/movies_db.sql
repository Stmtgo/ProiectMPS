USE [master]
GO
/****** Object:  Database [movie_db]    Script Date: 5/14/2014 1:39:36 PM ******/
CREATE DATABASE [movie_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'movie_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\movie_db.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'movie_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\movie_db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [movie_db] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [movie_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [movie_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [movie_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [movie_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [movie_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [movie_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [movie_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [movie_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [movie_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [movie_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [movie_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [movie_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [movie_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [movie_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [movie_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [movie_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [movie_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [movie_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [movie_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [movie_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [movie_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [movie_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [movie_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [movie_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [movie_db] SET  MULTI_USER 
GO
ALTER DATABASE [movie_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [movie_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [movie_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [movie_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [movie_db] SET DELAYED_DURABILITY = DISABLED 
GO
USE [movie_db]
GO
/****** Object:  User [oregano]    Script Date: 5/14/2014 1:39:36 PM ******/
CREATE USER [oregano] FOR LOGIN [oregano] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [oregano]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [oregano]
GO
/****** Object:  Table [dbo].[actors]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[actors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_actors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_actor] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[directors]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[directors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_directors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_director] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[genres]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genres](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_genres] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_genre] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[movies]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](60) NOT NULL,
	[description] [nvarchar](150) NOT NULL,
	[year] [int] NOT NULL,
	[nrDiscs] [int] NOT NULL,
 CONSTRAINT [PK_movies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_movie_year] UNIQUE NONCLUSTERED 
(
	[name] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[movies_actors]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies_actors](
	[movieid] [int] NOT NULL,
	[actorid] [int] NOT NULL,
 CONSTRAINT [PK_movies_actors] PRIMARY KEY CLUSTERED 
(
	[movieid] ASC,
	[actorid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[movies_directors]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies_directors](
	[movieid] [int] NOT NULL,
	[directorid] [int] NOT NULL,
 CONSTRAINT [PK_movies_directors] PRIMARY KEY CLUSTERED 
(
	[movieid] ASC,
	[directorid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[movies_genres]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies_genres](
	[movieid] [int] NOT NULL,
	[genreid] [int] NOT NULL,
 CONSTRAINT [PK_movies_genres] PRIMARY KEY CLUSTERED 
(
	[movieid] ASC,
	[genreid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[movies_subtitles]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies_subtitles](
	[movieid] [int] NOT NULL,
	[subtitleid] [int] NOT NULL,
 CONSTRAINT [PK_movies_subtitles] PRIMARY KEY CLUSTERED 
(
	[movieid] ASC,
	[subtitleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[subtitlesLang]    Script Date: 5/14/2014 1:39:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subtitlesLang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_subtitlesLang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[movies_actors]  WITH CHECK ADD  CONSTRAINT [fk_ma_actor] FOREIGN KEY([actorid])
REFERENCES [dbo].[actors] ([id])
GO
ALTER TABLE [dbo].[movies_actors] CHECK CONSTRAINT [fk_ma_actor]
GO
ALTER TABLE [dbo].[movies_actors]  WITH CHECK ADD  CONSTRAINT [fk_ma_movie] FOREIGN KEY([movieid])
REFERENCES [dbo].[movies] ([id])
GO
ALTER TABLE [dbo].[movies_actors] CHECK CONSTRAINT [fk_ma_movie]
GO
ALTER TABLE [dbo].[movies_directors]  WITH CHECK ADD  CONSTRAINT [fk_md_director] FOREIGN KEY([directorid])
REFERENCES [dbo].[directors] ([id])
GO
ALTER TABLE [dbo].[movies_directors] CHECK CONSTRAINT [fk_md_director]
GO
ALTER TABLE [dbo].[movies_directors]  WITH CHECK ADD  CONSTRAINT [fk_md_movie] FOREIGN KEY([movieid])
REFERENCES [dbo].[movies] ([id])
GO
ALTER TABLE [dbo].[movies_directors] CHECK CONSTRAINT [fk_md_movie]
GO
ALTER TABLE [dbo].[movies_genres]  WITH CHECK ADD  CONSTRAINT [fk_mg_genre] FOREIGN KEY([genreid])
REFERENCES [dbo].[genres] ([id])
GO
ALTER TABLE [dbo].[movies_genres] CHECK CONSTRAINT [fk_mg_genre]
GO
ALTER TABLE [dbo].[movies_genres]  WITH CHECK ADD  CONSTRAINT [fk_mg_movie] FOREIGN KEY([movieid])
REFERENCES [dbo].[movies] ([id])
GO
ALTER TABLE [dbo].[movies_genres] CHECK CONSTRAINT [fk_mg_movie]
GO
ALTER TABLE [dbo].[movies_subtitles]  WITH CHECK ADD  CONSTRAINT [fk_ms_movie] FOREIGN KEY([movieid])
REFERENCES [dbo].[movies] ([id])
GO
ALTER TABLE [dbo].[movies_subtitles] CHECK CONSTRAINT [fk_ms_movie]
GO
ALTER TABLE [dbo].[movies_subtitles]  WITH CHECK ADD  CONSTRAINT [fk_ms_subtitle] FOREIGN KEY([subtitleid])
REFERENCES [dbo].[subtitlesLang] ([id])
GO
ALTER TABLE [dbo].[movies_subtitles] CHECK CONSTRAINT [fk_ms_subtitle]
GO
USE [master]
GO
ALTER DATABASE [movie_db] SET  READ_WRITE 
GO
