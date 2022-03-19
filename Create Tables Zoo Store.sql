IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CUSTOMER' and xtype='U')
CREATE TABLE CUSTOMER
(
ID INT IDENTITY NOT NULL,
FIRST_NAME VARCHAR(64) NOT NULL,
LAST_NAME VARCHAR(64) NOT NULL,
[ADDRESS] VARCHAR(128) NOT NULL,
EMAIL VARCHAR(64) NOT NULL,
LOGIN_ID INT NOT NULL,
CART_ID INT NOT NULL,
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'CUSTOMER'
AND TABLE_SCHEMA ='dbo' )

BEGIN
ALTER TABLE CUSTOMER ADD CONSTRAINT [PK_CUSTOMER_ID] PRIMARY KEY(ID)
END
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'ADMINISTRATOR' and XTYPE = 'U')
CREATE TABLE ADMINISTRATOR
(
ID INT IDENTITY NOT NULL, 
FIRST_NAME VARCHAR(64) NOT NULL,
LAST_NAME VARCHAR(64) NOT NULL,
[ADDRESS] VARCHAR(128) NOT NULL,
LOGIN_ID INT NOT NULL, 
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'ADMINISTRATOR'
AND TABLE_SCHEMA ='dbo' )

BEGIN
ALTER TABLE ADMINISTRATOR ADD CONSTRAINT [PK_ADMINISTRATOR_ID] PRIMARY KEY(ID)
END 
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'LOGIN' AND XTYPE = 'U')
CREATE TABLE [LOGIN]
(
ID INT IDENTITY NOT NULL, 
USERNAME VARCHAR(64) NOT NULL,
[PASSWORD] VARCHAR(64) NOT NULL,
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'LOGIN'
AND TABLE_SCHEMA ='dbo' )
BEGIN
ALTER TABLE [LOGIN] ADD CONSTRAINT [PK_LOGIN_ID] PRIMARY KEY(ID)
END 
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'GUEST' AND XTYPE = 'U')
CREATE TABLE GUEST
(
ID INT IDENTITY NOT NULL, 
EMAIL VARCHAR(64) NOT NULL,
FIRST_NAME VARCHAR(64) NOT NULL,
LAST_NAME VARCHAR(64) NOT NULL,
[ADDRESS] VARCHAR(128) NOT NULL,
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'GUEST'
AND TABLE_SCHEMA ='dbo' )
BEGIN
ALTER TABLE GUEST ADD CONSTRAINT PK_GUEST_ID PRIMARY KEY(ID)
END 
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'ORDER' AND XTYPE = 'U')
CREATE TABLE [ORDER]
(
ID INT IDENTITY NOT NULL, 
CART_ID INT NOT NULL,
ORDER_DATE DATE NOT NULL,
DELIVERY_DATE DATE NOT NULL,
[STATUS] SMALLINT NOT NULL
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'ORDER'
AND TABLE_SCHEMA ='dbo' )
BEGIN
ALTER TABLE [ORDER] ADD CONSTRAINT PK_ORDER_ID PRIMARY KEY(ID)
END 
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'CART' AND XTYPE = 'U')
CREATE TABLE CART
(
ID INT IDENTITY NOT NULL,
PRODUCT_QUANTITY INT NOT NULL,
TOTAL_MONEY FLOAT NOT NULL,
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'CART'
AND TABLE_SCHEMA ='dbo' )
BEGIN
ALTER TABLE CART ADD CONSTRAINT PK_CART_ID PRIMARY KEY(ID)
END 

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'PRODUCT' AND XTYPE = 'U')
CREATE TABLE PRODUCT
(
ID INT IDENTITY NOT NULL,
[TYPE_ID] INT NOT NULL,
[NAME] VARCHAR(128) NOT NULL,
CART_ID INT NOT NULL,
ANIMAL_TYPE_ID INT NOT NULL,
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'PRODUCT'
AND TABLE_SCHEMA ='dbo' )
BEGIN
ALTER TABLE PRODUCT ADD CONSTRAINT PK_PRODUCT_ID PRIMARY KEY(ID)
END
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'WAREHOUSE' AND XTYPE = 'U')
CREATE TABLE WAREHOUSE
(
ID INT IDENTITY NOT NULL,
PRODUCT_ID INT NOT NULL,
QUANTITY INT NOT NULL,
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'WAREHOUSE'
AND TABLE_SCHEMA ='dbo' )
BEGIN
ALTER TABLE WAREHOUSE ADD CONSTRAINT PK_WAREHOUSE_ID PRIMARY KEY(ID)
END
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'PRODUCT_TYPE' AND XTYPE = 'U')
CREATE TABLE PRODUCT_TYPE
(
ID INT IDENTITY NOT NULL,
[TYPE] SMALLINT NOT NULL,
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'PRODUCT_TYPE'
AND TABLE_SCHEMA ='dbo' )
BEGIN
ALTER TABLE PRODUCT_TYPE ADD CONSTRAINT PK_PRODUCT_TYPE_ID PRIMARY KEY(ID)
END
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'ANIMAL_TYPE' AND XTYPE = 'U')
CREATE TABLE ANIMAL_TYPE
(
ID INT IDENTITY NOT NULL,
[TYPE] SMALLINT NOT NULL,
AGE SMALLINT NOT NULL 
)
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
AND TABLE_NAME = 'ANIMAL_TYPE'
AND TABLE_SCHEMA ='dbo' )
BEGIN
ALTER TABLE ANIMAL_TYPE ADD CONSTRAINT PK_ANIMAL_TYPE_ID PRIMARY KEY(ID)
END
GO

