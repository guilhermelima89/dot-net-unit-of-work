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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220820212248_00')
BEGIN
    CREATE TABLE [Log] (
        [Id] int NOT NULL IDENTITY,
        [Descricao] varchar(250) NOT NULL,
        [DataCadastro] datetime NOT NULL,
        [DataAlteracao] datetime NULL,
        [DataExclusao] datetime NULL,
        CONSTRAINT [PK_Log] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220820212248_00')
BEGIN
    CREATE TABLE [Pessoa] (
        [Id] int NOT NULL IDENTITY,
        [Nome] varchar(250) NOT NULL,
        [DataCadastro] datetime NOT NULL,
        [DataAlteracao] datetime NULL,
        [DataExclusao] datetime NULL,
        CONSTRAINT [PK_Pessoa] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220820212248_00')
BEGIN
    CREATE TABLE [EmailPessoa] (
        [Id] int NOT NULL IDENTITY,
        [Email] varchar(50) NOT NULL,
        [Sequencia] int NOT NULL,
        [PessoaId] int NOT NULL,
        [DataCadastro] datetime NOT NULL,
        [DataAlteracao] datetime NULL,
        [DataExclusao] datetime NULL,
        CONSTRAINT [PK_EmailPessoa] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_EmailPessoa_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220820212248_00')
BEGIN
    CREATE TABLE [TelefonePessoa] (
        [Id] int NOT NULL IDENTITY,
        [Telefone] varchar(50) NOT NULL,
        [Sequencia] int NOT NULL,
        [PessoaId] int NOT NULL,
        [DataCadastro] datetime NOT NULL,
        [DataAlteracao] datetime NULL,
        [DataExclusao] datetime NULL,
        CONSTRAINT [PK_TelefonePessoa] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TelefonePessoa_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220820212248_00')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAlteracao', N'DataCadastro', N'DataExclusao', N'Nome') AND [object_id] = OBJECT_ID(N'[Pessoa]'))
        SET IDENTITY_INSERT [Pessoa] ON;
    EXEC(N'INSERT INTO [Pessoa] ([Id], [DataAlteracao], [DataCadastro], [DataExclusao], [Nome])
    VALUES (1, NULL, ''2022-08-20T18:22:48.737'', NULL, ''PESSOA DE TESTE'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAlteracao', N'DataCadastro', N'DataExclusao', N'Nome') AND [object_id] = OBJECT_ID(N'[Pessoa]'))
        SET IDENTITY_INSERT [Pessoa] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220820212248_00')
BEGIN
    CREATE INDEX [IX_EmailPessoa_PessoaId] ON [EmailPessoa] ([PessoaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220820212248_00')
BEGIN
    CREATE INDEX [IX_TelefonePessoa_PessoaId] ON [TelefonePessoa] ([PessoaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220820212248_00')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220820212248_00', N'6.0.4');
END;
GO

COMMIT;
GO

