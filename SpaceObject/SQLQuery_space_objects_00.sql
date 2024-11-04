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

SELECT [ai].[name], 'class ' + [ai].[type] AS [category], [ap].[size], [ap].[weight], [ap].[speed] FROM [dbo].[asteroid_items] AS [ai]
INNER JOIN [dbo].[asteroid_properties] AS [ap]
ON [ai].[id] = [ap].[FK_IdAsteroidItem]
WHERE [ai].[type] = 'c'