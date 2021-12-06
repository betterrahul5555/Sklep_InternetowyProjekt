
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/06/2021 17:34:19
-- Generated from EDMX file: C:\Users\Janek\source\repos\Sklep_Internetowy\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SklepBaza];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Faktura_produktuProdukt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktSet] DROP CONSTRAINT [FK_Faktura_produktuProdukt];
GO
IF OBJECT_ID(N'[dbo].[FK_FakturaFaktura_produktu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Faktura_produktuSet] DROP CONSTRAINT [FK_FakturaFaktura_produktu];
GO
IF OBJECT_ID(N'[dbo].[FK_Kategoria_produktuProducent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kategoria_produktuSet] DROP CONSTRAINT [FK_Kategoria_produktuProducent];
GO
IF OBJECT_ID(N'[dbo].[FK_KategoriaKategoria_produktu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kategoria_produktuSet] DROP CONSTRAINT [FK_KategoriaKategoria_produktu];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktKategoria_produktu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kategoria_produktuSet] DROP CONSTRAINT [FK_ProduktKategoria_produktu];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktZdjęcia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZdjęciaSet] DROP CONSTRAINT [FK_ProduktZdjęcia];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdresSet];
GO
IF OBJECT_ID(N'[dbo].[Dane_kontaktoweSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dane_kontaktoweSet];
GO
IF OBJECT_ID(N'[dbo].[Faktura_produktuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faktura_produktuSet];
GO
IF OBJECT_ID(N'[dbo].[FakturaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FakturaSet];
GO
IF OBJECT_ID(N'[dbo].[Kategoria_produktuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategoria_produktuSet];
GO
IF OBJECT_ID(N'[dbo].[KategoriaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KategoriaSet];
GO
IF OBJECT_ID(N'[dbo].[KlientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlientSet];
GO
IF OBJECT_ID(N'[dbo].[PracownikSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PracownikSet];
GO
IF OBJECT_ID(N'[dbo].[ProducentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProducentSet];
GO
IF OBJECT_ID(N'[dbo].[ProduktSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProduktSet];
GO
IF OBJECT_ID(N'[dbo].[ZdjęciaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZdjęciaSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdresSet'
CREATE TABLE [dbo].[AdresSet] (
    [Id_adresu] int IDENTITY(1,1) NOT NULL,
    [miasto] nvarchar(max)  NULL,
    [powiat] nvarchar(max)  NULL,
    [ulica] nvarchar(max)  NULL,
    [numer_domu] int  NULL,
    [numer_lokalu] int  NULL,
    [Klient_Id_klienta] int  NULL
);
GO

-- Creating table 'KlientSet'
CREATE TABLE [dbo].[KlientSet] (
    [Id_klienta] int IDENTITY(1,1) NOT NULL,
    [Id_kontaktu] int  NULL,
    [Id_adresu] int  NULL,
    [imie] nvarchar(max)  NULL,
    [nazwisko] nvarchar(max)  NULL
);
GO

-- Creating table 'PracownikSet'
CREATE TABLE [dbo].[PracownikSet] (
    [Id_pracownika] int IDENTITY(1,1) NOT NULL,
    [imie] nvarchar(max)  NULL,
    [nazwisko] nvarchar(max)  NULL,
    [data_zatrunienia] datetime  NULL,
    [Id_adresu] int  NULL,
    [Id_kontaktu] int  NULL
);
GO

-- Creating table 'Dane_kontaktoweSet'
CREATE TABLE [dbo].[Dane_kontaktoweSet] (
    [Id_kontaktu] int IDENTITY(1,1) NOT NULL,
    [numer] int  NULL,
    [emial] nvarchar(max)  NULL
);
GO

-- Creating table 'ProduktSet'
CREATE TABLE [dbo].[ProduktSet] (
    [Id_produktu] int IDENTITY(1,1) NOT NULL,
    [Id_kategorii_produktu] int  NULL,
    [nazwa] nvarchar(max)  NULL,
    [opis] nvarchar(max)  NULL,
    [Id_zdjecia] int  NULL,
    [cena_netto] float  NULL,
    [procent_vat] float  NULL,
    [Faktura_produktuId_faktura_produktu] int  NOT NULL,
    [cena_brutto] float  NULL
);
GO

-- Creating table 'FakturaSet'
CREATE TABLE [dbo].[FakturaSet] (
    [numer_faktury] int IDENTITY(1,1) NOT NULL,
    [Id_klienta] int  NOT NULL,
    [data_sprzedaży] datetime  NULL,
    [wartość_netto] float  NULL,
    [czy_dostawa] bit  NULL,
    [procent_podatku] float  NOT NULL
);
GO

-- Creating table 'Faktura_produktuSet'
CREATE TABLE [dbo].[Faktura_produktuSet] (
    [Id_faktura_produktu] int IDENTITY(1,1) NOT NULL,
    [Id_produktu] int  NOT NULL,
    [numer_faktury] int  NOT NULL
);
GO

-- Creating table 'ZdjęciaSet'
CREATE TABLE [dbo].[ZdjęciaSet] (
    [Id_zdjecia] int IDENTITY(1,1) NOT NULL,
    [nazwa] nvarchar(max)  NOT NULL,
    [data] datetime  NOT NULL,
    [Id_produktu] int  NOT NULL,
    [ProduktId_produktu] int  NOT NULL
);
GO

-- Creating table 'Kategoria_produktuSet'
CREATE TABLE [dbo].[Kategoria_produktuSet] (
    [Id_kategoria_produktu] int IDENTITY(1,1) NOT NULL,
    [Id_producenta] int  NULL,
    [Id_kategorii] int  NULL,
    [Produkt_Id_produktu] int  NOT NULL,
    [Producent_Id_producenta] int  NOT NULL,
    [Kategoria_Id_kategorii] int  NOT NULL
);
GO

-- Creating table 'KategoriaSet'
CREATE TABLE [dbo].[KategoriaSet] (
    [Id_kategorii] int IDENTITY(1,1) NOT NULL,
    [nazwa] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProducentSet'
CREATE TABLE [dbo].[ProducentSet] (
    [Id_producenta] int IDENTITY(1,1) NOT NULL,
    [nazwa] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_adresu] in table 'AdresSet'
ALTER TABLE [dbo].[AdresSet]
ADD CONSTRAINT [PK_AdresSet]
    PRIMARY KEY CLUSTERED ([Id_adresu] ASC);
GO

-- Creating primary key on [Id_klienta] in table 'KlientSet'
ALTER TABLE [dbo].[KlientSet]
ADD CONSTRAINT [PK_KlientSet]
    PRIMARY KEY CLUSTERED ([Id_klienta] ASC);
GO

-- Creating primary key on [Id_pracownika] in table 'PracownikSet'
ALTER TABLE [dbo].[PracownikSet]
ADD CONSTRAINT [PK_PracownikSet]
    PRIMARY KEY CLUSTERED ([Id_pracownika] ASC);
GO

-- Creating primary key on [Id_kontaktu] in table 'Dane_kontaktoweSet'
ALTER TABLE [dbo].[Dane_kontaktoweSet]
ADD CONSTRAINT [PK_Dane_kontaktoweSet]
    PRIMARY KEY CLUSTERED ([Id_kontaktu] ASC);
GO

-- Creating primary key on [Id_produktu] in table 'ProduktSet'
ALTER TABLE [dbo].[ProduktSet]
ADD CONSTRAINT [PK_ProduktSet]
    PRIMARY KEY CLUSTERED ([Id_produktu] ASC);
GO

-- Creating primary key on [numer_faktury] in table 'FakturaSet'
ALTER TABLE [dbo].[FakturaSet]
ADD CONSTRAINT [PK_FakturaSet]
    PRIMARY KEY CLUSTERED ([numer_faktury] ASC);
GO

-- Creating primary key on [Id_faktura_produktu] in table 'Faktura_produktuSet'
ALTER TABLE [dbo].[Faktura_produktuSet]
ADD CONSTRAINT [PK_Faktura_produktuSet]
    PRIMARY KEY CLUSTERED ([Id_faktura_produktu] ASC);
GO

-- Creating primary key on [Id_zdjecia] in table 'ZdjęciaSet'
ALTER TABLE [dbo].[ZdjęciaSet]
ADD CONSTRAINT [PK_ZdjęciaSet]
    PRIMARY KEY CLUSTERED ([Id_zdjecia] ASC);
GO

-- Creating primary key on [Id_kategoria_produktu] in table 'Kategoria_produktuSet'
ALTER TABLE [dbo].[Kategoria_produktuSet]
ADD CONSTRAINT [PK_Kategoria_produktuSet]
    PRIMARY KEY CLUSTERED ([Id_kategoria_produktu] ASC);
GO

-- Creating primary key on [Id_kategorii] in table 'KategoriaSet'
ALTER TABLE [dbo].[KategoriaSet]
ADD CONSTRAINT [PK_KategoriaSet]
    PRIMARY KEY CLUSTERED ([Id_kategorii] ASC);
GO

-- Creating primary key on [Id_producenta] in table 'ProducentSet'
ALTER TABLE [dbo].[ProducentSet]
ADD CONSTRAINT [PK_ProducentSet]
    PRIMARY KEY CLUSTERED ([Id_producenta] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Produkt_Id_produktu] in table 'Kategoria_produktuSet'
ALTER TABLE [dbo].[Kategoria_produktuSet]
ADD CONSTRAINT [FK_ProduktKategoria_produktu]
    FOREIGN KEY ([Produkt_Id_produktu])
    REFERENCES [dbo].[ProduktSet]
        ([Id_produktu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktKategoria_produktu'
CREATE INDEX [IX_FK_ProduktKategoria_produktu]
ON [dbo].[Kategoria_produktuSet]
    ([Produkt_Id_produktu]);
GO

-- Creating foreign key on [Producent_Id_producenta] in table 'Kategoria_produktuSet'
ALTER TABLE [dbo].[Kategoria_produktuSet]
ADD CONSTRAINT [FK_Kategoria_produktuProducent]
    FOREIGN KEY ([Producent_Id_producenta])
    REFERENCES [dbo].[ProducentSet]
        ([Id_producenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kategoria_produktuProducent'
CREATE INDEX [IX_FK_Kategoria_produktuProducent]
ON [dbo].[Kategoria_produktuSet]
    ([Producent_Id_producenta]);
GO

-- Creating foreign key on [Kategoria_Id_kategorii] in table 'Kategoria_produktuSet'
ALTER TABLE [dbo].[Kategoria_produktuSet]
ADD CONSTRAINT [FK_KategoriaKategoria_produktu]
    FOREIGN KEY ([Kategoria_Id_kategorii])
    REFERENCES [dbo].[KategoriaSet]
        ([Id_kategorii])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KategoriaKategoria_produktu'
CREATE INDEX [IX_FK_KategoriaKategoria_produktu]
ON [dbo].[Kategoria_produktuSet]
    ([Kategoria_Id_kategorii]);
GO

-- Creating foreign key on [Faktura_produktuId_faktura_produktu] in table 'ProduktSet'
ALTER TABLE [dbo].[ProduktSet]
ADD CONSTRAINT [FK_Faktura_produktuProdukt]
    FOREIGN KEY ([Faktura_produktuId_faktura_produktu])
    REFERENCES [dbo].[Faktura_produktuSet]
        ([Id_faktura_produktu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Faktura_produktuProdukt'
CREATE INDEX [IX_FK_Faktura_produktuProdukt]
ON [dbo].[ProduktSet]
    ([Faktura_produktuId_faktura_produktu]);
GO

-- Creating foreign key on [ProduktId_produktu] in table 'ZdjęciaSet'
ALTER TABLE [dbo].[ZdjęciaSet]
ADD CONSTRAINT [FK_ProduktZdjęcia]
    FOREIGN KEY ([ProduktId_produktu])
    REFERENCES [dbo].[ProduktSet]
        ([Id_produktu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktZdjęcia'
CREATE INDEX [IX_FK_ProduktZdjęcia]
ON [dbo].[ZdjęciaSet]
    ([ProduktId_produktu]);
GO

-- Creating foreign key on [numer_faktury] in table 'Faktura_produktuSet'
ALTER TABLE [dbo].[Faktura_produktuSet]
ADD CONSTRAINT [FK_FakturaFaktura_produktu]
    FOREIGN KEY ([numer_faktury])
    REFERENCES [dbo].[FakturaSet]
        ([numer_faktury])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FakturaFaktura_produktu'
CREATE INDEX [IX_FK_FakturaFaktura_produktu]
ON [dbo].[Faktura_produktuSet]
    ([numer_faktury]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------