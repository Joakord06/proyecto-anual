-- Script de inicialización: crea usuarios 'admin' y 'user' si no existen
-- Usa SHA2_256 y convierte a string hex (sin prefijo 0x) para almacenar en PasswordHash

SET NOCOUNT ON;

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Users')
BEGIN
    PRINT 'Tabla Users no encontrada. Asegúrate de crear la estructura antes de ejecutar este script.';
END

-- Admin
IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'admin')
BEGIN
    DECLARE @pwdAdminVarbinary varbinary(32) = HASHBYTES('SHA2_256', 'admin' + 'adminAdmin123!');
    DECLARE @pwdAdminHex varchar(64) = LOWER(SUBSTRING(master.dbo.fn_varbintohexstr(@pwdAdminVarbinary),3,8000));
    INSERT INTO Users (Username, PasswordHash, Email, IsFirstLogin, Role, CreatedAt)
    VALUES ('admin', @pwdAdminHex, 'admin@example.com', 0, 'Admin', GETDATE());
    PRINT 'Usuario admin creado.';
END
ELSE
    PRINT 'Usuario admin ya existe.';

-- Usuario estándar
IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'user')
BEGIN
    DECLARE @pwdUserVarbinary varbinary(32) = HASHBYTES('SHA2_256', 'user' + 'userUser123!');
    DECLARE @pwdUserHex varchar(64) = LOWER(SUBSTRING(master.dbo.fn_varbintohexstr(@pwdUserVarbinary),3,8000));
    INSERT INTO Users (Username, PasswordHash, Email, IsFirstLogin, Role, CreatedAt)
    VALUES ('user', @pwdUserHex, 'user@example.com', 0, 'User', GETDATE());
    PRINT 'Usuario user creado.';
END
ELSE
    PRINT 'Usuario user ya existe.';

-- Opcional: valores iniciales para SystemConfig si no existen
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'SystemConfig')
BEGIN
    PRINT 'Tabla SystemConfig no encontrada. Crea la tabla y luego inserta la configuración requerida.';
END
ELSE
BEGIN
    IF NOT EXISTS (SELECT 1 FROM SystemConfig)
    BEGIN
        INSERT INTO SystemConfig (MinPasswordLength, QuestionsToAnswer, RequireUpperLower, RequireDigits, RequireSpecial, Require2FA, DisallowPreviousPasswords, DisallowPersonalData)
        VALUES (8, 2, 1, 1, 0, 0, 1, 1);
        PRINT 'SystemConfig inicial creada.';
    END
    ELSE
        PRINT 'SystemConfig ya contiene datos.';
END

