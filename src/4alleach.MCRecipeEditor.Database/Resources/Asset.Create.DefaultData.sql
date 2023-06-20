INSERT INTO ItemType ( [Id], [Value] ) 
VALUES ( '8d9f9455-4c58-4c54-afd2-5c64ba1ea6aa', 'Fluid' ),
       ( '276a7692-9213-4cfb-8d0b-e39dc60996d4', 'Block' ),
       ( '0154b8eb-bc89-4967-ab7a-5ed9956fdbaa', 'Entity' );

INSERT INTO ModType ( [Id], [FullName], [ShortName] ) 
VALUES ( '17c59ca7-f168-4929-929e-f06745abe58d', 'Minecraft', 'minecraft' );


INSERT INTO Item ( [Id], [Name], [Description], [ItemTypeId], [ModTypeId] ) 
VALUES ( 'de17ef40-6d85-4c12-9d5d-4251bf991de7', 'Air', 'Fill the void with something', '276a7692-9213-4cfb-8d0b-e39dc60996d4', '17c59ca7-f168-4929-929e-f06745abe58d' );
