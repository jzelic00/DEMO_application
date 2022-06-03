CREATE TABLE [dbo].[Contact] (
    [ContactId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (20) NULL,
    [Lastname]  NVARCHAR (20) NULL,
    [Number]    NVARCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([ContactId] ASC)
);


GO
GRANT ALTER
    ON OBJECT::[dbo].[Contact] TO [ap_demo]
    AS [dbo];


GO
GRANT CONTROL
    ON OBJECT::[dbo].[Contact] TO [ap_demo]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[Contact] TO [ap_demo]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[Contact] TO [ap_demo]
    AS [dbo];

