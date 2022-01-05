ALTER TABLE book ADD author_id BIGINT NULL;

ALTER TABLE book
	ADD CONSTRAINT FK_book_author FOREIGN KEY (author_id)
		REFERENCES authors(id);