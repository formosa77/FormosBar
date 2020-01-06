CREATE TABLE [dbo].[Order] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      NVARCHAR (MAX) NULL,
    [UserName]    NVARCHAR (MAX) NULL,
    [TableNumber] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Order] PRIMARY KEY CLUSTERED ([Id] ASC)
);

