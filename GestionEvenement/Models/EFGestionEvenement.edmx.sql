
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2020 17:40:20
-- Generated from EDMX file: D:\workspaces\c#\GestionEvenement\GestionEvenement\Models\EFGestionEvenement.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GestionEvenement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Evenement__IdAdr__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Evenement] DROP CONSTRAINT [FK__Evenement__IdAdr__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__Evenement__IdTra__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Evenement] DROP CONSTRAINT [FK__Evenement__IdTra__412EB0B6];
GO
IF OBJECT_ID(N'[dbo].[FK__Evenement__IdTyp__403A8C7D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Evenement] DROP CONSTRAINT [FK__Evenement__IdTyp__403A8C7D];
GO
IF OBJECT_ID(N'[dbo].[FK__Inscripti__IdEve__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscriptionUserEvenement] DROP CONSTRAINT [FK__Inscripti__IdEve__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__Inscripti__IdUse__44FF419A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscriptionUserEvenement] DROP CONSTRAINT [FK__Inscripti__IdUse__44FF419A];
GO
IF OBJECT_ID(N'[dbo].[FK__PaiementU__IdIns__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaiementUserResa] DROP CONSTRAINT [FK__PaiementU__IdIns__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__PaiementU__IdPai__4BAC3F29]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaiementUserResa] DROP CONSTRAINT [FK__PaiementU__IdPai__4BAC3F29];
GO
IF OBJECT_ID(N'[dbo].[FK__PaiementU__IdUse__4AB81AF0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaiementUserResa] DROP CONSTRAINT [FK__PaiementU__IdUse__4AB81AF0];
GO
IF OBJECT_ID(N'[dbo].[FK__PlanningU__IdIns__52593CB8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanningUserEvent] DROP CONSTRAINT [FK__PlanningU__IdIns__52593CB8];
GO
IF OBJECT_ID(N'[dbo].[FK__PlanningU__IdPla__5165187F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanningUserEvent] DROP CONSTRAINT [FK__PlanningU__IdPla__5165187F];
GO
IF OBJECT_ID(N'[dbo].[FK__Users__IdAdresse__3B75D760]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK__Users__IdAdresse__3B75D760];
GO
IF OBJECT_ID(N'[dbo].[FK__Users__IdRole__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK__Users__IdRole__3A81B327];
GO
IF OBJECT_ID(N'[dbo].[FK__Users__IdTranche__398D8EEE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK__Users__IdTranche__398D8EEE];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Adresse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Adresse];
GO
IF OBJECT_ID(N'[dbo].[Evenement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Evenement];
GO
IF OBJECT_ID(N'[dbo].[InscriptionUserEvenement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InscriptionUserEvenement];
GO
IF OBJECT_ID(N'[dbo].[Paiement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paiement];
GO
IF OBJECT_ID(N'[dbo].[PaiementUserResa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaiementUserResa];
GO
IF OBJECT_ID(N'[dbo].[Planning]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Planning];
GO
IF OBJECT_ID(N'[dbo].[PlanningUserEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanningUserEvent];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[TrancheAge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrancheAge];
GO
IF OBJECT_ID(N'[dbo].[Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Type];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Adresse'
CREATE TABLE [dbo].[Adresse] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] int  NULL,
    [Rue] varchar(80)  NULL,
    [CodePostal] int  NULL,
    [Ville] varchar(50)  NULL
);
GO

-- Creating table 'Evenement'
CREATE TABLE [dbo].[Evenement] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] varchar(50)  NULL,
    [Description] varchar(500)  NULL,
    [Image] varchar(255)  NULL,
    [DateDebut] datetime  NULL,
    [DateFin] datetime  NULL,
    [Duree] int  NULL,
    [DateLimiteInscription] datetime  NULL,
    [IdType] int  NULL,
    [IdTrancheAge] int  NULL,
    [IdAdresse] int  NULL
);
GO

-- Creating table 'InscriptionUserEvenement'
CREATE TABLE [dbo].[InscriptionUserEvenement] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateResa] datetime  NULL,
    [Remarque] varchar(100)  NULL,
    [IdUser] int  NULL,
    [IdEvenement] int  NULL
);
GO

-- Creating table 'Paiement'
CREATE TABLE [dbo].[Paiement] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Montant] int  NULL,
    [Libelle] varchar(80)  NULL,
    [DatePaiement] datetime  NULL,
    [PaiementAJour] bit  NULL
);
GO

-- Creating table 'PaiementUserResa'
CREATE TABLE [dbo].[PaiementUserResa] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdUser] int  NULL,
    [IdPaiement] int  NULL,
    [IdInscriptionUserEvenement] int  NULL
);
GO

-- Creating table 'Planning'
CREATE TABLE [dbo].[Planning] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Horaire] int  NULL,
    [EstDispo] bit  NULL
);
GO

-- Creating table 'PlanningUserEvent'
CREATE TABLE [dbo].[PlanningUserEvent] (
    [Id] int  NOT NULL,
    [IdPlanning] int  NULL,
    [IdInscriptionUserEvenement] int  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] varchar(50)  NULL
);
GO

-- Creating table 'TrancheAge'
CREATE TABLE [dbo].[TrancheAge] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] varchar(50)  NULL,
    [AgeMin] int  NULL,
    [AgeMax] int  NULL
);
GO

-- Creating table 'Type'
CREATE TABLE [dbo].[Type] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] varchar(80)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] varchar(50)  NULL,
    [Prenom] varchar(50)  NULL,
    [DateNaissance] datetime  NULL,
    [Genre] bit  NULL,
    [Mail] varchar(50)  NOT NULL,
    [Telephone] int  NULL,
    [Photo] varchar(255)  NULL,
    [DateAdhesion] datetime  NULL,
    [IdTrancheAge] int  NULL,
    [IdRole] int  NULL,
    [IdAdresse] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Adresse'
