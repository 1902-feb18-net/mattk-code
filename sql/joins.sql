-- joins

-- cross join (on the same table)

SELECT e1.*, e2.*
FROM Employee AS e1 CROSS JOIN Employee AS e2;

-- generate a lot of example customer names
-- by 

-- most common join, inner.
-- most common condition for inner join: foreign key = primary key.

SELECT *
FROM Track INNER JOIN Genre ON Track.GenreId = Genre.GenreId;

-- joining on "true" is the same as a cross join.
SELECT *
FROM Track INNER JOIN Genre ON 1 = 1;

-- three kinds of outer join: left outer, right outer, and full outer.
SELECT t.Name, g.Name
FROM Track t RIGHT JOIN Genre g ON t.GenreId = g.GenreId;

-- all rock songs in the database, showing artist name and song name.
SELECT ar.Name + ' - ' + t.Name
FROM Track AS t
	INNER JOIN Album AS al ON t.AlbumId = al.AlbumId
	INNER JOIN Artist AS ar ON al.ArtistId = ar.ArtistId
	INNER JOIN Genre AS g ON t.GenreId = g.GenreId
WHERE g.Name = 'Rock';

-- every employee together with who he reports to (his manager) if any
SELECT 
	emp.FirstName + ' ' + emp.LastName AS Employee,
	mgr.FirstName + ' ' + mgr.LastName AS Manager
FROM Employee AS emp
	LEFT OUTER JOIN Employee AS mgr ON emp.ReportsTo = mgr.EmployeeId;


-- 1. show all invoices of customers from brazil (mailing address not billing)
SELECT *
FROM Invoice AS inv
	INNER JOIN Customer AS c ON inv.CustomerId = c.CustomerId
WHERE c.Country = 'Brazil'; 

--2. show all invoices together with the name of the sales agent of each one
SELECT InvoiceId, emp.FirstName + ' ' + emp.LastName AS 'SalesAgent'
FROM Invoice AS inv
	INNER JOIN Customer AS c ON inv.CustomerId = c.CustomerId
	INNER JOIN Employee AS emp ON c.SupportRepId = emp.EmployeeId



SELECT *
FROM Employee;
--3. show all playlists ordered by the total number of tracks they have
SELECT pl.Name, COUNT(*) AS Count
FROM Playlist AS pl
	INNER JOIN PlaylistTrack AS plt ON pl.PlaylistId = plt.PlaylistId
GROUP BY pl.PlaylistId, pl.Name;


--4. which sales agent made the most in sales in 2009?
SELECT *
FROM Employee AS emp
	INNER JOIN Customer AS c ON emp.EmployeeId = c.SupportRepId
	INNER JOIN Invoice AS inv ON c.



--5. how many customers are assigned to each sales agent?
--6. which track was purchased the most since 2010?
--7. show the top three best-selling artists.
--8. which customers have the same initials as at least one other customer?









