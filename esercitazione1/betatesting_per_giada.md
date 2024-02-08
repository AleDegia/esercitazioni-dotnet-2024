## backtest per giada

- a "inserisci l'anno di uscita" assicurati che non si possano scrivere cose che non siano degli int, e anni che non siano superiori all'anno corrente o minori di un certo anno
(al momento se inserisco una lettera o 3000 ad es, lo prende e va avanti)

- se ad "assegna un voto" inserisco una lettera mi genera:
     Unhandled exception. System.FormatException: The input string 'g' was not in a correct format.
   at System.Number.ThrowFormatException[TChar](ReadOnlySpan`1 value)
   at System.Int32.Parse(String s)
   at Program.Main(String[] args) in C:\Users\DOTNET\Documents\Corso-Dotnet-2024\CORSO-DOTNET-2024\esercitazioni-dotnet-2024\esercitazione1\Program.cs:line 25

- ad "assegna un voto" sarebbe bene specificare all'utente se da 1 a 10 o cosa, altrimenti potrei anche mettere 90 come voto ad es..

- a "Vuoi inserire un altro videogioco?" se invece che s o n premo un altra lettera la prende come fosse una s e riparte a chiedermi le info per il nuovo videogioco da inserire

- Dopo aver inserito il primo videogioco se premo s mi chiede le info per il secondo videogioco ma poi non mi permette + di inserire una recensione
(questo però solo se metto info sbagliate, tipo mettendo 2 a ogni domanda. se le info sono giuste invece da nuovamente la possibilita di inserire una recensione) 
(a volte lo fa anche alla prima se ad esempio inserisco sempre 2 a tutto, si ferma dopo "assegna un voto")
(penso il problema sia che se esiste già un json con quel nome del videogioco si ferma dopo "assegna un voto")

- Se inserisco come titolo del videogioco un nome che è già presente come file json non viene aggiunta la mia recensione al json (ad es, se il json del gioco con titolo "2" è {"nome":"2","anno":"2","voto":"2"}, ora dando come titolo 2, anno 333 e voto 8, questo record non verrà aggiunto al file json, perciò attualmente se un gioco è gia stato recensito una volta poi le recensioni di altri utenti riguardanti quel gioco non vengono prese.)

- A "Vuoi darci più informazioni riguardo al videogioco" e a "Vuoi aggiungere una recensione personale?" se inserisco qualsiasi cosa che non sia o s o n lo prendo come n (ad es se inserisco un numero..)

- A "Vuoi darci più informazioni riguardo al videogioco" se premo s appaiono le varie opzioni da 1 a 5 e cosi via, ma se inserisco un opzione non valida, tipo 58, la prende comunque per buona e va avanti. Questo accade per tutte e 3 le domande a scelta multipla.


## suggerimenti per giada

sarebbe figo vedere anche una classifica dei giochi con le recensioni migliori o dei giochi con maggiori recensioni