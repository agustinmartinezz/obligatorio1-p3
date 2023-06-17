INSERT INTO dbo.TipoCabanias VALUES ('Cabaña Aurora', 'Una cabaña acogedora rodeada de naturaleza', 50),
('Cabaña del Lago', 'Una cabaña con vista al lago', 75)
,('Cabaña del Bosque', 'Una cabaña rodeada de árboles', 65)
,('Cabaña de la Montaña', 'Una cabaña en las faldas de la montaña', 80)
,('Cabaña de la Playa', 'Una cabaña a pocos pasos del mar', 90)
,('Cabaña de la Pradera', 'Una cabaña en medio de una pradera', 70)
,('Cabaña de la Ciudad', 'Una cabaña en la ciudad con todas las comodidades', 100)
,('Cabaña del Valle', 'Una cabaña en un valle rodeado de montañas', 85)
,('Cabaña del Rio', 'Una cabaña con vista al rio', 80)
,('Cabaña del Pueblo', 'Una cabaña en un pueblo pintoresco', 60)
,('Cabaña del Campo', 'Una cabaña en medio del campo', 75)
,('Cabaña de la Isla', 'Una cabaña en una isla privada', 150)
,('Cabaña de la Selva', 'Una cabaña en la selva con todas las comodidades', 120)
,('Cabaña de la Laguna', 'Una cabaña en las orillas de una laguna', 95)
,('Cabaña del Desierto', 'Una cabaña en el desierto', 110)
,('Cabaña del Glaciar', 'Una cabaña con vista a un glaciar', 130)
,('Cabaña de la Estepa', 'Una cabaña en la estepa', 70)
,('Cabaña del Puerto', 'Una cabaña con vista al puerto', 90)
,('Cabaña del Oceano', 'Una cabaña frente al oceano', 120)
,('Cabaña del Bosque Encantado', 'Una cabaña en un bosque encantado', 95);

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
(1,'La Cabaña de Iron Man','Equipada con tecnología de punta de Stark Industries',0,1,1,2,'Imagenes/la_cabania_de_iron_man_001.png'),
(2,'La Cabaña de Mickey Mouse','Ubicada en el corazón de Disneyland, perfecta para disfrutar de la magia del parque',1,0,2,3,'Imagenes/la_cabania_de_mickey_mouse_001.jpeg'),
(3,'La Cabaña de Hulk','Situada en la cima de una montaña, con vistas impresionantes de la naturaleza',0,1,3,4,'Imagenes/la_cabania_de_hulk_001.jpg'),
(4,'La Cabaña de Buzz Lightyear','Ubicada en el espacio exterior, con amplias vistas de las estrellas y planetas',1,1,4,2,'Imagenes/la_cabania_de_buzz_lightyear_001.jpeg'),
(5,'La Cabaña de Spider-Man','Escondida en un callejón de Nueva York, con acceso fácil a los sitios turísticos cercanos',0,0,5,5,'Imagenes/la_cabania_de_spiderman_001.jpg'),
(6,'La Cabaña de Batman','Ubicada en una gruta subterránea, con una gran colección de tecnología de Batman',1,1,6,2,'Imagenes/la_cabania_de_batman_001.jpeg'),
(7,'La Cabaña de Los Increíbles','En un bosque tranquilo, perfecta para relajarse después de una larga misión de salvar al mundo',1,0,7,3,'Imagenes/la_cabania_de_los_increibles_001.jpeg'),
(8,'La Cabaña de Thor','Situada en un acantilado con vistas al océano',0,1,8,4,'Imagenes/la_cabania_de_thor_001.jpg'),
(9,'La Cabaña de Elsa','En medio de un paisaje nevado',1,1,9,2,'Imagenes/la_cabania_de_elsa_001.jpg'),
(10,'La Cabaña de Capitán América','Ubicada en un prado con vistas al horizonte, con un escudo del Capitán América en la entrada',0,0,10,5,'Imagenes/la_cabania_de_capitan_america_001.jpg')

INSERT INTO dbo.Mantenimientos VALUES
('01/03/2022','Limpieza completa de la cabaña, incluyendo cambio de sábanas y toallas','150','Juan el limpiador',5),
('15/05/2022','Revisión y reparación del sistema de calefacción','300','Pedro el técnico',3),
('22/06/2022','Limpieza del exterior de la cabaña, incluyendo los muebles de jardín','100','Sofía la limpiadora',1),
('10/07/2022','Reparación del techo de la cabaña después de una tormenta','500','Carlos el técnico',7),
('02/08/2022','Limpieza de las ventanas y puertas de la cabaña','50','María la limpiadora',2),
('19/08/2022','Revisión y reparación del sistema de fontanería','400','Pedro el técnico',9),
('30/08/2022','Limpieza completa de la cocina, incluyendo la nevera y el horno','200','Juan el limpiador',6),
('05/09/2022','Revisión y reparación del sistema de iluminación','250','Carlos el técnico',4),
('22/09/2022','Limpieza de las alfombras y tapicería de la cabaña','100','Sofía la limpiadora',8),
('10/10/2022','Reparación de las puertas y ventanas de la cabaña','350','Pedro el técnico',1)