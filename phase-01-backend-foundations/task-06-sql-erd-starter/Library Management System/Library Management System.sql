-- 1. Create independent tables first
CREATE TABLE Authors (
    AuthorId INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(100) NOT NULL,
    BirthDate DATE,
    Country VARCHAR(50)
);

CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(255)
);

-- 2. Create tables with Foreign Keys
CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(150) NOT NULL,
    ISBN VARCHAR(20),
    PublishedYear INT,
    AvailableCopies INT,
    AuthorId INT,
    CategoryId INT,
    FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

-- 3. Create the Members table (Independent)
CREATE TABLE Members (
    MemberId INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    PhoneNumber VARCHAR(20),
    JoinDate DATE,
    -- In MSSQL, 'BIT' is used for true/false (1/0) instead of boolean
    IsActive BIT
);

-- 4. Create the BorrowRecords table (Relies on Books and Members)
CREATE TABLE BorrowRecords (
    BorrowRecordId INT PRIMARY KEY IDENTITY(1,1),
    BookId INT,
    MemberId INT,
    BorrowDate DATE,
    DueDate DATE,
    ReturnDate DATE,
    Status VARCHAR(50),
    
    -- Define the Foreign Keys connecting this table to Books and Members
    FOREIGN KEY (BookId) REFERENCES Books(BookId),
    FOREIGN KEY (MemberId) REFERENCES Members(MemberId)
);
INSERT INTO Authors (FullName, BirthDate, Country)
VALUES 
    ('J.K. Rowling', '1965-07-31', 'UK'),
    ('George Orwell', '1903-06-25', 'UK'),
    ('Isaac Asimov', '1920-01-02', 'USA'),
    ('Agatha Christie', '1890-09-15', 'UK'),
    ('Naguib Mahfouz', '1911-12-11', 'Egypt');

INSERT INTO Categories (Name, Description)
VALUES 
    ('Fantasy', 'Magical and supernatural themes.'),
    ('Dystopian', 'Societies in cataclysmic decline.'),
    ('Sci-Fi', 'Futuristic concepts and advanced science.'),
    ('Mystery', 'Crime solving and suspenseful plots.'),
    ('Historical Fiction', 'Stories set in the past reflecting history.');

INSERT INTO Books (Title, ISBN, PublishedYear, AvailableCopies, AuthorId, CategoryId)
VALUES 
    ('Harry Potter and the Sorcerer''s Stone', '978-0590353427', 1997, 5, 1, 1),
    ('1984', '978-0451524935', 1949, 3, 2, 2),
    ('Foundation', '978-0553293357', 1951, 4, 3, 3),
    ('Murder on the Orient Express', '978-0062073501', 1934, 2, 4, 4),
    ('The Cairo Trilogy', '978-0307386227', 1956, 1, 5, 5);


INSERT INTO Members (FullName, Email, PhoneNumber, JoinDate, IsActive)
VALUES 
    ('Ahmed Hassan', 'ahmed@example.com', '01012345678', '2023-01-15', 1),
    ('Sara Youssef', 'sara@example.com', '01123456789', '2023-03-22', 1),
    ('Omar Khaled', 'omar@example.com', '01234567890', '2022-11-05', 0),
    ('Mona Ali', 'mona@example.com', '01545678901', '2024-01-10', 1),
    ('Tarek Fahmy', 'tarek@example.com', '01098765432', '2021-08-30', 1);

INSERT INTO BorrowRecords (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Status)
VALUES 
    (1, 1, '2024-02-01', '2024-02-15', '2024-02-10', 'Returned'),
    (2, 2, '2024-02-05', '2024-02-19', NULL, 'Borrowed'),
    (3, 4, '2024-01-10', '2024-01-24', '2024-01-28', 'Late Return'),
    (4, 1, '2024-02-12', '2024-02-26', NULL, 'Borrowed'),
    (5, 5, '2023-12-01', '2023-12-15', '2023-12-12', 'Returned');


select * from Books;
--2. Select all active members
select * from Members where IsActive = 1;
--3. Select books by category
select b.Title , b.PublishedYear , c.Name AS CategoryName 
from Books b
join Categories c oN b.CategoryId = c.CategoryId
where c.Name = 'Fantasy'

--4. Count books per category
SELECT c.Name AS CategoryName, COUNT(b.BookId) AS TotalBooks
FROM Categories c
LEFT JOIN Books b ON c.CategoryId = b.CategoryId
GROUP BY c.Name;
--5. Select borrow records with member name and book title using JOIN
SELECT 
    br.BorrowRecordId, 
    m.FullName AS MemberName, 
    b.Title AS BookTitle, 
    br.BorrowDate, 
    br.Status
FROM BorrowRecords br
JOIN Members m ON br.MemberId = m.MemberId
JOIN Books b ON br.BookId = b.BookId;
--6. Select overdue books
SELECT 
    m.FullName AS MemberName, 
    b.Title AS BookTitle, 
    br.DueDate
FROM BorrowRecords br
JOIN Members m ON br.MemberId = m.MemberId
JOIN Books b ON br.BookId = b.BookId
WHERE br.ReturnDate IS NULL 
  AND br.DueDate < GETDATE();
--7. Select borrowing history for one member

SELECT 
    b.Title, 
    br.BorrowDate, 
    br.ReturnDate, 
    br.Status
FROM BorrowRecords br
JOIN Books b ON br.BookId = b.BookId
WHERE br.MemberId = 1;

--8. Select available books
SELECT Title, AvailableCopies 
FROM Books 
WHERE AvailableCopies > 0;

--9. Count how many books each author has
SELECT a.FullName AS AuthorName, COUNT(b.BookId) AS NumberOfBooks
FROM Authors a
LEFT JOIN Books b ON a.AuthorId = b.AuthorId
GROUP BY a.FullName;
--10. Select top 5 most borrowed books
SELECT TOP 5 
    b.Title, 
    COUNT(br.BorrowRecordId) AS TimesBorrowed
FROM Books b
JOIN BorrowRecords br ON b.BookId = br.BookId
GROUP BY b.Title
ORDER BY TimesBorrowed DESC;