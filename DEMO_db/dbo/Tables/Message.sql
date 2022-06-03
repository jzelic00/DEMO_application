CREATE TABLE [dbo].[Message] (
    [MessageId]            INT           IDENTITY (1, 1) NOT NULL,
    [ContactId]            INT           NOT NULL,
    [Folder]               NVARCHAR (30) NULL,
    [DateAndTimeOfSending] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([MessageId] ASC),
    FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact] ([ContactId])
);


GO
GRANT CONTROL
    ON OBJECT::[dbo].[Message] TO [ap_demo]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[Message] TO [ap_demo]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[Message] TO [ap_demo]
    AS [dbo];


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[Message] TO [ap_demo]
    AS [dbo];

