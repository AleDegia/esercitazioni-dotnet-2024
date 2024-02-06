### es json

L'obiettivo è perettere a degli utenti di simulare l'acquisto di un prodotto tramite un sito web.
Il json dovrà storare i nomi utenti e le password per poi permettere l'accesso al sito tramite il login.
In base a quale utente è loggato, relazionare i dati degli acquisti a quell'utente, perciò gli utenti poi potranno vedere i propri acquisti ed il proprio saldo.


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


### BETA TESTING

- controllare perchè se inserisco dei dati sbagliati non esce dal loop (lo fa solo quando mi registro anche)
- mettere la map dei prodotti acquistabili come json
- quando mi registro, se poi esegui il login senza chiudere il programma non funziona