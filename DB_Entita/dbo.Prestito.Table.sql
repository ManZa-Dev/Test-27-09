USE [Biblioteca_Bella]
GO
/****** Object:  Table [dbo].[Prestito]    Script Date: 27/09/2024 15:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestito](
	[prestitoID] [int] IDENTITY(1,1) NOT NULL,
	[prestitoCOD] [varchar](50) NOT NULL,
	[ini_prest] [datetime] NOT NULL,
	[fin_prest] [datetime] NOT NULL,
	[utenteRIF] [int] NOT NULL,
	[libroRIF] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[prestitoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Prestito] ADD  DEFAULT (newid()) FOR [prestitoCOD]
GO
ALTER TABLE [dbo].[Prestito] ADD  DEFAULT (getdate()) FOR [ini_prest]
GO
ALTER TABLE [dbo].[Prestito]  WITH CHECK ADD FOREIGN KEY([libroRIF])
REFERENCES [dbo].[Libro] ([libroID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prestito]  WITH CHECK ADD FOREIGN KEY([utenteRIF])
REFERENCES [dbo].[Utente] ([utenteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prestito]  WITH CHECK ADD  CONSTRAINT [checkDate] CHECK  (([fin_prest]>[ini_prest]))
GO
ALTER TABLE [dbo].[Prestito] CHECK CONSTRAINT [checkDate]
GO
