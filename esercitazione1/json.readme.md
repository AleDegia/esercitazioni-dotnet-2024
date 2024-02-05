### es json

L'obiettivo è quello di simulare l'acquisto di un qualsiasi prodotto tramite un sito web.
Il json dovrà storare i nomi utenti e le password per dare l'accesso al sito
In base a quale utente è loggato, relazionare i dati degli acquisti a quell'utente


### Sequenza lavoro
- permettere ad un utente di registrarsi e fare il login    V 
- chiedere all'utente se deve registrarsi o se deve fare il login    V
- mettere in un file json gli utenti registrati e le password prendendoli dalle rispettive liste   V
- permettere l'acquisto solo agli utenti loggati (e permettere il logout)
- proporre una lista di acquisti possibili
- far partire l'acquisto solo se il saldo è ok 
- fare un json per ogni utente che colleghi un utente specifico ad un determinato acquisto che conterrà: data, oggetto, spesa, importo speso
- far vedere tutti gli acquisti fatti da un determinato utente se l'utente è loggato


### cosnigli utili
- aggiungere in una lista ogni utente nuovo utente che si registra
- creare un json in base al numero dei json presenti o se non trova un json con quel nome (indice)
-  Creare la parte del testo predeterminata
    -  string parteTestoFissa = "acquisto";
- Comporre il nome del file JSON
    -  string nomeFile = $"{parteTestoFissa}_{numeroAcquisto}.json";



### in +
-  Creare un nome casuale usando un Guid
    - string nomeFile = Guid.NewGuid().ToString() + ".json";