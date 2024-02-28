using Newtonsoft.Json;

public class GestioneJson
{
    static void Main(string[] args)
    {
        Persona persona = new Persona()             //invece che usare un costruttore, siccome la classe Persona non lo ha, assgnamo direttamente
        {
            Nome = "Mario Rossi",
            Eta = 30,
            Impiegato = true
        };

        //Serializzazione dell'oggetto in una stringa json
        string json = JsonConvert.SerializeObject(persona, Formatting.Indented);
        File.WriteAllText(@"persona.json", json);

        //Deserializzazione della stringa JSON in un oggetto persona
        string jsonDaLeggere = File.ReadAllText(@"persona.json");
        Persona personaDeserializzata = JsonConvert.DeserializeObject<Persona>(jsonDaLeggere);

        System.Console.WriteLine(personaDeserializzata.Nome);
    }
}



/*
string json = JsonConvert.SerializeObject(persona, Formatting.Indented);

- prende l'oggetto persona e lo serializza in una stringa JSON utilizzando il metodo SerializeObject della classe JsonConvert. 
Il parametro Formatting.Indented viene utilizzato per formattare la stringa JSON in modo leggibile, con indentazione. 
La stringa JSON risultante viene quindi memorizzata nella variabile json.

File.WriteAllText(@"persona.json", json);

- Questo codice scrive la stringa JSON nel file chiamato "persona.json" sul disco.

string jsonDaLeggere = File.ReadAllText(@"persona.json");
Persona personaDeserializzata = JsonConvert.DeserializeObject<Persona>(jsonDaLeggere);

- Questo codice legge il contenuto del file "persona.json" e lo memorizza nella stringa jsonDaLeggere. 
Successivamente, utilizza il metodo DeserializeObject della classe JsonConvert per deserializzare la stringa JSON in un oggetto di tipo Persona. 
Il tipo di destinazione (Persona) viene specificato come parametro generico <T> del metodo DeserializeObject. 
L'oggetto deserializzato viene quindi memorizzato nella variabile personaDeserializzata.