CREATE TABLE person (
	id BIGINT IDENTITY(1,1) PRIMARY KEY,
	first_name VARCHAR(255),
	last_name VARCHAR(255),
	address VARCHAR(255),
	gender VARCHAR(255)
);