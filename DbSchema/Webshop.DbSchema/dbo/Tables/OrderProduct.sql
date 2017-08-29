CREATE TABLE [dbo].[OrderProduct] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Quantity]  INT NOT NULL,
    CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_OrderProduct_Quantity] CHECK ([Quantity]>(0)),
    CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [UK_OrderProduct_OrderIdProductId] UNIQUE NONCLUSTERED ([OrderId] ASC, [ProductId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Quantity should be greater than zero', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderProduct', @level2type = N'CONSTRAINT', @level2name = N'CK_OrderProduct_Quantity';

