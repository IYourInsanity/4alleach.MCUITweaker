INSERT INTO ItemPrefix (
	Id,
    [Value]
) 
VALUES (
	'B5A0EB64-CB9F-47F8-B237-439C30ED170B',
	'Minecraft'
);

INSERT INTO ItemPostfix (
	Id,
    [Value]
) 
VALUES (
	'EECDD304-2FB3-46B5-AE04-5A429640BD5D',
	'12'
);

INSERT INTO ModType (
	Id,
    FullName,
    ShortName
) 
VALUES (
	'17C59CA7-F168-4929-929E-F06745ABE58D',
	'Minecraft',
    'minecraft'
);

INSERT INTO ItemType (
	Id,
    [Value]
) 
VALUES (
	'8D9F9455-4C58-4C54-AFD2-5C64BA1EA6AA',
	'Fluid'
);

INSERT INTO Item (
	Id,
    [Name],
    [Description],
    ItemTypeId,
    ModTypeId,
    ItemPrefixId,
    ItemPostfixId 
) 
VALUES (
	'DE17EF40-6D85-4C12-9D5D-4251BF991DE7',
	'Water',
    'H20 Just add a water',
    '8D9F9455-4C58-4C54-AFD2-5C64BA1EA6AA',
    '17C59CA7-F168-4929-929E-F06745ABE58D',
    'B5A0EB64-CB9F-47F8-B237-439C30ED170B',
    'EECDD304-2FB3-46B5-AE04-5A429640BD5D'
);
