-- Schema creation for GestionProyecto
-- Run this on your SQL Server instance to create the tables the app expects.

SET NOCOUNT ON;

IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(100) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(256) NOT NULL,
        Email NVARCHAR(256) NULL,
        IsFirstLogin BIT NOT NULL DEFAULT(1),
        Role NVARCHAR(50) NOT NULL DEFAULT('User'),
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
END

IF OBJECT_ID('dbo.SystemConfig', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SystemConfig (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        MinPasswordLength INT NOT NULL DEFAULT(8),
        QuestionsToAnswer INT NOT NULL DEFAULT(2),
        RequireUpperLower BIT NOT NULL DEFAULT(0),
        RequireDigits BIT NOT NULL DEFAULT(0),
        RequireSpecial BIT NOT NULL DEFAULT(0),
        Require2FA BIT NOT NULL DEFAULT(0),
        DisallowPreviousPasswords BIT NOT NULL DEFAULT(0),
        DisallowPersonalData BIT NOT NULL DEFAULT(0)
    );
    -- insert default row
    INSERT INTO dbo.SystemConfig (MinPasswordLength, QuestionsToAnswer, RequireUpperLower, RequireDigits, RequireSpecial, Require2FA, DisallowPreviousPasswords, DisallowPersonalData)
    VALUES (8, 2, 1, 1, 0, 0, 1, 1);
END

IF OBJECT_ID('dbo.SecurityQuestions', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SecurityQuestions (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL REFERENCES dbo.Users(Id) ON DELETE CASCADE,
        Question NVARCHAR(400) NOT NULL,
        AnswerHash NVARCHAR(256) NOT NULL
    );
END

IF OBJECT_ID('dbo.PasswordHistory', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.PasswordHistory (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL REFERENCES dbo.Users(Id) ON DELETE CASCADE,
        PasswordHash NVARCHAR(256) NOT NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
END

PRINT 'Schema creation script finished.';
