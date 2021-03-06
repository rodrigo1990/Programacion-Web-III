if not exists(select * from sys.databases where name = 'PW3TP_20181C_Tareas')
BEGIN
	CREATE DATABASE [PW3TP_20181C_Tareas]
END

CREATE TABLE [dbo].[ArchivoTarea](
	[IdArchivoTarea] [int] IDENTITY(1,1) NOT NULL,
	[RutaArchivo] [nvarchar](max) NOT NULL,
	[IdTarea] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_ArchivoTarea] PRIMARY KEY CLUSTERED 
(
	[IdArchivoTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carpeta]    Script Date: 4/11/2018 2:08:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carpeta](
	[IdCarpeta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Carpetas] PRIMARY KEY CLUSTERED 
(
	[IdCarpeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComentarioTarea]    Script Date: 4/11/2018 2:08:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComentarioTarea](
	[IdComentarioTarea] [int] IDENTITY(1,1) NOT NULL,
	[Texto] [nvarchar](max) NOT NULL,
	[IdTarea] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[IdComentarioTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 4/11/2018 2:08:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[IdTarea] [int] IDENTITY(1,1) NOT NULL,
	[IdCarpeta] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[EstimadoHoras] [decimal](18,2) NULL,
	[FechaFin] [datetime] NULL,
	[Prioridad] [smallint] NOT NULL,
	[Completada] [smallint] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/11/2018 2:08:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Contrasenia] [nvarchar](50) NOT NULL,
	[Activo] [smallint] NOT NULL,
	[FechaRegistracion] [datetime] NOT NULL,
	[FechaActivacion] [datetime] NULL,
	[CodigoActivacion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

