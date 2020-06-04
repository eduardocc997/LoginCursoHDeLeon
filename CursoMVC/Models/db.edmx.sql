
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2020 14:10:58
-- Generated from EDMX file: C:\Users\Eduardo\source\repos\cursoHdeLeon\LoginCursoHDeLeon\CursoMVC\Models\db.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [corsomvc];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_user_cstate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user] DROP CONSTRAINT [FK_user_cstate];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[cstate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cstate];
GO
IF OBJECT_ID(N'[dbo].[user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'cstate'
CREATE TABLE [dbo].[cstate] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(50)  NULL
);
GO

-- Creating table 'user'
CREATE TABLE [dbo].[user] (
    [id] int IDENTITY(1,1) NOT NULL,
    [email] varchar(50)  NULL,
    [password] varchar(100)  NULL,
    [idState] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'cstate'
ALTER TABLE [dbo].[cstate]
ADD CONSTRAINT [PK_cstate]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'user'
ALTER TABLE [dbo].[user]
ADD CONSTRAINT [PK_user]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idState] in table 'user'
ALTER TABLE [dbo].[user]
ADD CONSTRAINT [FK_user_cstate]
    FOREIGN KEY ([idState])
    REFERENCES [dbo].[cstate]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_user_cstate'
CREATE INDEX [IX_FK_user_cstate]
ON [dbo].[user]
    ([idState]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------