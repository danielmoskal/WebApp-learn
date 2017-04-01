
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/01/2017 11:10:46
-- Generated from EDMX file: D:\Kodowanie\C#\GIT\WebApp learn\drugaApka\Models\RentFlatModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RentFlatDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BALANCESSet'
CREATE TABLE [dbo].[BALANCESSet] (
    [BALANCE_ID] int IDENTITY(1,1) NOT NULL,
    [validFrom] nvarchar(max)  NOT NULL,
    [validTo] nvarchar(max)  NOT NULL,
    [value] nvarchar(max)  NOT NULL,
    [PAYS_PAY_ID] int  NOT NULL,
    [USERS_USER_ID] int  NOT NULL
);
GO

-- Creating table 'PAYSSet'
CREATE TABLE [dbo].[PAYSSet] (
    [PAY_ID] int IDENTITY(1,1) NOT NULL,
    [user] nvarchar(max)  NOT NULL,
    [date] nvarchar(max)  NOT NULL,
    [USERS_USER_ID] int  NOT NULL
);
GO

-- Creating table 'USERSSet'
CREATE TABLE [dbo].[USERSSet] (
    [USER_ID] int IDENTITY(1,1) NOT NULL,
    [firstName] nvarchar(max)  NOT NULL,
    [lastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EXPENSESSet'
CREATE TABLE [dbo].[EXPENSESSet] (
    [EXPENSE_ID] int IDENTITY(1,1) NOT NULL,
    [RentalFee] nvarchar(max)  NOT NULL,
    [Rent] nvarchar(max)  NOT NULL,
    [CurrentBill] nvarchar(max)  NOT NULL,
    [GasBill] nvarchar(max)  NOT NULL,
    [InternetBill] nvarchar(max)  NOT NULL,
    [ExpenseDate] nvarchar(max)  NOT NULL,
    [ExpensePerMonth] nvarchar(max)  NOT NULL,
    [EXTRA_EXPENSES_EXTRA_EXPENSES_ID] int  NOT NULL
);
GO

-- Creating table 'USERS_EXPENSESSet'
CREATE TABLE [dbo].[USERS_EXPENSESSet] (
    [ID_US_EXP] int IDENTITY(1,1) NOT NULL,
    [USERS_USER_ID] int  NOT NULL,
    [EXPENSES_EXPENSE_ID] int  NOT NULL
);
GO

-- Creating table 'EXTRA_EXPENSESSet'
CREATE TABLE [dbo].[EXTRA_EXPENSESSet] (
    [EXTRA_EXPENSES_ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BALANCE_ID] in table 'BALANCESSet'
ALTER TABLE [dbo].[BALANCESSet]
ADD CONSTRAINT [PK_BALANCESSet]
    PRIMARY KEY CLUSTERED ([BALANCE_ID] ASC);
GO

-- Creating primary key on [PAY_ID] in table 'PAYSSet'
ALTER TABLE [dbo].[PAYSSet]
ADD CONSTRAINT [PK_PAYSSet]
    PRIMARY KEY CLUSTERED ([PAY_ID] ASC);
GO

-- Creating primary key on [USER_ID] in table 'USERSSet'
ALTER TABLE [dbo].[USERSSet]
ADD CONSTRAINT [PK_USERSSet]
    PRIMARY KEY CLUSTERED ([USER_ID] ASC);
GO

-- Creating primary key on [EXPENSE_ID] in table 'EXPENSESSet'
ALTER TABLE [dbo].[EXPENSESSet]
ADD CONSTRAINT [PK_EXPENSESSet]
    PRIMARY KEY CLUSTERED ([EXPENSE_ID] ASC);
GO

-- Creating primary key on [ID_US_EXP] in table 'USERS_EXPENSESSet'
ALTER TABLE [dbo].[USERS_EXPENSESSet]
ADD CONSTRAINT [PK_USERS_EXPENSESSet]
    PRIMARY KEY CLUSTERED ([ID_US_EXP] ASC);
GO

-- Creating primary key on [EXTRA_EXPENSES_ID] in table 'EXTRA_EXPENSESSet'
ALTER TABLE [dbo].[EXTRA_EXPENSESSet]
ADD CONSTRAINT [PK_EXTRA_EXPENSESSet]
    PRIMARY KEY CLUSTERED ([EXTRA_EXPENSES_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PAYS_PAY_ID] in table 'BALANCESSet'
ALTER TABLE [dbo].[BALANCESSet]
ADD CONSTRAINT [FK_PAYSBALANCES]
    FOREIGN KEY ([PAYS_PAY_ID])
    REFERENCES [dbo].[PAYSSet]
        ([PAY_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PAYSBALANCES'
CREATE INDEX [IX_FK_PAYSBALANCES]
ON [dbo].[BALANCESSet]
    ([PAYS_PAY_ID]);
GO

-- Creating foreign key on [USERS_USER_ID] in table 'PAYSSet'
ALTER TABLE [dbo].[PAYSSet]
ADD CONSTRAINT [FK_USERSPAYS]
    FOREIGN KEY ([USERS_USER_ID])
    REFERENCES [dbo].[USERSSet]
        ([USER_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_USERSPAYS'
CREATE INDEX [IX_FK_USERSPAYS]
ON [dbo].[PAYSSet]
    ([USERS_USER_ID]);
GO

-- Creating foreign key on [USERS_USER_ID] in table 'BALANCESSet'
ALTER TABLE [dbo].[BALANCESSet]
ADD CONSTRAINT [FK_USERSBALANCES]
    FOREIGN KEY ([USERS_USER_ID])
    REFERENCES [dbo].[USERSSet]
        ([USER_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_USERSBALANCES'
CREATE INDEX [IX_FK_USERSBALANCES]
ON [dbo].[BALANCESSet]
    ([USERS_USER_ID]);
GO

-- Creating foreign key on [USERS_USER_ID] in table 'USERS_EXPENSESSet'
ALTER TABLE [dbo].[USERS_EXPENSESSet]
ADD CONSTRAINT [FK_USERSUSERS_EXPENSES]
    FOREIGN KEY ([USERS_USER_ID])
    REFERENCES [dbo].[USERSSet]
        ([USER_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_USERSUSERS_EXPENSES'
CREATE INDEX [IX_FK_USERSUSERS_EXPENSES]
ON [dbo].[USERS_EXPENSESSet]
    ([USERS_USER_ID]);
GO

-- Creating foreign key on [EXPENSES_EXPENSE_ID] in table 'USERS_EXPENSESSet'
ALTER TABLE [dbo].[USERS_EXPENSESSet]
ADD CONSTRAINT [FK_EXPENSESUSERS_EXPENSES]
    FOREIGN KEY ([EXPENSES_EXPENSE_ID])
    REFERENCES [dbo].[EXPENSESSet]
        ([EXPENSE_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EXPENSESUSERS_EXPENSES'
CREATE INDEX [IX_FK_EXPENSESUSERS_EXPENSES]
ON [dbo].[USERS_EXPENSESSet]
    ([EXPENSES_EXPENSE_ID]);
GO

-- Creating foreign key on [EXTRA_EXPENSES_EXTRA_EXPENSES_ID] in table 'EXPENSESSet'
ALTER TABLE [dbo].[EXPENSESSet]
ADD CONSTRAINT [FK_EXTRA_EXPENSESEXPENSES]
    FOREIGN KEY ([EXTRA_EXPENSES_EXTRA_EXPENSES_ID])
    REFERENCES [dbo].[EXTRA_EXPENSESSet]
        ([EXTRA_EXPENSES_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EXTRA_EXPENSESEXPENSES'
CREATE INDEX [IX_FK_EXTRA_EXPENSESEXPENSES]
ON [dbo].[EXPENSESSet]
    ([EXTRA_EXPENSES_EXTRA_EXPENSES_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------