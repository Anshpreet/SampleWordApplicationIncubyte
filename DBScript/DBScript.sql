Create Database [WordsDB]

USE [WordsDB]
GO

/****** Object:  Table [dbo].[Word]    Script Date: 3/31/2022 4:57:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Word](
	[word_id] [int] IDENTITY(1,1) NOT NULL,
	[word_param] [nvarchar](200) NOT NULL,
	[updated_at] [datetimeoffset](7) NULL,
	[deleted_at] [datetimeoffset](7) NULL,
	[is_deleted] [bit] NULL,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[word_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