ALTER TABLE [dbo].[Adresse]
ADD CONSTRAINT [PK_Adresse]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Evenement'
ALTER TABLE [dbo].[Evenement]
ADD CONSTRAINT [PK_Evenement]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InscriptionUserEvenement'
ALTER TABLE [dbo].[InscriptionUserEvenement]
ADD CONSTRAINT [PK_InscriptionUserEvenement]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Paiement'
ALTER TABLE [dbo].[Paiement]
ADD CONSTRAINT [PK_Paiement]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaiementUserResa'
ALTER TABLE [dbo].[PaiementUserResa]
ADD CONSTRAINT [PK_PaiementUserResa]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Planning'
ALTER TABLE [dbo].[Planning]
ADD CONSTRAINT [PK_Planning]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlanningUserEvent'
ALTER TABLE [dbo].[PlanningUserEvent]
ADD CONSTRAINT [PK_PlanningUserEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrancheAge'
ALTER TABLE [dbo].[TrancheAge]
ADD CONSTRAINT [PK_TrancheAge]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Type'
ALTER TABLE [dbo].[Type]
ADD CONSTRAINT [PK_Type]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdAdresse] in table 'Evenement'
ALTER TABLE [dbo].[Evenement]
ADD CONSTRAINT [FK__Evenement__IdAdr__4222D4EF]
    FOREIGN KEY ([IdAdresse])
    REFERENCES [dbo].[Adresse]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Evenement__IdAdr__4222D4EF'
CREATE INDEX [IX_FK__Evenement__IdAdr__4222D4EF]
ON [dbo].[Evenement]
    ([IdAdresse]);
GO

-- Creating foreign key on [IdAdresse] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK__Users__IdAdresse__3B75D760]
    FOREIGN KEY ([IdAdresse])
    REFERENCES [dbo].[Adresse]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Users__IdAdresse__3B75D760'
CREATE INDEX [IX_FK__Users__IdAdresse__3B75D760]
ON [dbo].[Users]
    ([IdAdresse]);
GO

-- Creating foreign key on [IdTrancheAge] in table 'Evenement'
ALTER TABLE [dbo].[Evenement]
ADD CONSTRAINT [FK__Evenement__IdTra__412EB0B6]
    FOREIGN KEY ([IdTrancheAge])
    REFERENCES [dbo].[TrancheAge]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Evenement__IdTra__412EB0B6'
CREATE INDEX [IX_FK__Evenement__IdTra__412EB0B6]
ON [dbo].[Evenement]
    ([IdTrancheAge]);
GO

-- Creating foreign key on [IdType] in table 'Evenement'
ALTER TABLE [dbo].[Evenement]
ADD CONSTRAINT [FK__Evenement__IdTyp__403A8C7D]
    FOREIGN KEY ([IdType])
    REFERENCES [dbo].[Type]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Evenement__IdTyp__403A8C7D'
CREATE INDEX [IX_FK__Evenement__IdTyp__403A8C7D]
ON [dbo].[Evenement]
    ([IdType]);
