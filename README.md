# EFCoreProject

SQL code to create DB with sample data

```sql
CREATE DATABASE education;

CREATE TABLE teacher (
	id INT IDENTITY(1,1) PRIMARY KEY,
	firstname VARCHAR(30),
	lastname VARCHAR(30),
	position VARCHAR(10)
);

CREATE TABLE student (
	id INT IDENTITY(1,1) PRIMARY KEY,
	firstname VARCHAR(30),
	lastname VARCHAR(30),
	group_name VARCHAR(10),
	id_teacher INT,
	FOREIGN KEY (id_teacher) REFERENCES teacher(id)
);

INSERT INTO teacher(firstname, lastname, position)
VALUES
('Mykhaylo', 'Shcherbatyy', 'docent'),
('Yuriy', 'Yashchuk', 'docent'),
('Liliia', 'Diakoniuk', 'docent');

INSERT INTO student(firstname, lastname, group_name, id_teacher)
VALUES
('Vasyl', 'Diakiv', 'PMP-42', 1),
('Ruslan', 'Partsey', 'PMP-42', 2),
('Matskiv', 'Marian', 'PMP-42', 1);
```
