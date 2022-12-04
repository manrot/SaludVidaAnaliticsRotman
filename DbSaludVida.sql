USE [master]
GO
/****** Object:  Database [DBSaludVida]    Script Date: 21/11/2022 13:42:26 ******/
CREATE DATABASE [DBSaludVida]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBSaludVida', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBSaludVida.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBSaludVida_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBSaludVida_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBSaludVida] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBSaludVida].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBSaludVida] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBSaludVida] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBSaludVida] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBSaludVida] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBSaludVida] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBSaludVida] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBSaludVida] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBSaludVida] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBSaludVida] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBSaludVida] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBSaludVida] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBSaludVida] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBSaludVida] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBSaludVida] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBSaludVida] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBSaludVida] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBSaludVida] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBSaludVida] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBSaludVida] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBSaludVida] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBSaludVida] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBSaludVida] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBSaludVida] SET RECOVERY FULL 
GO
ALTER DATABASE [DBSaludVida] SET  MULTI_USER 
GO
ALTER DATABASE [DBSaludVida] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBSaludVida] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBSaludVida] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBSaludVida] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBSaludVida] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBSaludVida] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBSaludVida', N'ON'
GO
ALTER DATABASE [DBSaludVida] SET QUERY_STORE = OFF
GO
USE [DBSaludVida]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[IdPaciente] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido1] [varchar](50) NOT NULL,
	[Apellido2] [varchar](50) NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[IdPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[IdCita] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [bigint] NOT NULL,
	[IdMedico] [int] NOT NULL,
	[IdConsultorio] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdHorario] [int] NOT NULL,
	[CostoConsulta] [varchar](50) NOT NULL,
	[IdEspecialidad] [int] NOT NULL,
 CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED 
(
	[IdCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ReportePacientesCitas]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReportePacientesCitas]
AS
SELECT dbo.Pacientes.Nombre, dbo.Pacientes.Apellido1, dbo.Pacientes.Apellido2, dbo.Pacientes.Identificacion, dbo.Citas.Fecha, dbo.Citas.IdCita
FROM     dbo.Pacientes INNER JOIN
                  dbo.Citas ON dbo.Pacientes.IdPaciente = dbo.Citas.IdPaciente
