CREATE TABLE [dbo].[T_Base_Book] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Code]     NVARCHAR (50) NULL,
    [Author]   NVARCHAR (50) NULL,
    [Price]    DECIMAL (18)  NULL,
    [PYear]    DATETIME      NULL,
    [BookName] NVARCHAR (50) NULL,
    [Version]  NVARCHAR (20) NULL,
    [Pic]      NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

