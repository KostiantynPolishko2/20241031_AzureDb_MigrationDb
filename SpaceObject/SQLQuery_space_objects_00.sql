USE [space_objects];

INSERT INTO [dbo].[asteroid_items] (name, type)
VALUES
('cerera', 'a'),
('pallada', 'b'),
('yunona', 's');

INSERT INTO [dbo].[asteroid_properties] (size, weight, speed, FK_isAsteroidItem)
VALUES
(464, 3.939, 18, 1),
(512, 2.11, 1, 2),
(234, 2.82, 1, 3);

SELECT * FROM [dbo].[asteroid_items];
SELECT * FROM [dbo].[asteroid_properties];