# Task 06 - SQL & ERD Starter

## Selected Scenario
Library Management System

## Main Entities
- Authors
- Categories
- Books
- Members
- BorrowRecords

## Relationships
- Author has many Books
- Category has many Books
- Book has many BorrowRecords
- Member has many BorrowRecords

## Why I Designed It This Way
I separated `Authors` and `Categories` into their own tables to normalize the data and avoid duplication in the `Books` table. The `Books` table stores the main inventory and relies on these tables using Foreign Keys. The `Members` table holds user information independently. To track who borrowed what and when, I introduced a `BorrowRecords` table. This setup ensures that we can track multiple borrows for a single member and multiple borrow events for the same book over time, preserving a complete history of transactions.

## SQL Queries
The SQL queries and table schemas are provided in the `Library Management System.sql` file. Here are some of the key JOIN queries implemented:

```sql
-- Select books by category
select b.Title , b.PublishedYear , c.Name AS CategoryName 
from Books b
join Categories c oN b.CategoryId = c.CategoryId
where c.Name = 'Fantasy';

-- Select borrow records with member name and book title using JOIN
SELECT 
    br.BorrowRecordId, 
    m.FullName AS MemberName, 
    b.Title AS BookTitle, 
    br.BorrowDate, 
    br.Status
FROM BorrowRecords br
JOIN Members m ON br.MemberId = m.MemberId
JOIN Books b ON br.BookId = b.BookId;

-- Select top 5 most borrowed books
SELECT TOP 5 
    b.Title, 
    COUNT(br.BorrowRecordId) AS TimesBorrowed
FROM Books b
JOIN BorrowRecords br ON b.BookId = br.BookId
GROUP BY b.Title
ORDER BY TimesBorrowed DESC;
```
