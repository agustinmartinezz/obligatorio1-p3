INSERT INTO dbo.TipoCabanias VALUES ('Caba�a Aurora', 'Una caba�a acogedora rodeada de naturaleza', 50),
('Caba�a del Lago', 'Una caba�a con vista al lago', 75)
,('Caba�a del Bosque', 'Una caba�a rodeada de �rboles', 65)
,('Caba�a de la Monta�a', 'Una caba�a en las faldas de la monta�a', 80)
,('Caba�a de la Playa', 'Una caba�a a pocos pasos del mar', 90)
,('Caba�a de la Pradera', 'Una caba�a en medio de una pradera', 70)
,('Caba�a de la Ciudad', 'Una caba�a en la ciudad con todas las comodidades', 100)
,('Caba�a del Valle', 'Una caba�a en un valle rodeado de monta�as', 85)
,('Caba�a del Rio', 'Una caba�a con vista al rio', 80)
,('Caba�a del Pueblo', 'Una caba�a en un pueblo pintoresco', 60)
,('Caba�a del Campo', 'Una caba�a en medio del campo', 75)
,('Caba�a de la Isla', 'Una caba�a en una isla privada', 150)
,('Caba�a de la Selva', 'Una caba�a en la selva con todas las comodidades', 120)
,('Caba�a de la Laguna', 'Una caba�a en las orillas de una laguna', 95)
,('Caba�a del Desierto', 'Una caba�a en el desierto', 110)
,('Caba�a del Glaciar', 'Una caba�a con vista a un glaciar', 130)
,('Caba�a de la Estepa', 'Una caba�a en la estepa', 70)
,('Caba�a del Puerto', 'Una caba�a con vista al puerto', 90)
,('Caba�a del Oceano', 'Una caba�a frente al oceano', 120)
,('Caba�a del Bosque Encantado', 'Una caba�a en un bosque encantado', 95);

INSERT INTO dbo.Usuarios VALUES ('Juan Gonzalez','juangonzalez@gmail.com','Juan123')
,('Romina Lopez','rominalopez@gmail.com','Romina123')
,('Martin Rodriguez','martinrodriguez@gmail.com','Martin123'),('Peter Parker','peterparker@gmail.com','Spiderman123'),
('Clark Kent','clarkkent@gmail.com','Superman123'),
('Bruce Wayne','brucewayne@gmail.com','Batman123'),
('Tony Stark','tonystark@gmail.com','Ironman123'),
('Barry Allen','barryallen@gmail.com','Flash123'),
('Diana Prince','dianaprince@gmail.com','Wonderwoman123'),
('Wade Wilson','wadewilson@gmail.com','Deadpool123'),
('Arthur Curry','arthurcurry@gmail.com','Aquaman123'),
('Scott Lang','scottlang@gmail.com','Antman123'),
('Harley Quinn','harleyquinn@gmail.com','Crazy123'),
('Mickey Mouse','mickeymouse@gmail.com','Mouse123'),
('Donald','donal@gmail.com','Duck123'),
('Goofy','goofy@gmail.com','Goofy123'),
('Simba','simba@gmail.com','HakunaMatata123'),
('Aladdin','aladdin@gmail.com','Genie123');

INSERT INTO dbo.Cabanias VALUES 
(1,'La Caba�a de Iron Man','Equipada con tecnolog�a de punta de Stark Industries',0,1,1,2,'Imagenes/la_cabania_de_iron_man_001.png'),
(2,'La Caba�a de Mickey Mouse','Ubicada en el coraz�n de Disneyland, perfecta para disfrutar de la magia del parque',1,0,2,3,'Imagenes/la_cabania_de_mickey_mouse_001.jpeg'),
(3,'La Caba�a de Hulk','Situada en la cima de una monta�a, con vistas impresionantes de la naturaleza',0,1,3,4,'Imagenes/la_cabania_de_hulk_001.jpg'),
(4,'La Caba�a de Buzz Lightyear','Ubicada en el espacio exterior, con amplias vistas de las estrellas y planetas',1,1,4,2,'Imagenes/la_cabania_de_buzz_lightyear_001.jpeg'),
(5,'La Caba�a de Spider-Man','Escondida en un callej�n de Nueva York, con acceso f�cil a los sitios tur�sticos cercanos',0,0,5,5,'Imagenes/la_cabania_de_spiderman_001.jpg'),
(6,'La Caba�a de Batman','Ubicada en una gruta subterr�nea, con una gran colecci�n de tecnolog�a de Batman',1,1,6,2,'Imagenes/la_cabania_de_batman_001.jpeg'),
(7,'La Caba�a de Los Incre�bles','En un bosque tranquilo, perfecta para relajarse despu�s de una larga misi�n de salvar al mundo',1,0,7,3,'Imagenes/la_cabania_de_los_increibles_001.jpeg'),
(8,'La Caba�a de Thor','Situada en un acantilado con vistas al oc�ano',0,1,8,4,'Imagenes/la_cabania_de_thor_001.jpg'),
(9,'La Caba�a de Elsa','En medio de un paisaje nevado',1,1,9,2,'Imagenes/la_cabania_de_elsa_001.jpg'),
(10,'La Caba�a de Capit�n Am�rica','Ubicada en un prado con vistas al horizonte, con un escudo del Capit�n Am�rica en la entrada',0,0,10,5,'Imagenes/la_cabania_de_capitan_america_001.jpg')

INSERT INTO dbo.Mantenimientos VALUES
('01/03/2022','Limpieza completa de la caba�a, incluyendo cambio de s�banas y toallas','150','Juan el limpiador',5),
('15/05/2022','Revisi�n y reparaci�n del sistema de calefacci�n','300','Pedro el t�cnico',3),
('22/06/2022','Limpieza del exterior de la caba�a, incluyendo los muebles de jard�n','100','Sof�a la limpiadora',1),
('10/07/2022','Reparaci�n del techo de la caba�a despu�s de una tormenta','500','Carlos el t�cnico',7),
('02/08/2022','Limpieza de las ventanas y puertas de la caba�a','50','Mar�a la limpiadora',2),
('19/08/2022','Revisi�n y reparaci�n del sistema de fontaner�a','400','Pedro el t�cnico',9),
('30/08/2022','Limpieza completa de la cocina, incluyendo la nevera y el horno','200','Juan el limpiador',6),
('05/09/2022','Revisi�n y reparaci�n del sistema de iluminaci�n','250','Carlos el t�cnico',4),
('22/09/2022','Limpieza de las alfombras y tapicer�a de la caba�a','100','Sof�a la limpiadora',8),
('10/10/2022','Reparaci�n de las puertas y ventanas de la caba�a','350','Pedro el t�cnico',1)