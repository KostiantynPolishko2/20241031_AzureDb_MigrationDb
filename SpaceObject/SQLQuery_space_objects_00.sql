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

INSERT INTO [dbo].[asteroid_images] (name, path, FK_IdAsteroidItem)
VALUES
('cerera', 'https://docfiles.blob.core.windows.net/files/asteroid/cerera.png', 1),
('pallada', 'https://docfiles.blob.core.windows.net/files/asteroid/pallada.png', 2),
('yunona', 'https://docfiles.blob.core.windows.net/files/asteroid/yunona.png', 3),
('astreya', 'https://docfiles.blob.core.windows.net/files/asteroid/astreya.png', 5);

SELECT * FROM [dbo].[asteroid_items];
SELECT * FROM [dbo].[asteroid_properties];
SELECT * FROM [dbo].[asteroid_images];

SELECT [ai].[name], 'class ' + [ai].[type] AS [category], [ap].[size], [ap].[weight], [ap].[speed], [am].[path] FROM [dbo].[asteroid_items] AS [ai]
INNER JOIN [dbo].[asteroid_properties] AS [ap]
ON [ai].[id] = [ap].[FK_IdAsteroidItem]
INNER JOIN [dbo].[asteroid_images] AS [am]
ON [ai].[id] = [am].[FK_IdAsteroidItem]
WHERE [ai].[type] = 'c'

SELECT * FROM [dbo].[__EFMigrationsHistory];

INSERT INTO [dbo].[__EFMigrationsHistory] (MigrationId, ProductVersion)
VALUES
('20241103094705_SpaceObjects_00', '8.0.10'),
('20241103132921_SpaceObjects_01', '8.0.10'),
('20241103140909_SpaceObjects_02', '8.0.10');