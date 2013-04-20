create database Came;
go
use Came;
go
-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'actividads'
CREATE TABLE [dbo].[Actividad] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Tipo] int  NOT NULL
);
GO

-- Creating table 'actividad_ejercicio'
CREATE TABLE [dbo].[Actividad_Ejercicio] (
    [ID] int  NOT NULL,
    [IdActividad] int  NOT NULL,
    [IdEjercicio] int  NOT NULL
);
GO

-- Creating table 'alergias'
CREATE TABLE [dbo].[Alergia] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Descripcion] varchar(1000)  NULL,
    [Tratamiento] varchar(1000)  NULL
);
GO

-- Creating table 'alumnoes'
CREATE TABLE [dbo].[Alumno] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Apellidos] varchar(1000)  NOT NULL,
    [Direccion] varchar(1000)  NOT NULL,
    [IdTutor] int  NOT NULL,
    [FechaNacimiento] datetime  NOT NULL,
    [FechaRegistro] datetime  NOT NULL,
    [CURP] varchar(1000)  NOT NULL,
    [GradoAcademico] varchar(1000)  NOT NULL,
    [TallaUniforme] varchar(1000)  NOT NULL,
    [IdDiagnostico] int  NOT NULL,
    [IdGrupo] int  NOT NULL,
    [IdRutina] int  NOT NULL
);
GO

-- Creating table 'alumno_alergia'
CREATE TABLE [dbo].[Alumno_Alergia] (
    [ID] int  NOT NULL,
    [IdAlumno] int  NOT NULL,
    [IdAlergia] int  NOT NULL
);
GO

-- Creating table 'alumno_medicamento'
CREATE TABLE [dbo].[Alumno_Medicamento] (
    [ID] int  NOT NULL,
    [IdAlumno] int  NOT NULL,
    [IdMedicamento] int  NOT NULL
);

GO

-- Creating table 'diagnosticoes'
CREATE TABLE [dbo].[Diagnostico] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Descripcion] varchar(1000)  NULL
);
GO

-- Creating table 'diagnostico_discapacidad'
CREATE TABLE [dbo].[Diagnostico_Discapacidad] (
    [ID] int  NOT NULL,
    [IdDiagnostico] int  NOT NULL,
    [IdDiscapacidad] int  NOT NULL
);
GO

-- Creating table 'discapacidad_factor'
CREATE TABLE [dbo].[Discapacidad_Factor] (
    [ID] int  NOT NULL,
    [IdDiscapacidad] int  NOT NULL,
    [IdFactor] int  NOT NULL
);
GO

-- Creating table 'discapacidads'
CREATE TABLE [dbo].[Discapacidad] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Descripcion] varchar(1000)  NULL
);
GO

-- Creating table 'ejercicios'
CREATE TABLE [dbo].[Ejercicio] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Descripcion] varchar(1000)  NULL,
    [Tipo] int  NOT NULL
);
GO

-- Creating table 'factors'
CREATE TABLE [dbo].[Factor] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL
);
GO

-- Creating table 'grupoes'
CREATE TABLE [dbo].[Grupo] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Capacidad] int  NOT NULL
);
GO


-- creating table 'grupo_alumno'
CREATE TABLE [dbo].[Grupo_Alumno] (
	[ID] int NOT NULL,
	[IdGrupo] int NOT NULL,
	[IdAlumno] int NOT NULL
);
GO

-- Creating table 'maestroes'
CREATE TABLE [dbo].[Maestro] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Direccion] varchar(1000)  NOT NULL,
    [Email] varchar(1000)  NULL,
    [Telefono] varchar(1000)  NULL,
    [Celular] varchar(1000)  NULL,
    [Rfc] varchar(1000)  NOT NULL,
    [FechaIngreso] datetime  NOT NULL
);
GO

-- Creating table 'maestro_grupo'
CREATE TABLE [dbo].[Maestro_Grupo] (
    [ID] int  NOT NULL,
    [IdMaestro] int  NOT NULL,
    [IdGrupo] int  NOT NULL
);
GO