GO

-- Creating foreign key on [IdEvenement] in table 'InscriptionUserEvenement'
ALTER TABLE [dbo].[InscriptionUserEvenement]
ADD CONSTRAINT [FK__Inscripti__IdEve__45F365D3]
    FOREIGN KEY ([IdEvenement])
    REFERENCES [dbo].[Evenement]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Inscripti__IdEve__45F365D3'
CREATE INDEX [IX_FK__Inscripti__IdEve__45F365D3]
ON [dbo].[InscriptionUserEvenement]
    ([IdEvenement]);
GO

-- Creating foreign key on [IdUser] in table 'InscriptionUserEvenement'
ALTER TABLE [dbo].[InscriptionUserEvenement]
ADD CONSTRAINT [FK__Inscripti__IdUse__44FF419A]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Inscripti__IdUse__44FF419A'
CREATE INDEX [IX_FK__Inscripti__IdUse__44FF419A]
ON [dbo].[InscriptionUserEvenement]
    ([IdUser]);
GO

-- Creating foreign key on [IdInscriptionUserEvenement] in table 'PaiementUserResa'
ALTER TABLE [dbo].[PaiementUserResa]
ADD CONSTRAINT [FK__PaiementU__IdIns__4CA06362]
    FOREIGN KEY ([IdInscriptionUserEvenement])
    REFERENCES [dbo].[InscriptionUserEvenement]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PaiementU__IdIns__4CA06362'
CREATE INDEX [IX_FK__PaiementU__IdIns__4CA06362]
ON [dbo].[PaiementUserResa]
    ([IdInscriptionUserEvenement]);
GO

-- Creating foreign key on [IdInscriptionUserEvenement] in table 'PlanningUserEvent'
ALTER TABLE [dbo].[PlanningUserEvent]
ADD CONSTRAINT [FK__PlanningU__IdIns__52593CB8]
    FOREIGN KEY ([IdInscriptionUserEvenement])
    REFERENCES [dbo].[InscriptionUserEvenement]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PlanningU__IdIns__52593CB8'
CREATE INDEX [IX_FK__PlanningU__IdIns__52593CB8]
ON [dbo].[PlanningUserEvent]
    ([IdInscriptionUserEvenement]);
GO

-- Creating foreign key on [IdPaiement] in table 'PaiementUserResa'
ALTER TABLE [dbo].[PaiementUserResa]
ADD CONSTRAINT [FK__PaiementU__IdPai__4BAC3F29]
    FOREIGN KEY ([IdPaiement])
    REFERENCES [dbo].[Paiement]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PaiementU__IdPai__4BAC3F29'
CREATE INDEX [IX_FK__PaiementU__IdPai__4BAC3F29]
ON [dbo].[PaiementUserResa]
    ([IdPaiement]);
GO

-- Creating foreign key on [IdUser] in table 'PaiementUserResa'
ALTER TABLE [dbo].[PaiementUserResa]
ADD CONSTRAINT [FK__PaiementU__IdUse__4AB81AF0]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PaiementU__IdUse__4AB81AF0'
CREATE INDEX [IX_FK__PaiementU__IdUse__4AB81AF0]
ON [dbo].[PaiementUserResa]
    ([IdUser]);
GO

-- Creating foreign key on [IdPlanning] in table 'PlanningUserEvent'
ALTER TABLE [dbo].[PlanningUserEvent]
ADD CONSTRAINT [FK__PlanningU__IdPla__5165187F]
    FOREIGN KEY ([IdPlanning])
    REFERENCES [dbo].[Planning]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PlanningU__IdPla__5165187F'
CREATE INDEX [IX_FK__PlanningU__IdPla__5165187F]
ON [dbo].[PlanningUserEvent]
    ([IdPlanning]);
GO

-- Creating foreign key on [IdRole] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK__Users__IdRole__3A81B327]
    FOREIGN KEY ([IdRole])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Users__IdRole__3A81B327'
CREATE INDEX [IX_FK__Users__IdRole__3A81B327]
ON [dbo].[Users]
    ([IdRole]);
GO

-- Creating foreign key on [IdTrancheAge] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK__Users__IdTranche__398D8EEE]
    FOREIGN KEY ([IdTrancheAge])
    REFERENCES [dbo].[TrancheAge]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Users__IdTranche__398D8EEE'
CREATE INDEX [IX_FK__Users__IdTranche__398D8EEE]
ON [dbo].[Users]
    ([IdTrancheAge]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------