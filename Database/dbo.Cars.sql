CREATE TABLE [dbo].[Cars] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT          NULL,
    [ColorId]     INT          NULL,
    [ModelYear]   INT          NULL,
    [DailyPrice]  DECIMAL (18) NULL,
    [Description] NTEXT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]),
    CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id])
);

