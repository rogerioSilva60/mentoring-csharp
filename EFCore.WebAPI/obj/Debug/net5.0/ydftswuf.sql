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

BEGIN TRANSACTION;
GO

ALTER TABLE [Heros] DROP CONSTRAINT [FK_Heros_Battles_BattleId];
GO

DROP INDEX [IX_Heros_BattleId] ON [Heros];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Heros]') AND [c].[name] = N'BattleId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Heros] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Heros] DROP COLUMN [BattleId];
GO

CREATE TABLE [HeroBattles] (
    [HeroId] int NOT NULL,
    [BattleId] int NOT NULL,
    CONSTRAINT [PK_HeroBattles] PRIMARY KEY ([BattleId], [HeroId]),
    CONSTRAINT [FK_HeroBattles_Battles_BattleId] FOREIGN KEY ([BattleId]) REFERENCES [Battles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HeroBattles_Heros_HeroId] FOREIGN KEY ([HeroId]) REFERENCES [Heros] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [SecretIdentities] (
    [Id] int NOT NULL IDENTITY,
    [RealName] nvarchar(max) NULL,
    [HeroId] int NOT NULL,
    CONSTRAINT [PK_SecretIdentities] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SecretIdentities_Heros_HeroId] FOREIGN KEY ([HeroId]) REFERENCES [Heros] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_HeroBattles_HeroId] ON [HeroBattles] ([HeroId]);
GO

CREATE UNIQUE INDEX [IX_SecretIdentities_HeroId] ON [SecretIdentities] ([HeroId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211205202014_HeroBattles_Identity', N'5.0.12');
GO

COMMIT;
GO

