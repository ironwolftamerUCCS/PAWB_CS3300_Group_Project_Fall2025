CREATE TABLE [dbo].[Table2]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [Username] NCHAR(10) NOT NULL, 
    [Password] NCHAR(10) NOT NULL, 
    [Website] NCHAR(10) NOT NULL, 
    [Notes] NCHAR(10) NULL
    FOREIGN KEY (UserID) REFERENCES Table1(UserID)
)
