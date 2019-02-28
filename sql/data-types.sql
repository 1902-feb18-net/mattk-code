-- in SSMS, like in VS, we have Ctrl+K, C for comment, Ctrl+K, U for uncomment

-- data types
-- numeric
--	integer 
--	- TINYINT (1 byte) (like byte or char, not in this language though, but similar)
--	- SMALLINT (2 byte)
--	- INT (4 bytes) (we use this one when we have no special need of the others)
--	- BIGINT (8 bytes)
--	floating-point
--	- FLOAT
--	- REAL
--	- DECIMAL/NUMERIC(n, p) (highest-precision + custom precision, can choose how precise it is, we use this one)
--	   decimal(4, 3) means, 4 digits, with 3 of them after the decimal point.
--	currency
--	- MONEY
--	string
--	- CHAR/CHARACTER(n)
--	   fixed-length string with size N
--	   uses one-byte-per-character encoding specific by the collation.
--	- VARCHAR/CHARACTER VARYING(n)
--	   variable-length string up to size N
--	   uses one-byte-per-character encoding specific by the collation.
--	      when we say 'abc' this is a VARCHAR
--	   we can set N to MAX (VARCHAR(MAX)) and that will allow maximum size
--	- NCHAR(n)
--	   unicode CHAR
--	- NVARCHAR(n)
--	   unicode VARCHAR. this is the one we use all the time for string stuff.
--	   we use this to store many international alphabets without depending on
--	   collation.
--	      when we say N'abc', this is an NVARCHAR. (the N stands for national)
--	   (can also use MAX here)
--	date/time
--	- DATE for dates
--	- TIME for times that aren't attached to a particular day
--	- DATETIME for timestamps, for times of a certain day
--	   don't use DATETIME because it is low precision and limited range
--	- DATETIME2(n) for high-precision, wide-range timestamps
--	   n controls precision
--	- DATETIMEOFFSET for intervals of time
--	we can use EXTRACT to get e.g. the YEAR from out of a DATETIME2.
--	there's also implicit conversions from strings, so i can compare
--	dates with '2019'

--	SELECT statement advanced usage
--	GROUP BY clause
--	by itself, it doesn't do a lot, but becomes useful with aggregate functions
--	   aggregate functions are functions that take in many values and return one value.
--		  COUNT, AVG, SUM, MIN, MAX.

--	all first names of customers, and the number of duplicates of them.
SELECT FirstName, COUNT(FirstName) AS Count
FROM SalesLT.Customer
GROUP BY FirstName
ORDER BY COUNT(FirstName) DESC;

-- GROUP BY accepts a list of columns, and for all rows which share thew same
-- values of all those columns are comboined into one row in the result set.
SELECT FirstName, COUNT(*) AS Count, LastName
FROM SalesLT.Customer
GROUP BY FirstName, LastName
ORDER BY COUNT(FirstName) DESC;
-- if we have a GROUP BY, we can't use any column in the select list
-- unless we say how to combine it together.
-- EITHER, you make it the basis for combining rows (put it in the GROUP BY)
-- OR, you run some aggregate function which says how to turn the many values
-- into one value.

-- how can i show all first names having no duplicates?
SELECT FirstName 
FROM SalesLT.Customer
WHERE COUNT(FirstName) = 1
GROUP BY FirstName; -- doesn't work
-- first, rows from the table are filtered with WHERE.
-- THEN, we run any aggregations with GROUP BY.
-- if we want to run conditions based on the aggregated rows, we need the HAVING clause.
SELECT FirstName AS fn
FROM SalesLT.Customer
WHERE LastName < 'n'
GROUP BY FirstName
HAVING COUNT(FirstName) = 1 -- HAVING is like WHERE but for aggregates
ORDER BY fn;

-- logical order of execution of a SELECT statement
-- essentially it "runs" in the order you write it, except, the SELECT clause is last
-- 1. FROM
-- 2. WHERE
-- 3. GROUP BY
-- 4. HAVING
-- 5. SELECT
-- 6. ORDER BY