-------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects  WHERE object_id = object_id(N'FK_LOGIN_ID') AND OBJECTPROPERTY(object_id, N'IsForeignKey') = 1)
BEGIN
    ALTER TABLE CUSTOMER ADD CONSTRAINT FK_LOGIN_ID FOREIGN KEY(LOGIN_ID) REFERENCES [LOGIN](ID)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects  WHERE object_id = object_id(N'FK_CART_ID ') AND OBJECTPROPERTY(object_id, N'IsForeignKey') = 1)
BEGIN
    ALTER TABLE CUSTOMER ADD CONSTRAINT FK_CART_ID FOREIGN KEY(CART_ID) REFERENCES CART(ID)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects  WHERE object_id = object_id(N'FK_PRODUCT_CART_ID') AND OBJECTPROPERTY(object_id, N'IsForeignKey') = 1)
BEGIN
    ALTER TABLE PRODUCT ADD CONSTRAINT FK_PRODUCT_CART_ID FOREIGN KEY(CART_ID) REFERENCES CART(ID)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects  WHERE object_id = object_id(N'ANIMAL_TYPE_ID') AND OBJECTPROPERTY(object_id, N'IsForeignKey') = 1)
BEGIN
    ALTER TABLE PRODUCT ADD CONSTRAINT FK_ANIMAL_TYPE_ID FOREIGN KEY(ANIMAL_TYPE_ID) REFERENCES ANIMAL_TYPE(ID)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects  WHERE object_id = object_id(N'FK_PRODUCT_TYPE_ID') AND OBJECTPROPERTY(object_id, N'IsForeignKey') = 1)
BEGIN
    ALTER TABLE PRODUCT ADD CONSTRAINT FK_PRODUCT_TYPE_ID FOREIGN KEY([TYPE_ID]) REFERENCES PRODUCT_TYPE(ID)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects  WHERE object_id = object_id(N'FK_ADMINISTRATORS_LOGIN_ID') AND OBJECTPROPERTY(object_id, N'IsForeignKey') = 1)
BEGIN
    ALTER TABLE ADMINISTRATOR ADD CONSTRAINT FK_ADMINISTRATORS_LOGIN_ID FOREIGN KEY(LOGIN_ID) REFERENCES [LOGIN](ID)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects  WHERE object_id = object_id(N'ORDER_CART_ID_FK') AND OBJECTPROPERTY(object_id, N'IsForeignKey') = 1)
BEGIN
    ALTER TABLE [ORDER] ADD CONSTRAINT ORDER_CART_ID_FK FOREIGN KEY(CART_ID) REFERENCES CART(ID)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects  WHERE object_id = object_id(N'FK_WAREHOUSE_PRODUCT_ID') AND OBJECTPROPERTY(object_id, N'IsForeignKey') = 1)
BEGIN
    ALTER TABLE WAREHOUSE ADD CONSTRAINT FK_WAREHOUSE_PRODUCT_ID FOREIGN KEY(PRODUCT_ID) REFERENCES PRODUCT(ID)
END
GO