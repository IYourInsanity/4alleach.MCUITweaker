CREATE TABLE ItemType (
	[Id]			      uniqueidentifier NOT NULL,
	[Value]   	          nvarchar(50),

	CONSTRAINT Pk_ItemType PRIMARY KEY ( Id )
);

CREATE TABLE ModType (
	[Id]			      uniqueidentifier NOT NULL,
    [FullName]            nvarchar(100),
	[ShortName]  	      nvarchar(50),

	CONSTRAINT Pk_ModType PRIMARY KEY ( Id )
);

CREATE TABLE ItemPrefix (
	[Id]			      uniqueidentifier NOT NULL,
    [Value]   	          nvarchar(50),

	CONSTRAINT Pk_ItemPrefix PRIMARY KEY ( Id )
);

CREATE TABLE ItemPostfix (
	[Id]			      uniqueidentifier NOT NULL,
    [Value]   	          nvarchar(50),

	CONSTRAINT Pk_ItemPostfix PRIMARY KEY ( Id )
);

CREATE TABLE Item (
	[Id]			      uniqueidentifier NOT NULL,
    [Name]                nvarchar(100),
    [Description]         nvarchar(500),
    [ItemTypeId]   	      uniqueidentifier NULL,
    [ModTypeId]           uniqueidentifier NULL,
    [ItemPrefixId]        uniqueidentifier NULL,
    [ItemPostfixId]       uniqueidentifier NULL,

	CONSTRAINT Pk_Item PRIMARY KEY ( Id ),
    FOREIGN KEY ( ItemTypeId ) REFERENCES ItemType( Id ),
    FOREIGN KEY ( ModTypeId ) REFERENCES ModType( Id ),
    FOREIGN KEY ( ItemPrefixId ) REFERENCES ItemPrefix( Id ),
    FOREIGN KEY ( ItemPostfixId ) REFERENCES ItemPostfix( Id )
);

CREATE INDEX idx_Item_TypeId ON Item ( TypeId );
CREATE INDEX idx_Item_ModTypeId ON Item ( ModTypeId );
CREATE INDEX idx_Item_ItemPrefixId ON Item ( ItemPrefixId );
CREATE INDEX idx_Item_ItemPostfixId ON Item ( ItemPostfixId );
