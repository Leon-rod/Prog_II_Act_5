CREATE DATABASE db_turnos_5
GO
USE [db_turnos_5]
GO
CREATE TABLE T_TURNOS(
[id] [int] IDENTITY(1,1) NOT NULL,
[fecha] [varchar](10) NULL,
[hora] [varchar](5) NULL,
[cliente] [varchar](100) NULL,
CONSTRAINT [PK_T_TURNOS] PRIMARY KEY (id)
)
CREATE TABLE T_SERVICIOS(
[id] [int] NOT NULL,
[nombre] [varchar](50) NOT NULL,
[costo] [int] NOT NULL,
[enPromocion] [varchar](1) NOT NULL,
CONSTRAINT [PK_T_SERVICIOS] PRIMARY KEY (id)
)
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion])
VALUES (1, N'Lavado de cabello', 500, N'N')
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion])
VALUES (2, N'Corte', 2000, N'S')
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion])
VALUES (3, N'Tintura', 3500, N'N')
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion])
VALUES (4, N'Alisado', 12000, N'N')
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion])
VALUES (5, N'Nutrición', 12500, N'S')
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion])
VALUES (6, N'Tratamiento de Keratina', 20000, N'N')

CREATE TABLE T_DETALLES_TURNO(
[id_turno] [int] NOT NULL,
[id_servicio] [int] NOT NULL,
[observaciones] [varchar](200) NULL,
CONSTRAINT [PK_T_DETALLES_TURNO] PRIMARY KEY (id_turno),
CONSTRAINT FK_TDT_TURNOS FOREIGN KEY (id_turno) REFERENCES T_TURNOS(id),
CONSTRAINT FK_TDT_SERVICIOS FOREIGN KEY (id_servicio) REFERENCES T_SERVICIOS(id)
)