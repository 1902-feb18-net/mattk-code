-- SQL has many statements/commands
-- they are categorized as a number of "sub-languages"

-- Data Manipulation Language (DML) operates on individual rows.
-- there are five DML commands in SQL Server -

-- SELECT, INSERT, UPDATE, DELETE, TRUNCATE TABLE

-- SELECT is for read access to the rows.

SELECT * FROM Genre;
-- INSERT
INSERT INTO Genre VALUES (26, 'Misc');
-- really we should name the columns.
-- this is more readable / less error-prone
-- and it lets us skip columns that have default values we are OK with.
INSERT INTO Genre (GenreId, Name) VALUES (27, 'Misc 2');
-- can use complex expressions with subqueries.
INSERT INTO Genre (GenreId, Name) VALUES 
(
(SELECT MAX(GenreId) FROM Genre) + 1,
'Misc 3'
);
-- can insert multiple rows at once.
INSERT INTO Genre (GenreId, Name) VALUES
	(29, 'Misc 4'),
	(30, 'Misc 5');
-- can insert the result of a query
-- (this one duplicates every genre)
INSERT INTO Genre (GenreId, Name) 
	(SELECT GenreId + 100, Name
	FROM Genre);

-- UPDATE statement
UPDATE Genre
SET Name = 'Misc 1' -- could change more than one column, comma separated
WHERE Name = 'Misc';
-- if we left out the WHERE, we would change every row.

UPDATE Genre
SET GenreId = GenreId - 50, Name = 'Miscellaneous ' + SUBSTRING(Name, 6, 1)
WHERE GenreId > 100 AND Name LIKE 'Misc%';

SELECT 'Miscellaneous ' + SUBSTRING(Name, 6, 1)
FROM Genre
WHERE GenreId > 100 AND Name LIKE 'Misc%';


-- DELETE statement
DELETE FROM Genre
WHERE GenreId > 100; -- without WHERE, would delete every row.

-- TRUNCATE TABLE
-- TRUNCATE TABLE Genre; -- would delete every row, no conditions (suggest not running it)

-- DELETE FROM Genre deletes every row, one at a time
-- TRUNCATE TABLE Genre deletes every row all at once, faster
-- 1. insert two new records into the employee table.
INSERT INTO Employee (EmployeeId, FirstName, LastName) VALUES
(
(SELECT MAX(EmployeeId) FROM Employee) + 1,
'Bob', 'Jim'
),
(
(SELECT MAX(EmployeeId) FROM Employee) + 2,
'Jane', 'Simmons'
);

SELECT *
FROM Employee;


	(29, 'Misc 4'),
	(30, 'Misc 5');

-- 2. insert two new records into the tracks table.
INSERT INTO Track (TrackId, Name) VALUES
(
(SELECT MAX(TrackId) FROM Track) + 1,
'Bob', 'Jim'
),
(
(SELECT MAX(TrackId) FROM Track) + 2,
'Jane', 'Simmons'
);

SELECT *
FROM Track;

-- 3. update customer Aaron Mitchell's name to Robert Walter
UPDATE Customer
SET FirstName = 'Robert', LastName = 'Walter' -- could change more than one column, comma separated
WHERE FirstName = 'Aaron' AND LastName = 'Mitchell';

SELECT *
FROM Customer
ORDER BY LastName;

-- 4. delete one of the employees you inserted.
DELETE FROM Employee
WHERE EmployeeId = 10; -- without WHERE, would delete every row.

SELECT *
FROM Employee;

-- 5. delete customer Robert Walter. (more complex than it seems!)
DELETE FROM InvoiceLine
WHERE InvoiceId = 50 OR InvoiceId = 61 OR InvoiceId = 116 OR
InvoiceId = 245 OR InvoiceId = 268 OR InvoiceId = 290 OR InvoiceId = 342;

SELECT *
FROM InvoiceLine;

SELECT *
FROM Invoice
WHERE CustomerId = 32;

DELETE FROM Invoice
WHERE CustomerId = 32;

DELETE FROM Customer
WHERE FirstName = 'Robert' AND LastName = 'Walter';

SELECT *
FROM Invoice inv
	JOIN Customer c ON inv.CustomerId = c.CustomerId;

SELECT *
FROM Customer
ORDER BY LastName;