CREATE TABLE [dbo].[Customer] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [Address]   NVARCHAR (100) NULL,
    [Telephone] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

