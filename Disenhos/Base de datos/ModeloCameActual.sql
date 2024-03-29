USE [Came]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Direccion] [varchar](1000) NOT NULL,
	[Telefono] [varchar](1000) NULL,
	[Email] [varchar](1000) NULL,
	[Celular] [varchar](1000) NULL,
	[Permisos] [int] NOT NULL,
	[UserName] [varchar](1000) NOT NULL,
	[Contrasenha] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tutor]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tutor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Direccion] [varchar](1000) NOT NULL,
	[Telefono] [varchar](1000) NOT NULL,
	[Celular] [varchar](1000) NULL,
 CONSTRAINT [PK_Tutor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actividad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Actividad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Alergia]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alergia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Descripcion] [varchar](1000) NULL,
	[Tratamiento] [varchar](1000) NULL,
 CONSTRAINT [PK_Alergia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Diagnostico]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Diagnostico](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Descripcion] [varchar](1000) NULL,
 CONSTRAINT [PK_Diagnostico] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Discapacidad]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Discapacidad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Descripcion] [varchar](1000) NULL,
 CONSTRAINT [PK_Discapacidad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Maestro]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Maestro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Direccion] [varchar](1000) NOT NULL,
	[Email] [varchar](1000) NULL,
	[Telefono] [varchar](1000) NULL,
	[Celular] [varchar](1000) NULL,
	[Rfc] [varchar](1000) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
 CONSTRAINT [PK_Maestro] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Horario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Dias] [varchar](1000) NOT NULL,
	[Horas] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Programa]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Programa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Programa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Medicamento]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medicamento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Descripcion] [varchar](1000) NULL,
	[Horas] [varchar](1000) NULL,
 CONSTRAINT [PK_Medicamento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Factor]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Factor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ejercicio]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ejercicio](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Descripcion] [varchar](1000) NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Ejercicio] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[IdHorario] [int] NOT NULL,
	[IdMaestro] [int] NOT NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Discapacidad_Factor]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discapacidad_Factor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdDiscapacidad] [int] NOT NULL,
	[IdFactor] [int] NOT NULL,
 CONSTRAINT [PK_Discapacidad_Factor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diagnostico_Discapacidad]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diagnostico_Discapacidad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdDiagnostico] [int] NOT NULL,
	[IdDiscapacidad] [int] NOT NULL,
 CONSTRAINT [PK_Diagnostico_Discapacidad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actividad_Ejercicio]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad_Ejercicio](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdActividad] [int] NOT NULL,
	[IdEjercicio] [int] NOT NULL,
 CONSTRAINT [PK_Actividad_Ejercicio] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rutina]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rutina](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[IdMaestro] [int] NOT NULL,
	[Lugar] [varchar](1000) NOT NULL,
	[Finalidad] [varchar](1000) NOT NULL,
	[IdHorario] [int] NOT NULL,
 CONSTRAINT [PK_Rutina] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Programa_Actividad]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programa_Actividad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdPrograma] [int] NOT NULL,
	[IdActividad] [int] NOT NULL,
 CONSTRAINT [PK_Programa_Actividad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rutina_Programa]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rutina_Programa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdRutina] [int] NOT NULL,
	[IdPrograma] [int] NOT NULL,
 CONSTRAINT [PK_Rutina_Programa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumno](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1000) NOT NULL,
	[Direccion] [varchar](1000) NOT NULL,
	[Matricula] [varchar](1000) NOT NULL,
	[IdTutor] [int] NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[CURP] [varchar](1000) NOT NULL,
	[GradoAcademico] [varchar](1000) NOT NULL,
	[TallaUniforme] [varchar](1000) NOT NULL,
	[IdDiagnostico] [int] NOT NULL,
	[IdGrupo] [int] NOT NULL,
	[IdRutina] [int] NOT NULL,
	[TipoSangre] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Maestro_Grupo]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestro_Grupo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdMaestro] [int] NOT NULL,
	[IdGrupo] [int] NOT NULL,
 CONSTRAINT [PK_Maestro_Grupo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo_Alumno]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo_Alumno](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupo] [int] NOT NULL,
	[IdAlumno] [int] NOT NULL,
 CONSTRAINT [PK_Grupo_Alumno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno_Medicamento]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno_Medicamento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdAlumno] [int] NOT NULL,
	[IdMedicamento] [int] NOT NULL,
 CONSTRAINT [PK_Alumno_Medicamento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno_Alergia]    Script Date: 04/22/2013 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno_Alergia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdAlumno] [int] NOT NULL,
	[IdAlergia] [int] NOT NULL,
 CONSTRAINT [PK_Alumno_Alergia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Actividad_Ejercicio_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Actividad_Ejercicio]  WITH CHECK ADD  CONSTRAINT [FK_Actividad_Ejercicio_ibfk_1] FOREIGN KEY([IdEjercicio])
