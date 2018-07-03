USE PW3TP_20181C_Tareas


INSERT INTO dbo.Usuario
VALUES('RODRIGO','REYNOSO','mcd77.1990@gmail.com','123Reynoso321',1,GETDATE(),GETDATE(),1231312312)



insert into Carpeta
VALUES (1,'Carpeta1','Carpeta1',GETDATE()),
		(1,'Carpeta2','Carpeta2',GETDATE()),
		(1,'Carpeta3','Carpeta3',GETDATE()),
		(1,'Carpeta3','Carpeta3',GETDATE())


GO
insert into tarea(IdCarpeta,IdUsuario,Nombre,Descripcion,EstimadoHoras,FechaFin,Prioridad,Completada,FechaCreacion)
VALUES(1,20,'PRUEBA','PRUEBA',2.2,GETDATE(),4,1,GETDATE()),
		(1,20,'PRUEBA2','PRUEBA',2.2,GETDATE(),4,1,GETDATE()),
		(1,20,'PRUEBA3','PRUEBA',2.2,GETDATE(),4,1,GETDATE()),
		(1,20,'PRUEBA4','PRUEBA',2.2,GETDATE(),4,1,GETDATE()),
		(1,20,'PRUEBA5','PRUEBA',2.2,GETDATE(),4,1,GETDATE())
GO
INSERT INTO ComentarioTarea
VALUES('HOLA',1,GETDATE()),
('HOLA',1,GETDATE()),
('HOLA',1,GETDATE()),
('HOLA',1,GETDATE())