USE [Biblioteca_Bella]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 27/09/2024 15:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[libroID] [int] IDENTITY(1,1) NOT NULL,
	[libroCOD] [varchar](50) NOT NULL,
	[titolo] [varchar](250) NOT NULL,
	[anno_pub] [char](4) NOT NULL,
	[isDisp] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[libroID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Libro] ADD  DEFAULT (newid()) FOR [libroCOD]
GO
ALTER TABLE [dbo].[Libro] ADD  DEFAULT ((1)) FOR [isDisp]
GO
