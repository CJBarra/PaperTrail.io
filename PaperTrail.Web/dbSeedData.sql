INSERT INTO 
BranchOffices(ImageUrl, [Address], [Name], Telephone, OpenDate, [Description]) 
VALUES 
('/PaperTrail.Web/wwwroot/images/branches/1.png', '88 Lakeshore Dr', 'Lake Shore Branch', '555-1234', '1975-05-13', 'The oldest library branch in Lakeview, the Lake Shore Branch was opened in 1975. Patrons of all ages enjoy the wide selection of literature available at Lake Shore library. The coffee shop is open during library hours of operation.'),
('/PaperTrail.Web/wwwroot/images/branches/2.png', '123 Skyline Dr', 'Mountain View Branch', '555-1235', '1998-06-01', 'The Mountain View branch contains the largest collection of technical and language learning books in the region. This branch is within walking distance to the University campus'),
('/PaperTrail.Web/wwwroot/images/branches/3.png', '540 Inventors Circle', 'Pleasant Hill Branch', '555-1236', '2017-09-20', 'The newest Lakeview Library System branch, Pleasant Hill has high-speed wireless access for all patrons and hosts Chess Club every Monday and Wednesday evening at 6 PM.');
SELECT * FROM BranchOffices

INSERT INTO PatronCards(Created, Fees) VALUES 
('2017-06-20', 12.00),
('2017-06-20', 0.00),
('2017-06-21', 0.50),
('2017-06-21', 0.00),
('2017-06-21', 3.50),
('2017-06-23', 1.50),
('2017-06-23', 0.00),
('2017-06-23', 8.00);
SELECT * FROM PatronCards

INSERT INTO 
Patrons([Address], DoB, FirstName, LocalBranchOfficeId, LastName, PatronCardId, PhoneNumber) VALUES
('165 Peace St', '1986-07-10', 'Jane', 1, 'Patterson', 1, '555-1234'),
('324 Shadow Ln', '1984-03-12', 'Margaret', 2, 'Smith', 2, '555-7785'),
('18 Stone Cir', '1956-02-10', 'Tomas', 2, 'Galloway', 3, '555-3467'),
('246 Jennifer St', '1997-01-17', 'Mary', 3, 'Li', 4, '555-1223'),
('1465 Williamson St', '1952-09-16', 'Dan', 3, 'Carter', 5, '555-8884'),
('785 Park Ave', '1994-03-24', 'Aruna', 3, 'Adhiban', 6, '555-9988'),
('5654 Main St', '2001-11-23', 'Raj', 1, 'Prasad', 7, '555-7894'),
('1352 Bicycle Ct', '1981-10-16', 'Tatyana', 3, 'Ponomaryova', 8, '555-4568');
SELECT * FROM Patrons

INSERT INTO Statuses 
([Name], [Description]) VALUES
('Checked Out', 'A library asset that has been checked out'),
('Available', 'A library asset that is available for loan'),
('Lost', 'A library asset that has been lost'),
('On Hold', 'A library asset that has been placed On Hold for loan')
SELECT * FROM Statuses

