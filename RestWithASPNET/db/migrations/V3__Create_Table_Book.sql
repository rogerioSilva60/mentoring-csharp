﻿CREATE TABLE book (
	id BIGINT IDENTITY(1,1) PRIMARY KEY,
	author VARCHAR(255),
	launch_date DATETIME,
	price DECIMAL(38,2),
	title VARCHAR(255)
);