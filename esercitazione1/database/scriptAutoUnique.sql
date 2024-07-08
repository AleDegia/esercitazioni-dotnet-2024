/*il nome del record che insieriamo non deve essere già presente nel database in un altro record*/
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);