REFERENCES [dbo].[Ejercicio] ([ID])
GO
ALTER TABLE [dbo].[Actividad_Ejercicio] CHECK CONSTRAINT [FK_Actividad_Ejercicio_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Actividad_Ejercicio_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Actividad_Ejercicio]  WITH CHECK ADD  CONSTRAINT [FK_Actividad_Ejercicio_ibfk_2] FOREIGN KEY([IdActividad])
REFERENCES [dbo].[Actividad] ([ID])
GO
ALTER TABLE [dbo].[Actividad_Ejercicio] CHECK CONSTRAINT [FK_Actividad_Ejercicio_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Alumno_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_ibfk_1] FOREIGN KEY([IdTutor])
REFERENCES [dbo].[Tutor] ([ID])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Alumno_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_ibfk_2] FOREIGN KEY([IdDiagnostico])
REFERENCES [dbo].[Diagnostico] ([ID])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Alumno_ibfk_3]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_ibfk_3] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([ID])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_ibfk_3]
GO
/****** Object:  ForeignKey [FK_Alumno_ibfk_4]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_ibfk_4] FOREIGN KEY([IdRutina])
REFERENCES [dbo].[Rutina] ([ID])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_ibfk_4]
GO
/****** Object:  ForeignKey [FK_Alumno_Alergia_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Alumno_Alergia]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Alergia_ibfk_1] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([ID])
GO
ALTER TABLE [dbo].[Alumno_Alergia] CHECK CONSTRAINT [FK_Alumno_Alergia_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Alumno_Alergia_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Alumno_Alergia]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Alergia_ibfk_2] FOREIGN KEY([IdAlergia])
REFERENCES [dbo].[Alergia] ([ID])
GO
ALTER TABLE [dbo].[Alumno_Alergia] CHECK CONSTRAINT [FK_Alumno_Alergia_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Alumno_Medicamento_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Alumno_Medicamento]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Medicamento_ibfk_1] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([ID])
GO
ALTER TABLE [dbo].[Alumno_Medicamento] CHECK CONSTRAINT [FK_Alumno_Medicamento_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Alumno_Medicamento_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Alumno_Medicamento]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Medicamento_ibfk_2] FOREIGN KEY([IdMedicamento])
REFERENCES [dbo].[Medicamento] ([ID])
GO
ALTER TABLE [dbo].[Alumno_Medicamento] CHECK CONSTRAINT [FK_Alumno_Medicamento_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Diagnostico_Discapacidad_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Diagnostico_Discapacidad]  WITH CHECK ADD  CONSTRAINT [FK_Diagnostico_Discapacidad_ibfk_1] FOREIGN KEY([IdDiagnostico])
REFERENCES [dbo].[Diagnostico] ([ID])
GO
ALTER TABLE [dbo].[Diagnostico_Discapacidad] CHECK CONSTRAINT [FK_Diagnostico_Discapacidad_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Diagnostico_Discapacidad_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Diagnostico_Discapacidad]  WITH CHECK ADD  CONSTRAINT [FK_Diagnostico_Discapacidad_ibfk_2] FOREIGN KEY([IdDiscapacidad])
REFERENCES [dbo].[Discapacidad] ([ID])
GO
ALTER TABLE [dbo].[Diagnostico_Discapacidad] CHECK CONSTRAINT [FK_Diagnostico_Discapacidad_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Discapacidad_Factor_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Discapacidad_Factor]  WITH CHECK ADD  CONSTRAINT [FK_Discapacidad_Factor_ibfk_1] FOREIGN KEY([IdDiscapacidad])
REFERENCES [dbo].[Discapacidad] ([ID])
GO
ALTER TABLE [dbo].[Discapacidad_Factor] CHECK CONSTRAINT [FK_Discapacidad_Factor_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Discapacidad_Factor_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Discapacidad_Factor]  WITH CHECK ADD  CONSTRAINT [FK_Discapacidad_Factor_ibfk_2] FOREIGN KEY([IdFactor])
REFERENCES [dbo].[Factor] ([ID])
GO
ALTER TABLE [dbo].[Discapacidad_Factor] CHECK CONSTRAINT [FK_Discapacidad_Factor_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Grupo_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_ibfk_2] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([ID])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Grupo_ibfk_3]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_ibfk_3] FOREIGN KEY([IdMaestro])
REFERENCES [dbo].[Maestro] ([ID])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_ibfk_3]
GO
/****** Object:  ForeignKey [FK_Grupo_Alumno_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Grupo_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Alumno_ibfk_1] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([ID])
GO
ALTER TABLE [dbo].[Grupo_Alumno] CHECK CONSTRAINT [FK_Grupo_Alumno_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Grupo_Alumno_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Grupo_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Alumno_ibfk_2] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([ID])
GO
ALTER TABLE [dbo].[Grupo_Alumno] CHECK CONSTRAINT [FK_Grupo_Alumno_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Maestro_Grupo_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Maestro_Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Maestro_Grupo_ibfk_1] FOREIGN KEY([IdMaestro])
REFERENCES [dbo].[Maestro] ([ID])
GO
ALTER TABLE [dbo].[Maestro_Grupo] CHECK CONSTRAINT [FK_Maestro_Grupo_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Maestro_Grupo_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Maestro_Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Maestro_Grupo_ibfk_2] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([ID])
GO
ALTER TABLE [dbo].[Maestro_Grupo] CHECK CONSTRAINT [FK_Maestro_Grupo_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Programa_Actividad_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Programa_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Programa_Actividad_ibfk_1] FOREIGN KEY([IdPrograma])
REFERENCES [dbo].[Programa] ([ID])
GO
ALTER TABLE [dbo].[Programa_Actividad] CHECK CONSTRAINT [FK_Programa_Actividad_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Programa_Actividad_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Programa_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Programa_Actividad_ibfk_2] FOREIGN KEY([IdActividad])
REFERENCES [dbo].[Actividad] ([ID])
GO
ALTER TABLE [dbo].[Programa_Actividad] CHECK CONSTRAINT [FK_Programa_Actividad_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Rutina_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Rutina]  WITH CHECK ADD  CONSTRAINT [FK_Rutina_ibfk_2] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([ID])
GO
ALTER TABLE [dbo].[Rutina] CHECK CONSTRAINT [FK_Rutina_ibfk_2]
GO
/****** Object:  ForeignKey [FK_Rutina_ibfk_3]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Rutina]  WITH CHECK ADD  CONSTRAINT [FK_Rutina_ibfk_3] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([ID])
GO
ALTER TABLE [dbo].[Rutina] CHECK CONSTRAINT [FK_Rutina_ibfk_3]
GO
/****** Object:  ForeignKey [FK_Rutina_programa_ibfk_1]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Rutina_Programa]  WITH CHECK ADD  CONSTRAINT [FK_Rutina_programa_ibfk_1] FOREIGN KEY([IdRutina])
REFERENCES [dbo].[Rutina] ([ID])
GO
ALTER TABLE [dbo].[Rutina_Programa] CHECK CONSTRAINT [FK_Rutina_programa_ibfk_1]
GO
/****** Object:  ForeignKey [FK_Rutina_Programa_ibfk_2]    Script Date: 04/22/2013 23:51:56 ******/
ALTER TABLE [dbo].[Rutina_Programa]  WITH CHECK ADD  CONSTRAINT [FK_Rutina_Programa_ibfk_2] FOREIGN KEY([IdPrograma])
REFERENCES [dbo].[Programa] ([ID])
GO
ALTER TABLE [dbo].[Rutina_Programa] CHECK CONSTRAINT [FK_Rutina_Programa_ibfk_2]
GO