GO
/****** Object:  Table [dbo].[Especialidades]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades](
	[IdEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[NombreEspecialidad] [varchar](50) NOT NULL,
	[Descripcion] [nvarchar](400) NULL,
 CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED 
(
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[IdMedico] [int] IDENTITY(1,1) NOT NULL,
	[NombreMedico] [varchar](50) NOT NULL,
	[Apellido1] [varchar](50) NOT NULL,
	[Apellido2] [varchar](50) NULL,
	[NumeroLicenciaMedica] [varchar](50) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[IdEspecialidad] [int] NOT NULL,
 CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[IdMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ReporteMedicosCitas]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReporteMedicosCitas]
AS
SELECT dbo.Medicos.NombreMedico AS Nombre, dbo.Medicos.Apellido1, dbo.Medicos.Apellido2, dbo.Medicos.Identificacion, dbo.Medicos.NumeroLicenciaMedica AS Licencia, dbo.Especialidades.NombreEspecialidad AS Especialidad, 
                  dbo.Citas.Fecha, dbo.Citas.IdCita
FROM     dbo.Medicos INNER JOIN
                  dbo.Citas ON dbo.Medicos.IdMedico = dbo.Citas.IdMedico INNER JOIN
                  dbo.Especialidades ON dbo.Citas.IdEspecialidad = dbo.Especialidades.IdEspecialidad
GO
/****** Object:  Table [dbo].[Horarios]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios](
	[IdHorario] [int] IDENTITY(1,1) NOT NULL,
	[HoraInit] [time](7) NOT NULL,
	[HoraEnd] [time](7) NOT NULL,
 CONSTRAINT [PK_Horarios] PRIMARY KEY CLUSTERED 
(
	[IdHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CitasAtendidas]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CitasAtendidas]
AS
SELECT dbo.Pacientes.Nombre AS NombrePaciente, dbo.Pacientes.Apellido1 AS Apellido1Paciente, dbo.Pacientes.Apellido2 AS Apellido2Paciente, dbo.Citas.Fecha, dbo.Medicos.NombreMedico, dbo.Medicos.Apellido1 AS Apellid1Medico, 
                  dbo.Medicos.Apellido2 AS Apellido2Medico, dbo.Citas.CostoConsulta AS Costo, dbo.Horarios.HoraInit, dbo.Horarios.HoraEnd, dbo.Citas.IdCita
FROM     dbo.Pacientes INNER JOIN
                  dbo.Citas ON dbo.Pacientes.IdPaciente = dbo.Citas.IdPaciente INNER JOIN
                  dbo.Horarios ON dbo.Citas.IdHorario = dbo.Horarios.IdHorario INNER JOIN
                  dbo.Medicos ON dbo.Citas.IdMedico = dbo.Medicos.IdMedico
GO
/****** Object:  View [dbo].[ReporteIngresos]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReporteIngresos]
AS
SELECT COUNT(IdCita) AS CitasTotales, SUM(CONVERT(float, CostoConsulta)) AS TotalIngresos
FROM     dbo.Citas
GO
/****** Object:  View [dbo].[PorcentajeAtencionMedico]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PorcentajeAtencionMedico]
AS
SELECT DISTINCT citas_1.IdMedico, COUNT(citas_1.IdMedico) AS CantidadDeCitas,
                      (SELECT COUNT(IdMedico) AS Expr1
                       FROM      dbo.Citas) AS TotalCitas, CONVERT(FLOAT, COUNT(citas_1.IdMedico) * 100) /
                      (SELECT COUNT(IdMedico) AS Expr1
                       FROM      dbo.Citas AS Citas_2) AS Porcentaje, dbo.Medicos.NombreMedico, dbo.Medicos.Apellido1, dbo.Medicos.Apellido2
FROM     dbo.citas AS citas_1 INNER JOIN
                  dbo.Medicos ON citas_1.IdMedico = dbo.Medicos.IdMedico
GROUP BY citas_1.IdMedico, dbo.Medicos.NombreMedico, dbo.Medicos.Apellido1, dbo.Medicos.Apellido2
GO
/****** Object:  View [dbo].[PorcentajeEspecialidadesAtendidas]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PorcentajeEspecialidadesAtendidas]
AS
SELECT DISTINCT citas_1.IdEspecialidad, COUNT(citas_1.IdEspecialidad) AS CantidadDeCitasEspecialidad,
                      (SELECT COUNT(IdEspecialidad) AS Expr1
                       FROM      dbo.Citas) AS TotalCitas, CONVERT(FLOAT, COUNT(citas_1.IdEspecialidad) * 100) /
                      (SELECT COUNT(IdEspecialidad) AS Expr1
                       FROM      dbo.Citas AS Citas_2) AS Porcentaje, dbo.Especialidades.NombreEspecialidad
FROM     dbo.citas AS citas_1 INNER JOIN
                  dbo.Especialidades ON citas_1.IdEspecialidad = dbo.Especialidades.IdEspecialidad
GROUP BY citas_1.IdEspecialidad, dbo.Especialidades.NombreEspecialidad
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultorios]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultorios](
	[IdConsultorio] [int] IDENTITY(1,1) NOT NULL,
	[NombreConsultorio] [varchar](50) NOT NULL,
	[NumeroConsultorio] [int] NOT NULL,
 CONSTRAINT [PK_Consultorios] PRIMARY KEY CLUSTERED 
(
	[IdConsultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipoMedico]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipoMedico](
	[IdEquipo] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreEquipo] [varchar](50) NOT NULL,
	[Descripcion] [nvarchar](300) NULL,
	[Estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_EquipoMedico] PRIMARY KEY CLUSTERED 
(
	[IdEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relacion_Consultorio_EquiposMedicos]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relacion_Consultorio_EquiposMedicos](
	[Id_Relacion] [bigint] IDENTITY(1,1) NOT NULL,
	[IdConsultorio] [int] NOT NULL,
	[IdEquipoMedico] [bigint] NOT NULL,
 CONSTRAINT [PK_Relacion_Consultorio_EquiposMedicos] PRIMARY KEY CLUSTERED 
(
	[Id_Relacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relacion_Consultorio_Especialidades]    Script Date: 21/11/2022 13:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relacion_Consultorio_Especialidades](
	[IdRelacion] [bigint] IDENTITY(1,1) NOT NULL,
	[IdConsultorio] [int] NOT NULL,
	[IdEspecialidad] [int] NOT NULL,
 CONSTRAINT [PK_Relacion_Consultorio_Especialidades] PRIMARY KEY CLUSTERED 
(
	[IdRelacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Citas] ON 

INSERT [dbo].[Citas] ([IdCita], [IdPaciente], [IdMedico], [IdConsultorio], [Fecha], [IdHorario], [CostoConsulta], [IdEspecialidad]) VALUES (1, 1, 2, 1, CAST(N'2022-11-16' AS Date), 9, N'9000', 3)
INSERT [dbo].[Citas] ([IdCita], [IdPaciente], [IdMedico], [IdConsultorio], [Fecha], [IdHorario], [CostoConsulta], [IdEspecialidad]) VALUES (2, 2, 4, 1, CAST(N'2022-11-20' AS Date), 13, N'3444', 4)
INSERT [dbo].[Citas] ([IdCita], [IdPaciente], [IdMedico], [IdConsultorio], [Fecha], [IdHorario], [CostoConsulta], [IdEspecialidad]) VALUES (3, 1, 2, 1, CAST(N'2022-11-24' AS Date), 14, N'10000', 6)
SET IDENTITY_INSERT [dbo].[Citas] OFF
GO
SET IDENTITY_INSERT [dbo].[Consultorios] ON 

INSERT [dbo].[Consultorios] ([IdConsultorio], [NombreConsultorio], [NumeroConsultorio]) VALUES (1, N'Consultorio principal', 1)
SET IDENTITY_INSERT [dbo].[Consultorios] OFF
GO
SET IDENTITY_INSERT [dbo].[EquipoMedico] ON 

INSERT [dbo].[EquipoMedico] ([IdEquipo], [NombreEquipo], [Descripcion], [Estado]) VALUES (1, N'Bisturi', N'Sirve para cortar', N'Activo')
INSERT [dbo].[EquipoMedico] ([IdEquipo], [NombreEquipo], [Descripcion], [Estado]) VALUES (2, N'Gasas', N'sirven para detener sangre', N'Activo')
SET IDENTITY_INSERT [dbo].[EquipoMedico] OFF
GO
SET IDENTITY_INSERT [dbo].[Especialidades] ON 

INSERT [dbo].[Especialidades] ([IdEspecialidad], [NombreEspecialidad], [Descripcion]) VALUES (1, N'Medicina General', N'Es para ver el cuerpo entero')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [NombreEspecialidad], [Descripcion]) VALUES (2, N'Geriatría', NULL)
INSERT [dbo].[Especialidades] ([IdEspecialidad], [NombreEspecialidad], [Descripcion]) VALUES (3, N'Oftalmología', NULL)
INSERT [dbo].[Especialidades] ([IdEspecialidad], [NombreEspecialidad], [Descripcion]) VALUES (4, N'Urología', NULL)
INSERT [dbo].[Especialidades] ([IdEspecialidad], [NombreEspecialidad], [Descripcion]) VALUES (5, N'Oncología', NULL)
INSERT [dbo].[Especialidades] ([IdEspecialidad], [NombreEspecialidad], [Descripcion]) VALUES (6, N'Ginecología', NULL)
SET IDENTITY_INSERT [dbo].[Especialidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Horarios] ON 

INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (1, CAST(N'08:00:00' AS Time), CAST(N'08:30:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (3, CAST(N'08:30:00' AS Time), CAST(N'09:00:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (4, CAST(N'09:00:00' AS Time), CAST(N'09:30:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (5, CAST(N'09:30:00' AS Time), CAST(N'10:00:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (6, CAST(N'10:00:00' AS Time), CAST(N'10:30:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (7, CAST(N'10:30:00' AS Time), CAST(N'11:00:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (9, CAST(N'11:00:00' AS Time), CAST(N'11:30:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (10, CAST(N'11:30:00' AS Time), CAST(N'12:00:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (11, CAST(N'13:30:00' AS Time), CAST(N'14:00:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (12, CAST(N'14:00:00' AS Time), CAST(N'14:30:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (13, CAST(N'14:30:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (14, CAST(N'15:00:00' AS Time), CAST(N'15:30:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (15, CAST(N'15:30:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (16, CAST(N'16:00:00' AS Time), CAST(N'16:30:00' AS Time))
INSERT [dbo].[Horarios] ([IdHorario], [HoraInit], [HoraEnd]) VALUES (17, CAST(N'16:30:00' AS Time), CAST(N'17:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Horarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicos] ON 

INSERT [dbo].[Medicos] ([IdMedico], [NombreMedico], [Apellido1], [Apellido2], [NumeroLicenciaMedica], [Identificacion], [IdEspecialidad]) VALUES (2, N'2', N'2', N'2', N'2', N'2', 6)
INSERT [dbo].[Medicos] ([IdMedico], [NombreMedico], [Apellido1], [Apellido2], [NumeroLicenciaMedica], [Identificacion], [IdEspecialidad]) VALUES (3, N'3', N'3', N'3', N'3', N'3', 4)
INSERT [dbo].[Medicos] ([IdMedico], [NombreMedico], [Apellido1], [Apellido2], [NumeroLicenciaMedica], [Identificacion], [IdEspecialidad]) VALUES (4, N'Andres', N'Ramirez', N'Ramirez', N'1234234', N'0603030309', 4)
SET IDENTITY_INSERT [dbo].[Medicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacientes] ON 

INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido1], [Apellido2], [Identificacion], [Telefono]) VALUES (1, N'Rotman', N'Vargas', N'Parra', N'604020598', N'84382323')
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido1], [Apellido2], [Identificacion], [Telefono]) VALUES (2, N'Karolay', N'Moli', N'Artavia', N'0604050128', N'43526544')
SET IDENTITY_INSERT [dbo].[Pacientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Relacion_Consultorio_EquiposMedicos] ON 

INSERT [dbo].[Relacion_Consultorio_EquiposMedicos] ([Id_Relacion], [IdConsultorio], [IdEquipoMedico]) VALUES (3, 1, 2)
SET IDENTITY_INSERT [dbo].[Relacion_Consultorio_EquiposMedicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Relacion_Consultorio_Especialidades] ON 

INSERT [dbo].[Relacion_Consultorio_Especialidades] ([IdRelacion], [IdConsultorio], [IdEspecialidad]) VALUES (1, 1, 4)
INSERT [dbo].[Relacion_Consultorio_Especialidades] ([IdRelacion], [IdConsultorio], [IdEspecialidad]) VALUES (3, 1, 3)
SET IDENTITY_INSERT [dbo].[Relacion_Consultorio_Especialidades] OFF
GO
ALTER TABLE [dbo].[EquipoMedico] ADD  CONSTRAINT [DF_EquipoMedico_Estado]  DEFAULT ('Activo') FOR [Estado]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Consultorios] FOREIGN KEY([IdConsultorio])
REFERENCES [dbo].[Consultorios] ([IdConsultorio])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Consultorios]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Especialidades] FOREIGN KEY([IdEspecialidad])
REFERENCES [dbo].[Especialidades] ([IdEspecialidad])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Especialidades]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Horarios] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horarios] ([IdHorario])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Horarios]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Medicos] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Medicos]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Pacientes] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Pacientes] ([IdPaciente])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Pacientes]
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_Especialidades] FOREIGN KEY([IdEspecialidad])
REFERENCES [dbo].[Especialidades] ([IdEspecialidad])
GO
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [FK_Medicos_Especialidades]
GO
ALTER TABLE [dbo].[Relacion_Consultorio_EquiposMedicos]  WITH CHECK ADD  CONSTRAINT [FK_Relacion_Consultorio_EquiposMedicos_Consultorios] FOREIGN KEY([IdConsultorio])
REFERENCES [dbo].[Consultorios] ([IdConsultorio])
GO
ALTER TABLE [dbo].[Relacion_Consultorio_EquiposMedicos] CHECK CONSTRAINT [FK_Relacion_Consultorio_EquiposMedicos_Consultorios]
GO
ALTER TABLE [dbo].[Relacion_Consultorio_EquiposMedicos]  WITH CHECK ADD  CONSTRAINT [FK_Relacion_Consultorio_EquiposMedicos_EquipoMedico] FOREIGN KEY([IdEquipoMedico])
REFERENCES [dbo].[EquipoMedico] ([IdEquipo])
GO
ALTER TABLE [dbo].[Relacion_Consultorio_EquiposMedicos] CHECK CONSTRAINT [FK_Relacion_Consultorio_EquiposMedicos_EquipoMedico]
GO
ALTER TABLE [dbo].[Relacion_Consultorio_Especialidades]  WITH CHECK ADD  CONSTRAINT [FK_Relacion_Consultorio_Especialidades_Consultorios] FOREIGN KEY([IdConsultorio])
REFERENCES [dbo].[Consultorios] ([IdConsultorio])
GO
ALTER TABLE [dbo].[Relacion_Consultorio_Especialidades] CHECK CONSTRAINT [FK_Relacion_Consultorio_Especialidades_Consultorios]
GO
ALTER TABLE [dbo].[Relacion_Consultorio_Especialidades]  WITH CHECK ADD  CONSTRAINT [FK_Relacion_Consultorio_Especialidades_Especialidades] FOREIGN KEY([IdEspecialidad])
REFERENCES [dbo].[Especialidades] ([IdEspecialidad])
GO
ALTER TABLE [dbo].[Relacion_Consultorio_Especialidades] CHECK CONSTRAINT [FK_Relacion_Consultorio_Especialidades_Especialidades]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Pacientes"
            Begin Extent = 
               Top = 30
               Left = 39
               Bottom = 193
               Right = 233
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Citas"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Horarios"
            Begin Extent = 
               Top = 129
               Left = 558
               Bottom = 270
               Right = 752
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Medicos"
            Begin Extent = 
               Top = 7
               Left = 774
               Bottom = 170
               Right = 1025
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CitasAtendidas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CitasAtendidas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "citas_1"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Medicos"
            Begin Extent = 
               Top = 7
               Left = 306
               Bottom = 170
               Right = 573
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PorcentajeAtencionMedico'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PorcentajeAtencionMedico'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "citas_1"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Especialidades"
            Begin Extent = 
               Top = 7
               Left = 306
               Bottom = 148
               Right = 556
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PorcentajeEspecialidadesAtendidas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PorcentajeEspecialidadesAtendidas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Citas"
            Begin Extent = 
               Top = 45
               Left = 162
               Bottom = 208
               Right = 372
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReporteIngresos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReporteIngresos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Medicos"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 299
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Citas"
            Begin Extent = 
               Top = 7
               Left = 347
               Bottom = 170
               Right = 541
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Especialidades"
            Begin Extent = 
               Top = 7
               Left = 589
               Bottom = 148
               Right = 823
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReporteMedicosCitas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReporteMedicosCitas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[32] 4[29] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Pacientes"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Citas"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportePacientesCitas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportePacientesCitas'
GO
USE [master]
GO
ALTER DATABASE [DBSaludVida] SET  READ_WRITE 
GO
