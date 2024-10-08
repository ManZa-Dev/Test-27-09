USE [Biblioteca_Bella]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 27/09/2024 15:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[utenteID] [int] IDENTITY(1,1) NOT NULL,
	[utenteCOD] [varchar](50) NOT NULL,
	[nome] [varchar](250) NOT NULL,
	[cognome] [varchar](250) NOT NULL,
	[email] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[utenteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Utente] ADD  DEFAULT (newid()) FOR [utenteCOD]
GO