-- Creating table 'medicamentoes'
CREATE TABLE [dbo].[Medicamento] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Descripcion] varchar(1000)  NULL,
    [Horas] varchar(1000)  NULL
);
GO

-- Creating table 'programas'
CREATE TABLE [dbo].[Programa] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL
);
GO

-- Creating table 'programa_actividad'
CREATE TABLE [dbo].[Programa_Actividad] (
    [ID] int  NOT NULL,
    [IdPrograma] int  NOT NULL,
    [IdActividad] int  NOT NULL
);
GO

-- Creating table 'rutinas'
CREATE TABLE [dbo].[Rutina] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [IdMaestro] int  NOT NULL,
    [Lugar] varchar(1000)  NOT NULL,
    [Finalidad] varchar(1000)  NOT NULL,
    [Horario] varchar(1000)  NOT NULL
);
GO

-- Creating table 'rutina_programa'
CREATE TABLE [dbo].[Rutina_Programa] (
    [ID] int  NOT NULL,
    [IdRutina] int  NOT NULL,
    [IdPrograma] int  NOT NULL
);
GO

-- Creating table 'tutors'
CREATE TABLE [dbo].[Tutor] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Direccion] varchar(1000)  NOT NULL,
    [Telefono] varchar(1000)  NOT NULL,
    [Celular] varchar(1000)  NULL
);
GO

