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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250526152603_InitialMigration'
)
BEGIN
    CREATE TABLE [Books] (
        [book_id] int NOT NULL IDENTITY,
        [title] varchar(100) NOT NULL,
        [first_name] varchar(50) NOT NULL,
        [last_name] varchar(50) NOT NULL,
        [TotalCopies] int NOT NULL,
        [CopiesInUse] int NOT NULL,
        [type] varchar(50) NOT NULL,
        [isbn] varchar(80) NOT NULL,
        [category] varchar(50) NOT NULL,
        [OwnershipStatus] varchar(100) NOT NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([book_id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250526152603_InitialMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250526152603_InitialMigration', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250526153027_ChangeColumnsName'
)
BEGIN
    EXEC sp_rename N'[Books].[TotalCopies]', N'total_copies', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250526153027_ChangeColumnsName'
)
BEGIN
    EXEC sp_rename N'[Books].[CopiesInUse]', N'copies_in_use', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250526153027_ChangeColumnsName'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250526153027_ChangeColumnsName', N'9.0.5');
END;

COMMIT;
GO

