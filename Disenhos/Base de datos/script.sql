create database came;

use came;


-- TABLAS DE ENTIDADES
create table Medicamento(
ID int not null primary key ,
Nombre varchar(100)not null,
Descripcion varchar(200), 
Horas varchar(100));

create table Tutor(
ID int not null primary key,
Nombre varchar(100)not null,
Direccion varchar(100)not null,
Telefono varchar(10)not null,
Celular varchar(10));

create table Alergia(
ID int not null primary key,
Nombre varchar(100)not null,
Descripcion varchar(200),
Tratamiento varchar(100));

create table Rutina(
ID int not null primary key,
Nombre varchar(100)not null,
IdMaestro int not null,
Lugar varchar(100)not null,
Finalidad varchar(200)not null,
Horario varchar(100)not null);

create table Programa(
ID int not null primary key,
Nombre varchar(100)not null);

create table Actividad(
ID int not null primary key,
Nombre varchar(100)not null,
Tipo int not null);

create table Ejercicio(
ID int not null primary key,
Nombre varchar(100)not null,
Descripcion varchar(200),
Tipo int not null);


create table Grupo(
ID int not null primary key,
Nombre varchar(100)not null,
Capacidad int not null default 0);

create table Maestro(
ID int not null primary key,
Nombre varchar(100)not null,
Direccion varchar(200)not null,
Email varchar(100), 
Telefono varchar(10),
Celular varchar(10),
RFC varchar(13)not null,
FechaIngreso date not null);


create table Diagnostico(
ID int not null primary key,
Nombre varchar(100)not null,
Descripcion varchar(200));

create table Discapacidad(
ID int not null primary key,
Nombre varchar(100)not null,
Descripcion varchar(200));

create table Factor(
ID int not null primary key,
Nombre varchar(100)not null);

create table Alumno(
ID int not null primary key,
Nombre varchar(100)not null,
Apellidos varchar(100)not null,
Direccion varchar(100)not null,
IdTutor int not null,
FechaNacimiento date not null,
FechaRegistro date not null,
CURP varchar(18)not null,
GradoAcademico varchar(50)not null,
TallaUniforme varchar(20)not null,
IdDiagnostico int not null,
IdGrupo int not null,
IdRutina int not null,
foreign key(IdTutor) references Tutor(ID),
foreign key(IdDiagnostico) references Diagnostico(ID),
foreign key(IdGrupo) references Grupo(ID),
foreign key(IdRutina) references Rutina(ID));

create table Usuario(
ID int not null primary key,
Nombre varchar(100)not null,
Direccion varchar(100)not null,
Telefono varchar(10),
Email varchar(100),
Celular varchar(10),
Permisos int not null default 0);


-- TABLAS DE RELACIONES 
create table Alumno_Medicamento(
ID int not null primary key,
IdAlumno int not null,
IdMedicamento int not null,
foreign key(IdAlumno) references Alumno(ID),
foreign key(IdMedicamento) references Medicamento(ID));


create table Alumno_Tutor(
ID int not null primary key,
IdAlumno int not null,
IdTutor int not null,
foreign key(IdAlumno) references Alumno(ID),
foreign key(IdTutor) references Tutor(ID));



create table Alumno_Alergia(
ID int not null primary key,
IdAlumno int not null,
IdAlergia int not null,
foreign key(IdAlumno) references Alumno(ID),
foreign key(IdAlergia) references Alergia(ID));


create table Maestro_Grupo(
ID int not null primary key,
IdMaestro int not null,
IdGrupo int not null,
foreign key(IdMaestro) references Maestro(ID),
foreign key(IdGrupo) references Grupo(ID));


create table Diagnostico_Discapacidad(
ID int not null primary key,
IdDiagnostico int not null,
IdDiscapacidad int not null,
foreign key(IdDiagnostico) references Diagnostico(ID),
foreign key(IdDiscapacidad) references Discapacidad(ID));

create table Rutina_Programa(
ID int not null primary key,
IdRutina int not null,
IdPrograma int not null,
foreign key(IdRutina)references Rutina(ID),
foreign key (IdPrograma)references Programa(ID));

create table Programa_Actividad(
ID int not null primary key,
IdPrograma int not null,
IdActividad int not null,
foreign key(IdPrograma)references Programa(ID),
foreign key(IdActividad)references Actividad(ID));

create table Actividad_Ejercicio(
ID int not null primary key,
IdActividad int not null,
IdEjercicio int not null,
foreign key(IdEjercicio)references Ejercicio(ID),
foreign key(IdActividad)references Actividad(ID));


create table Discapacidad_Factor(
ID int not null primary key,
IdDiscapacidad int not null,
IdFactor int not null,
foreign key(IdDiscapacidad) references Discapacidad(ID),
foreign key(IdFactor) references Factor(ID));

