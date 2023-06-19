INSERT INTO ItemPrefix (
	[Id],
    [Value]
) 
VALUES (
	'b5a0eb64-cb9f-47f8-b237-439c30ed170b',
	'Minecraft'
);

INSERT INTO ItemPostfix (
	[Id],
    [Value]
) 
VALUES (
	'eecdd304-2fb3-46b5-ae04-5a429640bd5d',
	'12'
);

INSERT INTO ModType (
	[Id],
    [FullName],
    [ShortName]
) 
VALUES (
	'17c59ca7-f168-4929-929e-f06745abe58d',
	'Minecraft',
    'minecraft'
);

INSERT INTO ItemType (
	[Id],
    [Value]
) 
VALUES (
	'8d9f9455-4c58-4c54-afd2-5c64ba1ea6aa',
	'Fluid'
);

INSERT INTO Item (
	[Id],
    [Name],
    [Description],
    [ItemTypeId],
    [ModTypeId],
    [ItemPrefixId],
    [ItemPostfixId] 
) 
VALUES (
	'de17ef40-6d85-4c12-9d5d-4251bf991de7',
	'Water',
    'H20 Just add a water',
    '8d9f9455-4c58-4c54-afd2-5c64ba1ea6aa',
    '17c59ca7-f168-4929-929e-f06745abe58d',
    'b5a0eb64-cb9f-47f8-b237-439c30ed170b',
    'eecdd304-2fb3-46b5-ae04-5a429640bd5d'
);
