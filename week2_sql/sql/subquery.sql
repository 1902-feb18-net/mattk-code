-- subqueries

-- another way (actually several ways)
-- to combine info from multiple tables

-- every track that has never been purchased.
SELECT *
FROM Track AS t
WHERE t.TrackId NOT IN (
	SELECT TrackId
	FROM InvoiceLine
);
-- here we have a subquery in the WHERE clause of another query.
-- we have operators IN, NOT IN

SELECT *
FROM Track AS t
WHERE t.TrackId = ( 
	SELECT TOP(1) TrackId
	FROM InvoiceLine
	GROUP BY TrackId
	ORDER BY COUNT(*) DESC
);
-- we have TOP(n) to take just the first n results of a query
-- the inner query is: get the top trackid when we group all the invoice lines
-- by trackid and count up how many in each group 

-- we can also have subqueries in HAVING (no difference)
-- but also in FROM clause

-- 
SELECT *
FROM Track INNER JOIN (
		SELECT Artist.Name AS Artist, Album.Title AS Album, Album.AlbumId AS AlbumId
		FROM Artist JOIN Album ON Album.ArtistId = Artist.ArtistId
	) AS subq ON Track.AlbumId = subq.AlbumId
WHERE Track.Name < 'b'; 

-- similar to subquery in FROM is "common table expression" (CTE)
-- which uses a "WITH" clause

-- every track that has never been purchased (CTE version)
WITH purchased_tracks AS (
	SELECT DISTINCT TrackId
	FROM InvoiceLine
)
SELECT *
FROM Track AS t
WHERE t.TrackId NOT IN (
	SELECT TrackId
	FROM purchased_tracks
);

-- some other subquery operators:
-- EXISTS, NOT EXISTS
-- SOME, ANY

-- get the artist who made the album with the longest title.
SELECT *
FROM Artist
WHERE ArtistId = (
		SELECT ArtistId
		FROM Album
		WHERE LEN(Title) >= ALL (SELECT LEN(Title) FROM Album)
	);

-- does the same thing
SELECT * 
FROM Artist
WHERE ArtistId = (
	SELECT TOP(1) ArtistId
	FROM Album
	ORDER BY LEN(Title) DESC
);

-- set operations 
-- we have from mathematical sets the concepts of 
-- UNION, INTERSECT, and (set difference) EXCEPT

-- all first names of customers and employees
SELECT FirstName FROM Customer
UNION -- DISTINCT is the default, so you don't have to specify it
SELECT FirstName FROM Employee; -- 63 rows
-- all rows of the first query, and also all rows of the second query.
-- (the number and types of the columns need to be compatible)

-- for each set op, we have a distinct version, and an ALL version.
-- the DISTINCT version is the default.
-- so by default, all these operators make a pass to remove duplicates from the result.
SELECT FirstName FROM Customer
UNION ALL
SELECT FirstName FROM Employee; -- 67 rows

-- UNION give you values that are in EITHER result. (or statement analog)
-- INTERSECT gives you values that are in BOTH results. (and statement analog)
-- EXCEPT gives you values that are in the FIRST but NOT the SECOND result.

-- 1. which artists did not make any albums at all?
SELECT *
FROM Artist AS art
	JOIN Album AS alb ON art.ArtistId = alb.ArtistId;


SELECT *
FROM Artist AS art
	LEFT JOIN Album AS alb ON art.ArtistId = alb.ArtistId;

SELECT *
FROM Artist AS art
WHERE art.ArtistId NOT IN (
	SELECT ar.ArtistId
	FROM Artist AS ar
		JOIN Album AS alb ON ar.ArtistId = alb.ArtistId
);


-- 2. which artists did not record any tracks of the Latin genre?
SELECT *
FROM Artist AS art
WHERE art.ArtistId NOT IN (
	SELECT ar.ArtistId 
	FROM Artist AS ar
		JOIN Album AS alb ON ar.ArtistId = alb.ArtistId
		JOIN Track AS t ON alb.AlbumId = t.AlbumId
		JOIN Genre AS g ON t.GenreId = g.GenreId
		WHERE g.Name = 'Latin'
);

SELECT ar.ArtistId, alb.AlbumId, t.TrackId
	FROM Artist AS ar
		JOIN Album AS alb ON ar.ArtistId = alb.ArtistId
		JOIN Track AS t ON alb.AlbumId = t.AlbumId
		JOIN Genre AS g ON t.AlbumId = g.GenreId
		WHERE g.Name = 'Latin'

SELECT *
FROM Genre;
-- 3. which video track has the longest length? (use media type table)
SELECT *
FROM Track;






-- 4. find the names of the customers who live in the same city as the boss employee (the one who reports to nobody)
-- 5. how many audio tracks were bought by German customers, and what was the total price paid for them?
-- 6. list the names and countries of the customers supported by an employee who was hired younger than 35.
-- ^^ solve these with a mixture of joins, subqueries, CTE, and set operators. solve at least one of them in two different ways, and see if the execution plan for them is the same, or different. (edited) 













