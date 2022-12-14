Build started...
Build succeeded.
warn: Microsoft.EntityFrameworkCore.Model.Validation[10400]
      Sensitive data logging is enabled. Log entries and exception messages may include sensitive application data; this mode should only be enabled during development.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (29ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (29ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      
      IF EXISTS
          (SELECT *
           FROM [sys].[objects] o
           WHERE [o].[type] = 'U'
           AND [o].[is_ms_shipped] = 0
           AND NOT EXISTS (SELECT *
               FROM [sys].[extended_properties] AS [ep]
               WHERE [ep].[major_id] = [o].[object_id]
                   AND [ep].[minor_id] = 0
                   AND [ep].[class] = 1
                   AND [ep].[name] = N'microsoft_database_tools_support'
          )
      )
      SELECT 1 ELSE SELECT 0
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

CREATE TABLE [Products] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY NONCLUSTERED ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Username] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [EmailAddress] nvarchar(200) NOT NULL,
    [CreatedAt] datetime NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetime NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY NONCLUSTERED ([Id]),
    CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderProducts] (
    [Id] uniqueidentifier NOT NULL,
    [OrderId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [CurrentPrice] decimal(18,2) NOT NULL,
    [CreatedAt] datetime NOT NULL,
    CONSTRAINT [PK_OrderProducts] PRIMARY KEY NONCLUSTERED ([Id]),
    CONSTRAINT [FK_OrderProducts_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderProducts_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_OrderProducts_OrderId] ON [OrderProducts] ([OrderId]);
GO

CREATE INDEX [IX_OrderProducts_ProductId] ON [OrderProducts] ([ProductId]);
GO

CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221126212256_InitialMigration', N'7.0.0');
GO

COMMIT;
GO


