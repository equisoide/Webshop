CREATE TABLE [dbo].[ProductCategory] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT NOT NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [UK_ProductCategory_ProductIdCategoryId] UNIQUE NONCLUSTERED ([ProductId] ASC, [CategoryId] ASC)
);

