IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Battles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Battles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Heros] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [BattleId] int NOT NULL,
    CONSTRAINT [PK_Heros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Heros_Battles_BattleId] FOREIGN KEY ([BattleId]) REFERENCES [Battles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Weapons] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [HeroId] int NOT NULL,
    CONSTRAINT [PK_Weapons] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Weapons_Heros_HeroId] FOREIGN KEY ([HeroId]) REFERENCES [Heros] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Heros_BattleId] ON [Heros] ([BattleId]);
GO

CREATE INDEX [IX_Weapons_HeroId] ON [Weapons] ([HeroId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211205191420_initial', N'5.0.12');
GO

COMMIT;
GO

