CREATE TABLE [dbo].[Item] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (160) NOT NULL,
    [Description]     NVARCHAR (MAX) NOT NULL,
    [Price]           INT            NOT NULL,
    [OnShelf]         BIT            NOT NULL,
    [DefaultImageURL] NVARCHAR (MAX) NOT NULL,
    [Category]        NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [ImageAlt]        NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.Item] PRIMARY KEY CLUSTERED ([Id] ASC)
);