INSERT INTO BranchAssets
(Discriminator, Cost, LocationId, StatusId, Author, DeweyIndex, ISBN, Title, [Year], Director, ImageUrl, NumberOfCopies) VALUES
('Book', 18.00, 2, 2, 'Jane Austen', '823.123', '38d6b0cf-2f3a-479e-a905-1c19e92a8838', 'Emma', 1815, NULL, '/PaperTrail.Web/wwwroot/images/emma.png', 1),
('Book', 18.00, 3, 2, 'Charlotte Bronte', '822.133', 'cdf83a17-0db1-44ee-9da8-2551737ff154', 'Jane Eyre', 1847, NULL, '/PaperTrail.Web/wwwroot/images/janeeyre.png', 1),
('Book', 12.99, 2, 2, 'Herman Melville', '821.153', '2695fc11-0cd9-485d-9154-74d08e20933f', 'Moby Dick', 1851, NULL, '/PaperTrail.Web/wwwroot/images/mobydick.png', 1),
('Book', 24.00, 2, 2, 'James Joyce', '822.556', '6f241f2a-7d6a-4254-acdf-2428dc89ca94', 'Ulysses', 1922, NULL, '/PaperTrail.Web/wwwroot/images/ulysses.png', 3),
('Book', 11.00, 3, 2, 'Plato', '820.119', 'de933dee-0804-4f67-bd1a-3077aeb43abd', 'Republic', -380, NULL, '/PaperTrail.Web/wwwroot/images/republic.png', 2),
('Book', 18.00, 3, 2, 'Bram Stoker', '821.526', '2e653091-ca34-45d8-a215-37c67a7c9512', 'Dracula', 1897, NULL, '/PaperTrail.Web/wwwroot/images/dracula.png', 4),
('Book', 12.99, 2, 2, 'Don Delillo', '822.436', 'e7ffe0a0-52df-4439-90ee-2968d5f48c11', 'White Noise', 1985, NULL, '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Book', 16.00, 2, 2, 'James Baldwin', '821.325', 'a6f37f67-6a97-4654-a6f0-45e10c43ecc0', 'Another Country', 1962, NULL, '/PaperTrail.Web/wwwroot/images/default.png', 2),
('Book', 11.00, 1, 2, 'Virginia Woolf', '822.888', 'fed6e4bf-8169-45ec-a33d-4fd9ba133fa3', 'The Waves', 1931, NULL, '/PaperTrail.Web/wwwroot/images/thewaves.png', 1),
('Book', 11.99, 1, 2, 'Alice Walker',	'820.298', '90dd13ce-799b-49aa-a7f1-9b155e7f1de0', 'The Color Purple', 1982, NULL, '/PaperTrail.Web/wwwroot/images/default.png', 2),
('Book', 12.50, 1, 2, 'Gabriel Garcia Marquez', '821.544', '9a2a7cc4-f505-4bcf-ba05-5bb92cbcba91', 'One Hundred Years of Solitude', 1967, NULL, '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Book', 22.00, 1, 2, 'Alice Monroe', '821.444', 'b3906940-2444-4653-9367-647477067cec', 'Friend of My Youth', 1990, NULL, '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Book', 13.50, 1, 2, 'Virginia Woolf', '820.111', '83e699eb-e792-4e98-88d9-a61bdcd89379', 'To the Lighthouse', 1927, NULL, '/PaperTrail.Web/wwwroot/images/tothelighthouse.png', 5),
('Book', 15.99, 3, 2, 'Virginia Woolf', '821.254', '6037b0fb-f56f-43ef-8992-abe805da1323', 'Mrs Dalloway', 1925, NULL, '/PaperTrail.Web/wwwroot/images/mrsdalloway.png', 1),
('Video', 24.00, 1, 2, NULL, NULL, NULL, 'Blue Velvet',	1986, 'David Lynch', '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Video', 24.00, 1, 2, NULL, NULL, NULL, 'Trois Coleurs: Rouge', 1994, 'Krzysztof Kieslowski', '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Video', 30.00, 1, 2, NULL, NULL, NULL, 'Citizen Kane',	1941, 'Orson Welles', '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Video', 28.00, 2, 2, NULL, NULL, NULL, 'Spirited Away',	2002, 'Hayao Miyazaki', '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Video', 23.00, 2, 2, NULL, NULL, NULL, 'The Departed',	2006, 'Martin Scorsese', '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Video', 17.99, 2, 2, NULL, NULL, NULL, 'Taxi Driver', 1976, 'Martin Scorsese', '/PaperTrail.Web/wwwroot/images/default.png', 1),
('Video', 18.00, 3, 2, NULL, NULL, NULL, 'Casablanca',	1943, 'Michael Curtiz', '/PaperTrail.Web/wwwroot/images/default.png', 1);
SELECT * FROM BranchAssets

INSERT INTO BranchHours (BranchId, ClosedHours, [DayOfWeek], OpenHours) VALUES 
(1, 14, 1, 7),
(1, 18, 2, 7),
(1, 18, 3, 7),
(1, 18, 4, 7),
(1, 18, 5, 7),
(1, 18, 6, 7),
(1, 14, 7, 7),

(2, 20, 1, 6),
(2, 20, 2, 6),
(2, 20, 3, 6),
(2, 20, 4, 6),
(2, 20, 5, 6),
(2, 20, 6, 6),
(2, 20, 7, 6),

(3, 22, 1, 5),
(3, 18, 2, 5),
(3, 18, 3, 5),
(3, 18, 4, 5),
(3, 18, 5, 5),
(3, 22, 6, 5),
(3, 22, 7, 5)