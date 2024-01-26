# Bookstore WPF Project

It is a simply desktop application in C#, that allows to manipulate data.

Application is based on:
* CRUD (Create, Read, Update, Delete) functionality,
* SQL queries to create and fill data in (LocalDB/MSSQL),
* Entity Framework for C#,
* DAL (Data Access Layer).

### Main Window
A main window includes buttons to open a specific windows, button to refresh data and table with all important data.

![Main window](https://user-images.githubusercontent.com/101014313/177840644-62aab8e3-be0d-4ea7-8935-48dfb10bea60.jpg)

### Author Window
A author window allows us to add a new author to a database and delete a selected author.

![Author](https://user-images.githubusercontent.com/101014313/177840987-a8afb4e9-5cf2-4be6-806b-569f24992126.jpg)

### Customer Window
A custom window allow us to add a new customer to a database, delete a selected customer and update customer's information (email). First name and last name are read only values. 

![Customer](https://user-images.githubusercontent.com/101014313/177841289-736daefd-693d-498c-8fdf-7de5d6e7493c.jpg)

### Book Window
A book window allo us to add a new book to a database and delete a selected book.

![book](https://user-images.githubusercontent.com/101014313/177841714-5ecc0dec-151e-4105-9a97-fe0abfbbe4f2.jpg)

### Queries to create tables
```
CREATE TABLE [dbo].[Books](
[ID] [int] PRIMARY KEY IDENTITY,
[Title] [nvarchar] (100) NOT NULL,
[PublishedYear] [date] NOT NULL,
[Quantity] [int] NOT NULL,
[AuthorId] [int] FOREIGN KEY REFERENCES Authors(Id),
[StatusId] [int] FOREIGN KEY REFERENCES Status(Id),
[CustomerId] [int] FOREIGN KEY REFERENCES Customers(Id));

CREATE TABLE [dbo].[Customers](
[ID] [int] PRIMARY KEY IDENTITY,
[FirstName] [nvarchar] (100) NOT NULL,
[LastName] [nvarchar] (100) NOT NULL,
[Email] [nvarchar] (100) NOT NULL,
[OrderQuantity] [int]  NOT NULL,
[CityId] [int] FOREIGN KEY REFERENCES Cities(Id));

CREATE TABLE [dbo].[Authors](
[ID] [int] PRIMARY KEY IDENTITY,
[FirstName] [nvarchar] (100) NOT NULL,
[LastName] [nvarchar] (100) NOT NULL);

CREATE TABLE [dbo].[Status](
[ID] [int] PRIMARY KEY IDENTITY,
[StatusName] [nvarchar] (50) NOT NULL);

CREATE TABLE [dbo].[Cities](
[ID] [int] PRIMARY KEY IDENTITY,
[CityName] [nvarchar] (100) NOT NULL);
```

### Queries to fill the initial data in
```
INSERT INTO Status(StatusName)
VALUES ('Avaliable'), ('Sold Out');

INSERT INTO Cities(CityName)
VALUES ('Cracow'), ('Wroclaw'), ('Warsaw'), ('Berlin'), ('Pragha'), ('Lublin'), ('Opole'), ('Legnica');

INSERT INTO Customers(FirstName, LastName, Email, OrderQuantity, CityId)
VALUES ('Aleksandra', 'Olesińska', 'ao@gmail.com', 4, 1), 
	   ('Sebastian', 'Oraczek', 'so@gmail.com', 2, 1),
	   ('Jan', 'Nowak', 'jn@gmail.com', 5, 3),
	   ('Grzegorz', 'Janaszek', 'gj@gmail.com', 2, 3),
	   ('Michał', 'Kokot', 'mk@gmail.com', 2, 3),
	   ('Grzegorz', 'Janaszek', 'gj@gmail.com', 4, 5),
	   ('Joanna', 'Fluder', 'jf@gmail.com', 2, 5),
	   ('Janina', 'Dunder', 'jd@gmail.com', 3, 3),
	   ('Jan', 'Kowalski', 'jk@gmail.com', 1, 2);

INSERT INTO Authors(FirstName, LastName)
VALUES ('J.K.', 'Rowling'),
	   ('J.R.R.', 'Tolkien'),
	   ('Nicolas', 'Sparks'),
       ('Stephen', 'King'),
       ('Diane', 'Setterfield'),
	   ('Harlan', 'Coben'),
	   ('Patricia', 'Lockwood'),
	   ('Remigiusz', 'Mróz');

INSERT INTO Books (Title, PublishedYear, Quantity, AuthorId, StatusId, CustomerId)
VALUES ('Harry Potter i Komnata Tajemnic', '1998-07-02', 10, 1, 1, 1),
	   ('Harry Potter i Czara Ognia', '2000-07-08', 0, 1, 2, 1),
	   ('Fantastyczne zwierzęta i jak je znaleźć', '2016-11-18', 2, 1, 1, 2),
	   ('Władca Pierścieni: Drużyna Pierścienia', '1954-07-29', 7, 2, 1, 2),
	   ('Hobbit', '1937-09-21', 12, 2, 1, 3),
	   ('Najdłuższa podróż', '2013-09-16', 0, 3, 2, 4),
	   ('Pamiętnik', '1996-10-01', 1, 3, 1, 4),
	   ('Zielona Mila', '1996-08-29', 3, 4, 1, 5),
	   ('Trzynasta opowieść', '2006-09-12', 10, 4, 1, 2),
	   ('Zachowaj spokój', '2008-04-15', 9, 5, 1, 6),
	   ('Zielona Mila', '1996-08-29', 3, 4, 1, 5);
```
