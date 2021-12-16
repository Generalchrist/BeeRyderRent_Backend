CREATE TABLE [dbo].[Rentals] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [CarId]      INT  NULL,
    [CustomerId] INT  NULL,
    [RentDate]   DATE NULL,
    [ReturnDate] DATE NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

