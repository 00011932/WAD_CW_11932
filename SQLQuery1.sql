USE [BookLibDB]
GO

/****** Object: Table [dbo].[Users] Script Date: 4/7/2023 10:59:07 AM ******/

CREATE TABLE [dbo].[Users] (
    [ID]             INT    PRIMARY KEY    IDENTITY,
    [FirstName]      NVARCHAR (120) NULL,
    [LastName]       NVARCHAR (120) NULL,
    [Email]          NVARCHAR (MAX) NOT NULL,
    [PassportNumber] NVARCHAR (MAX) NOT NULL,
    [CreatedAt]      DATETIME  NOT NULL,
    [Status]         INT            NOT NULL
);


-- create db table for Book--


CREATE TABLE [dbo].[Books] (
    [ID]          INT PRIMARY KEY  IDENTITY,
    [Title]       NVARCHAR (120) NOT NULL,
    [ISBN]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Status]      INT            NOT NULL,
    [Authors]     NVARCHAR (MAX) NULL,
    [PageCount]   INT            NOT NULL,
    [UserID]      INT            NULL,

    Constraint FK_Books_Users_UserId FOREIGN KEY (UserId) REFERENCES Users(ID) 
);
go
    ALTER TABLE Books
ALTER COLUMN UserId int NULL



-- create table for loans --

CREATE TABLE [dbo].[Loans] (
    [ID]               INT    PRIMARY KEY    IDENTITY,
    [UserId]           INT           NOT NULL,
    [BookId]           INT           NOT NULL,
    [DateTaken]        Datetime NOT NULL,
    [DurationPeriod]   INT           NOT NULL,
    [ActualReturnDate] DATETIME NULL

    CONSTRAINT [FK_Loans_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([ID]),
    CONSTRAINT [FK_Loans_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([ID])
);

go





INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount)
VALUES ('Book title', '1212122', 'book description', 1, 'Said Axmat', 123);

INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('Harry Potter and the Philosophers Stone', '9780747532743', 'The first novel in the Harry Potter series.', 1, 'J.K. Rowling', 223);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('To Kill a Mockingbird', '0060935464', 'A Pulitzer Prize-winning novel by Harper Lee.', 1, 'Harper Lee', 336);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('1984', '9780451524935', 'A dystopian novel by George Orwell.', 1, 'George Orwell', 328);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('The Great Gatsby', '9780743273565', 'A novel by F. Scott Fitzgerald.', 1, 'F. Scott Fitzgerald', 180);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('Pride and Prejudice', '9780486284736', 'A novel by Jane Austen.', 1, 'Jane Austen', 279);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('The Catcher in the Rye', '0316769177', 'A novel by J.D. Salinger.', 1, 'J.D. Salinger', 234);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('One Hundred Years of Solitude', '9780060883287', 'A novel by Gabriel García Márquez.', 1, 'Gabriel García Márquez', 417);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('The Hobbit', '9780547928227', 'A childrens fantasy novel by J.R.R. Tolkien.', 1, 'J.R.R. Tolkien', 366);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('The Hitchhikers Guide to the Galaxy', '9780345391803', 'A comedy science fiction series by Douglas Adams.', 1, 'Douglas Adams', 215);
INSERT INTO Books (Title, ISBN, Description, Status, Authors, PageCount) VALUES ('The Picture of Dorian Gray', '9780486278070', 'A novel by Oscar Wilde.', 1, 'Oscar Wilde', 254);




Insert into Users(FirstName, lastName, Email, PassportNumber, createdAt, Status)
Values ('Jon', 'student', 'sample@gmail.com', 'ABCD11111', '2008-11-11 13:23:44', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Emma', 'Watson', 'emmawatson@gmail.com', 'ABCD22222', '2010-06-14 09:11:22', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Tom', 'Hanks', 'tomhanks@gmail.com', 'EFGH11111', '2011-08-17 14:55:33', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Taylor', 'Swift', 'taylorswift@gmail.com', 'IJKL22222', '2012-05-22 11:44:55', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Robert', 'Downey Jr.', 'robertdowneyjr@gmail.com', 'MNOP11111', '2013-09-19 16:33:44', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Jennifer', 'Aniston', 'jenniferaniston@gmail.com', 'QRST22222', '2014-01-07 10:22:11', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Leonardo', 'DiCaprio', 'leonardodicaprio@gmail.com', 'UVWX11111', '2015-12-02 15:01:23', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Scarlett', 'Johansson', 'scarlettjohansson@gmail.com', 'YZAB22222', '2016-07-25 08:33:12', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Chris', 'Evans', 'chrisevans@gmail.com', 'CDEF11111', '2017-04-18 12:44:00', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Gal', 'Gadot', 'galgadot@gmail.com', 'GHIJ22222', '2018-10-23 09:23:44', 1);
INSERT INTO Users(FirstName, lastName, Email, PassportNumber, createdAt, Status) VALUES ('Chadwick', 'Boseman', 'chadwickboseman@gmail.com', 'KLMN11111', '2019-02-28 14:57:33', 1);

INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod)
VALUES (1, 1, '2023-03-23', 14);

INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (2, 2, '2022-01-26', 21);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (3, 3, '2023-03-23', 7);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (4, 4, '2023-02-21', 14);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (5, 5, '2023-01-13', 14);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (6, 6, '2023-03-23', 28);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (7, 7, '2023-03-23', 7);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (8, 8, '2023-03-23', 14);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (9, 9, '2023-03-23', 21);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (10, 10, '2022-04-23', 7);
INSERT INTO Loans(UserId, BookId, DateTaken, DurationPeriod) VALUES (11, 11, '2023-03-23', 14);

