-- 1
SELECT CustomerId, FirstName, LastName, Country 
FROM Customer
WHERE Country != 'USA';

-- 2
SELECT *
FROM Customer
WHERE Country = 'Brazil';

-- 3
SELECT *
FROM Employee
WHERE Title = 'Sales Support Agent';

-- 4
SELECT BillingCountry
FROM Invoice;

--5
SELECT COUNT(*) AS Count, SUM(Total) AS SalesTotal
FROM Invoice
WHERE InvoiceDate > '2009' AND InvoiceDate < '2010';
-- GROUP BY InvoiceId, InvoiceDate;

--6
SELECT *
FROM InvoiceLine;

SELECT COUNT(*) AS Count
FROM InvoiceLine
WHERE InvoiceId = 37;

-- 7
SELECT *
FROM Invoice;