CREATE TABLE [dbo].[Order] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [CustomerId] INT      NOT NULL,
    [Date]       DATETIME CONSTRAINT [DF_Order_Date] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