-- Creating table 'usuarios'
CREATE TABLE [dbo].[Usuario] (
    [ID] int  NOT NULL,
    [Nombre] varchar(1000)  NOT NULL,
    [Direccion] varchar(1000)  NOT NULL,
    [Telefono] varchar(1000)  NULL,
    [Email] varchar(1000)  NULL,
    [Celular] varchar(1000)  NULL,
    [Permisos] int  NOT NULL,
    [UserName] varchar(1000)  NOT NULL,
    [Contrasenha] varchar(1000)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'actividads'
ALTER TABLE [dbo].[Actividad]
ADD CONSTRAINT [PK_Actividad]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'actividad_ejercicio'
ALTER TABLE [dbo].[Actividad_Ejercicio]
ADD CONSTRAINT [PK_Actividad_Ejercicio]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'alergias'
ALTER TABLE [dbo].[Alergia]
ADD CONSTRAINT [PK_Alergia]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'alumnoes'
ALTER TABLE [dbo].[Alumno]
ADD CONSTRAINT [PK_Alumno]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'alumno_alergia'
ALTER TABLE [dbo].[Alumno_Alergia]
ADD CONSTRAINT [PK_Alumno_Alergia]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'alumno_medicamento'
ALTER TABLE [dbo].[Alumno_Medicamento]
ADD CONSTRAINT [PK_Alumno_Medicamento]
    PRIMARY KEY CLUSTERED ([ID] ASC);

GO

-- Creating primary key on [ID] in table 'diagnosticoes'
ALTER TABLE [dbo].[Diagnostico]
ADD CONSTRAINT [PK_Diagnostico]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'diagnostico_discapacidad'
ALTER TABLE [dbo].[Diagnostico_Discapacidad]
ADD CONSTRAINT [PK_Diagnostico_Discapacidad]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'discapacidad_factor'
ALTER TABLE [dbo].[Discapacidad_Factor]
ADD CONSTRAINT [PK_Discapacidad_Factor]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'discapacidads'
ALTER TABLE [dbo].[Discapacidad]
ADD CONSTRAINT [PK_Discapacidad]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ejercicios'
ALTER TABLE [dbo].[Ejercicio]
ADD CONSTRAINT [PK_Ejercicio]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'factors'
ALTER TABLE [dbo].[Factor]
ADD CONSTRAINT [PK_Factor]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'grupoes'
ALTER TABLE [dbo].[Grupo]
ADD CONSTRAINT [PK_Grupo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

--creating primary key on [ID] in table 'grupo_alumno'
ALTER TABLE [dbo].[Grupo_Alumno]
ADD CONSTRAINT [PK_Grupo_Alumno]
	PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'maestroes'
ALTER TABLE [dbo].[Maestro]
ADD CONSTRAINT [PK_Maestro]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'maestro_grupo'
ALTER TABLE [dbo].[Maestro_Grupo]
ADD CONSTRAINT [PK_Maestro_Grupo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'medicamentoes'
ALTER TABLE [dbo].[Medicamento]
ADD CONSTRAINT [PK_Medicamento]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'programas'
ALTER TABLE [dbo].[Programa]
ADD CONSTRAINT [PK_Programa]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'programa_actividad'
ALTER TABLE [dbo].[Programa_Actividad]
ADD CONSTRAINT [PK_Programa_Actividad]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'rutinas'
ALTER TABLE [dbo].[Rutina]
ADD CONSTRAINT [PK_Rutina]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'rutina_programa'
ALTER TABLE [dbo].[Rutina_Programa]
ADD CONSTRAINT [PK_Rutina_Programa]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tutors'
ALTER TABLE [dbo].[Tutor]
ADD CONSTRAINT [PK_Tutor]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'usuarios'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- -------------------------------------------------

-- Creating foreign key on [IdActividad] in table 'actividad_ejercicio'
ALTER TABLE [dbo].[Actividad_Ejercicio]
ADD CONSTRAINT [FK_Actividad_Ejercicio_ibfk_2]
    FOREIGN KEY ([IdActividad])
    REFERENCES [dbo].[Actividad]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_actividad_ejercicio_ibfk_2'
CREATE INDEX [IX_FK_Actividad_Ejercicio_ibfk_2]
ON [dbo].[Actividad_Ejercicio]
    ([IdActividad]);
GO

-- Creating foreign key on [IdActividad] in table 'programa_actividad'
ALTER TABLE [dbo].[Programa_Actividad]
ADD CONSTRAINT [FK_Programa_Actividad_ibfk_2]
    FOREIGN KEY ([IdActividad])
    REFERENCES [dbo].[Actividad]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_programa_actividad_ibfk_2'
CREATE INDEX [IX_FK_Programa_Actividad_ibfk_2]
ON [dbo].[Programa_Actividad]
    ([IdActividad]);
GO

-- Creating foreign key on [IdEjercicio] in table 'actividad_ejercicio'
ALTER TABLE [dbo].[Actividad_Ejercicio]
ADD CONSTRAINT [FK_Actividad_Ejercicio_ibfk_1]
    FOREIGN KEY ([IdEjercicio])
    REFERENCES [dbo].[Ejercicio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_actividad_ejercicio_ibfk_1'
CREATE INDEX [IX_FK_Actividad_Ejercicio_ibfk_1]
ON [dbo].[Actividad_Ejercicio]
    ([IdEjercicio]);
GO

-- Creating foreign key on [IdAlergia] in table 'alumno_alergia'
ALTER TABLE [dbo].[Alumno_Alergia]
ADD CONSTRAINT [FK_Alumno_Alergia_ibfk_2]
    FOREIGN KEY ([IdAlergia])
    REFERENCES [dbo].[Alergia]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alumno_alergia_ibfk_2'
CREATE INDEX [IX_FK_Alumno_Alergia_ibfk_2]
ON [dbo].[Alumno_Alergia]
    ([IdAlergia]);
GO

-- Creating foreign key on [IdAlumno] in table 'alumno_alergia'
ALTER TABLE [dbo].[Alumno_Alergia]
ADD CONSTRAINT [FK_Alumno_Alergia_ibfk_1]
    FOREIGN KEY ([IdAlumno])
    REFERENCES [dbo].[Alumno]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alumno_alergia_ibfk_1'
CREATE INDEX [IX_FK_Alumno_Alergia_ibfk_1]
ON [dbo].[Alumno_Alergia]
    ([IdAlumno]);
GO

-- Creating foreign key on [IdTutor] in table 'alumnoes'
ALTER TABLE [dbo].[Alumno]
ADD CONSTRAINT [FK_Alumno_ibfk_1]
    FOREIGN KEY ([IdTutor])
    REFERENCES [dbo].[Tutor]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alumno_ibfk_1'
CREATE INDEX [IX_FK_Alumno_ibfk_1]
ON [dbo].[Alumno]
    ([IdTutor]);
GO

-- Creating foreign key on [IdDiagnostico] in table 'alumnoes'
ALTER TABLE [dbo].[Alumno]
ADD CONSTRAINT [FK_Alumno_ibfk_2]
    FOREIGN KEY ([IdDiagnostico])
    REFERENCES [dbo].[Diagnostico]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alumno_ibfk_2'
CREATE INDEX [IX_FK_Alumno_ibfk_2]
ON [dbo].[Alumno]
    ([IdDiagnostico]);
GO

-- Creating foreign key on [IdGrupo] in table 'alumnoes'
ALTER TABLE [dbo].[Alumno]
ADD CONSTRAINT [FK_Alumno_ibfk_3]
    FOREIGN KEY ([IdGrupo])
    REFERENCES [dbo].[Grupo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alumno_ibfk_3'
CREATE INDEX [IX_FK_Alumno_ibfk_3]
ON [dbo].[Alumno]
    ([IdGrupo]);
GO

-- Creating foreign key on [IdRutina] in table 'alumnoes'
ALTER TABLE [dbo].[Alumno]
ADD CONSTRAINT [FK_Alumno_ibfk_4]
    FOREIGN KEY ([IdRutina])
    REFERENCES [dbo].[Rutina]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alumno_ibfk_4'
CREATE INDEX [IX_FK_Alumno_ibfk_4]
ON [dbo].[Alumno]
    ([IdRutina]);
GO

-- Creating foreign key on [IdAlumno] in table 'alumno_medicamento'
ALTER TABLE [dbo].[Alumno_Medicamento]
ADD CONSTRAINT [FK_Alumno_Medicamento_ibfk_1]
    FOREIGN KEY ([IdAlumno])
    REFERENCES [dbo].[Alumno]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alumno_medicamento_ibfk_1'
CREATE INDEX [IX_FK_Alumno_Medicamento_ibfk_1]
ON [dbo].[Alumno_Medicamento]
    ([IdAlumno]);


GO

-- Creating foreign key on [IdMedicamento] in table 'alumno_medicamento'
ALTER TABLE [dbo].[Alumno_Medicamento]
ADD CONSTRAINT [FK_Alumno_Medicamento_ibfk_2]
    FOREIGN KEY ([IdMedicamento])
    REFERENCES [dbo].[Medicamento]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alumno_medicamento_ibfk_2'
CREATE INDEX [IX_FK_Alumno_Medicamento_ibfk_2]
ON [dbo].[Alumno_Medicamento]
    ([IdMedicamento]);


GO

-- Creating foreign key on [IdDiagnostico] in table 'diagnostico_discapacidad'
ALTER TABLE [dbo].[Diagnostico_Discapacidad]
ADD CONSTRAINT [FK_Diagnostico_Discapacidad_ibfk_1]
    FOREIGN KEY ([IdDiagnostico])
    REFERENCES [dbo].[Diagnostico]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_diagnostico_discapacidad_ibfk_1'
CREATE INDEX [IX_FK_Diagnostico_Discapacidad_ibfk_1]
ON [dbo].[Diagnostico_Discapacidad]
    ([IdDiagnostico]);
GO

-- Creating foreign key on [IdDiagnostico] in table 'discapacidad_factor'
ALTER TABLE [dbo].[Discapacidad_Factor]
ADD CONSTRAINT [FK_Discapacidad_Factor_ibfk_1]
    FOREIGN KEY ([IdDiscapacidad])
    REFERENCES [dbo].[Discapacidad]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_discapacidad_factor_ibfk_1'
CREATE INDEX [IX_FK_Diagostico_Factor_ibfk_1]
ON [dbo].[Discapacidad_Factor]
    ([IdDiscapacidad]);
GO

-- Creating foreign key on [IdDiscapacidad] in table 'diagnostico_discapacidad'
ALTER TABLE [dbo].[Diagnostico_Discapacidad]
ADD CONSTRAINT [FK_Diagnostico_Discapacidad_ibfk_2]
    FOREIGN KEY ([IdDiscapacidad])
    REFERENCES [dbo].[Discapacidad]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_diagnostico_discapacidad_ibfk_2'
CREATE INDEX [IX_FK_Diagnostico_Discapacidad_ibfk_2]
ON [dbo].[Diagnostico_Discapacidad]
    ([IdDiscapacidad]);
GO

-- Creating foreign key on [IdFactor] in table 'discapacidad_factor'
ALTER TABLE [dbo].[Discapacidad_Factor]
ADD CONSTRAINT [FK_Discapacidad_Factor_ibfk_2]
    FOREIGN KEY ([IdFactor])
    REFERENCES [dbo].[Factor]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_discapacidad_factor_ibfk_2'
CREATE INDEX [IX_FK_Diagostico_Factor_ibfk_2]
ON [dbo].[Discapacidad_Factor]
    ([IdFactor]);
GO

-- Creating foreign key on [IdGrupo] in table 'maestro_grupo'
ALTER TABLE [dbo].[Maestro_Grupo]
ADD CONSTRAINT [FK_Maestro_Grupo_ibfk_2]
    FOREIGN KEY ([IdGrupo])
    REFERENCES [dbo].[Grupo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_maestro_grupo_ibfk_2'
CREATE INDEX [IX_FK_Maestro_Grupo_ibfk_2]
ON [dbo].[Maestro_Grupo]
    ([IdGrupo]);
GO

-- Creating foreign key on [IdMaestro] in table 'maestro_grupo'
ALTER TABLE [dbo].[Maestro_Grupo]
ADD CONSTRAINT [FK_Maestro_Grupo_ibfk_1]
    FOREIGN KEY ([IdMaestro])
    REFERENCES [dbo].[Maestro]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_maestro_grupo_ibfk_1'
CREATE INDEX [IX_FK_Maestro_Grupo_ibfk_1]
ON [dbo].[Maestro_Grupo]
    ([IdMaestro]);
GO


ALTER TABLE [dbo].[Grupo_Alumno]
ADD CONSTRAINT [FK_Grupo_Alumno_ibfk_1]
	FOREIGN KEY ([IdGrupo])
	REFERENCES [dbo].[Grupo]
		([ID])
		ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX [IX_FK_Grupo_Alumno_ibfk_1]
ON [dbo].[Grupo_Alumno]
    ([IdGrupo]);
GO


ALTER TABLE [dbo].[Grupo_Alumno]
ADD CONSTRAINT [FK_Grupo_Alumno_ibfk_2]
	FOREIGN KEY ([IdAlumno])
	REFERENCES [dbo].[Alumno]
		([ID])
		ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX [IX_FK_Grupo_Alumno_ibfk_2]
ON [dbo].[Grupo_Alumno]
    ([IdAlumno]);
GO


-- Creating foreign key on [IdPrograma] in table 'programa_actividad'
ALTER TABLE [dbo].[Programa_Actividad]
ADD CONSTRAINT [FK_Programa_Actividad_ibfk_1]
    FOREIGN KEY ([IdPrograma])
    REFERENCES [dbo].[Programa]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_programa_actividad_ibfk_1'
CREATE INDEX [IX_FK_Programa_Actividad_ibfk_1]
ON [dbo].[Programa_Actividad]
    ([IdPrograma]);
GO

-- Creating foreign key on [IdPrograma] in table 'rutina_programa'
ALTER TABLE [dbo].[Rutina_Programa]
ADD CONSTRAINT [FK_Rutina_Programa_ibfk_2]
    FOREIGN KEY ([IdPrograma])
    REFERENCES [dbo].[Programa]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_rutina_programa_ibfk_2'
CREATE INDEX [IX_FK_Rutina_Programa_ibfk_2]
ON [dbo].[Rutina_Programa]
    ([IdPrograma]);
GO

-- Creating foreign key on [IdRutina] in table 'rutina_programa'
ALTER TABLE [dbo].[Rutina_programa]
ADD CONSTRAINT [FK_Rutina_programa_ibfk_1]
    FOREIGN KEY ([IdRutina])
    REFERENCES [dbo].[Rutina]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_rutina_programa_ibfk_1'
CREATE INDEX [IX_FK_Rutina_Programa_ibfk_1]
ON [dbo].[Rutina_Programa]
    ([IdRutina]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------