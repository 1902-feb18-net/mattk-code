 CREATE SCHEMA EmpDB;
 GO

-- Employee has ID, FirstName, LastName, SSN, DeptID
-- Department has ID, Name, Location

DROP TABLE EmpDB.Department;
DROP TABLE EmpDB.Employee;

CREATE TABLE EmpDB.Department (
	DepartmentId INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	Location NVARCHAR(200) NOT NULL
);

CREATE TABLE EmpDB.Employee (
	EmployeeId INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	SSN INT NOT NULL,
	DepartmentID INT NOT NULL,
	CONSTRAINT FK_Department FOREIGN KEY (DepartmentID) REFERENCES EmpDB.Department (DepartmentId)
);

-- EmpDetails has ID, EmployeeID, Salary, Address 1, Address 2, City, State, Country

CREATE TABLE EmpDB.EmpDetails (
	EmpDetailsId INT NOT NULL PRIMARY KEY IDENTITY,
	EmployeeID INT NOT NULL,
	Salary DECIMAL(8, 2) NOT NULL,
	Address1 NVARCHAR(200),
	Address2 NVARCHAR(200),
	City NVARCHAR(100),
	State NVARCHAR(100),
	Country NVARCHAR(100),
	CONSTRAINT FK_Employee FOREIGN KEY (EmployeeID) REFERENCES EmpDB.Employee (EmployeeId)
);

CREATE TABLE EmpDB.Department (
	DepartmentId INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	Location NVARCHAR(200) NOT NULL
);

INSERT INTO EmpDB.Department VALUES 
	('Cosmetics', 'Dallas'),
	('Aviation', 'Seattle'),
	('WebDev', 'Palo Alto');

SELECT *
FROM EmpDB.Department;

CREATE TABLE EmpDB.Employee (
	EmployeeId INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	SSN INT NOT NULL,
	DepartmentID INT NOT NULL,
	CONSTRAINT FK_Department FOREIGN KEY (DepartmentID) REFERENCES EmpDB.Department (DepartmentId)
);

INSERT INTO EmpDB.Employee VALUES 
	('Bob', 'Jim', 78293029, 2),
	('Jane', 'Simmons', 09283785, 3),
	('Uruk', 'SantaCruz', 56382940, 1);

SELECT *
FROM EmpDB.Employee;

CREATE TABLE EmpDB.EmpDetails (
	EmpDetailsId INT NOT NULL PRIMARY KEY IDENTITY,
	EmployeeID INT NOT NULL,
	Salary DECIMAL(8, 2) NOT NULL,
	Address1 NVARCHAR(200),
	Address2 NVARCHAR(200),
	City NVARCHAR(100),
	State NVARCHAR(100),
	Country NVARCHAR(100),
	CONSTRAINT FK_Employee FOREIGN KEY (EmployeeID) REFERENCES EmpDB.Employee (EmployeeId)
);

INSERT INTO EmpDB.EmpDetails VALUES 
	(1, 643728.23, 'YoursTruly', NULL, 'Sacramento', 'CA', 'US'),
	(1, 72342.35, '45 Grand Ave', NULL, 'New York', 'NY', 'US'),
	(1, 123490.56, '892 Ulysses Way', NULL, 'Ensenada', 'Baja', 'MX');

SELECT *
FROM EmpDB.EmpDetails;

INSERT INTO EmpDB.Employee VALUES 
	('Tina', 'Smith', 24609284, 3);
	
SELECT *
FROM EmpDB.Employee;
	
INSERT INTO EmpDB.Department VALUES 
	('Marketing', 'Omaha');
	
SELECT *
FROM EmpDB.Department;

SELECT *
FROM EmpDB.Employee
WHERE DepartmentID = 4;

UPDATE EmpDB.Employee
SET DepartmentID = 4 
WHERE EmployeeId = 1 OR EmployeeId = 4;

-- multiplicity
-- 1 to 1
-- 1 to N -> 2 tables - FK NOT NULL
-- 0/1 to N -> 2 tables FK NULL
-- N to N -> 3 tables the middle one is a junction table connecting FKs
