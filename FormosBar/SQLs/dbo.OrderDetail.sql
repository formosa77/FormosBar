CREATE TABLE [dbo].[OrderDetail] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]  INT            NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Price]    INT            NOT NULL,
    [Quantity] INT            NOT NULL,
    [Status]   INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.OrderDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.OrderDetail_dbo.Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderId]
    ON [dbo].[OrderDetail]([OrderId] ASC);

