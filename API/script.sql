CREATE TABLE [Cars] (
    [Id] int NOT NULL IDENTITY,
    [BrandAndModel] nvarchar(max) NOT NULL,
    [Seaters] nvarchar(max) NOT NULL,
    [TrunkSize] nvarchar(max) NOT NULL,
    [GearBox] nvarchar(max) NOT NULL,
    [PictureUrl] nvarchar(max) NOT NULL,
    [Price] int NOT NULL,
    [Available] bit NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    [IsAdmin] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Rentals] (
    [Id] int NOT NULL IDENTITY,
    [RentalStart] nvarchar(max) NOT NULL,
    [RentalEnd] nvarchar(max) NOT NULL,
    [UserId] int NOT NULL,
    [CarId] int NOT NULL,
    CONSTRAINT [PK_Rentals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rentals_Cars_CarId] FOREIGN KEY ([CarId]) REFERENCES [Cars] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rentals_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Rentals_CarId] ON [Rentals] ([CarId]);
GO


CREATE INDEX [IX_Rentals_UserId] ON [Rentals] ([UserId]);
GO


