### es json

L'obiettivo del programma è quello di permttere a degli utenti di simulare l'acquisto di un prodotto tramite un sito web, previo login, e visualizzare il proprio bilancio ed il proprio storico degli acquisti.
Un primo json permetterà di storare i nomi degli utenti e le rispettive password per poi permettere l'accesso al sito tramite il login.
I successivi json verranno creati dinamicamente in base a quale utente è loggato, e serviranno a contenere i dati degli acquisti e del bilancio di quello specifico utente. Grazie a questi json qualsiasi utente già registrato potrà vedere i propri acquisti ed il proprio saldo.


### Sequenza lavoro
- permettere ad un utente di registrarsi e fare il login    V 
- chiedere all'utente se deve registrarsi o se deve fare il login    V
- mettere in un file json il nome degli gli utenti registrati e le password prendendoli dalle rispettive liste   V
- permettere il login verificando se nel json chiave e valore corrispondono V
- permettere l'acquisto solo agli utenti loggati (e permettere il logout)
- proporre una lista di acquisti possibili
- far partire l'acquisto solo se il saldo è ok (e aggiornare il balance per ogni utente)
- fare un json per ogni utente che colleghi un utente specifico ai suoi acquisti
- ogni acquisto contiene: data, oggetto comprato, importo speso
- far vedere tutti gli acquisti fatti da un determinato utente se l'utente è loggato




### consigli utili
- aggiungere in una lista ogni utente nuovo utente che si registra
- creare un json in base al numero dei json presenti o se non trova un json con quel nome (indice)
-  Creare la parte del testo predeterminata
    -  string parteTestoFissa = "acquisto";
- Comporre il nome del file JSON
    -  string nomeFile = $"{parteTestoFissa}_{numeroAcquisto}.json";



### in +
-  Creare un nome casuale usando un Guid
    - string nomeFile = Guid.NewGuid().ToString() + ".json";


### BETA TESTING MIO

- controllare perchè se inserisco dei dati sbagliati non esce dal loop (lo fa solo quando mi registro anche) V
- mettere la map dei prodotti acquistabili come json   V
- quando mi registro, se poi esegui il login senza chiudere il programma non funziona    V
- risolvere il problema della registrazione utente che attualmente è permessa anche se è utente è già registrato   V
- se a "cosa vuoi acquistare" invece che 1,2 o 3 premo un altro numero mi dice scelta non valida ma mi cambia il balance   V
- se acquisto anche se non ho soldi mi dice che non ho soldi ma il balance in realtà mi va sotto zero    V