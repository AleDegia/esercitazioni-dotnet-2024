CREATE TABLE clienti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, cognome TEXT);
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_cliente INTEGER, FOREIGN KEY (id_cliente) REFERENCES categorie(id));
CREATE TABLE acquisti (id INTEGER PRIMARY KEY AUTOINCREMENT, cliente TEXT,  quantita INTEGER CHECK (quantita >= 1), prodotto TEXT, id_cliente INTEGER, id_prodotto INTEGER, FOREIGN KEY (id_cliente) REFERENCES clienti(id), FOREIGN KEY (id_prodotto) REFERENCES prodotti(id));
/*CREATE TABLE acquisti (id INTEGER PRIMARY KEY AUTOINCREMENT, numero INTEGER, cliente TEXT, prodotto TEXT, FOREIGN KEY (cliente) REFERENCES clienti(nome), FOREIGN KEY (prodotto) REFERENCES prodotti(nome));*/
INSERT INTO clienti (nome, cognome) VALUES ('Luca', 'Rossi');
INSERT INTO clienti (nome, cognome) VALUES ('Marco', 'Verdi');
INSERT INTO clienti (nome, cognome) VALUES ('Pina', 'Anip');
INSERT INTO prodotti (nome, prezzo, quantita, id_cliente) VALUES ('prodotto1', 19.99, 120, 2), ('prodotto2', 38.99, 58, 1), ('prodotto3', 99.99, 23, 3);
INSERT INTO acquisti (cliente, prodotto, id_cliente, id_prodotto, quantita) VALUES ('Luca', 'prodotto3', 1, 3, 2), ('Pina', 'prodotto3', 3, 3, 1), ('Luca', 'prodotto3', 1, 3, 2);
SELECT * FROM prodotti JOIN clienti ON prodotti.id_cliente = clienti.id;
SELECT * FROM acquisti WHERE acquisti.cliente = 'Luca';    /*seleziono tutti gli acquisti fatti da luca*/
SELECT cliente, SUM(quantita) AS somma_quantita FROM acquisti  WHERE cliente = 'Luca';

