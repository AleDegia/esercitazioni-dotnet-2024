class Program{
    static void Main(string[] args)
    {
        Stack<string> nomi = new Stack<string>(); //the last element added to the stack is the first one to be removed. 
        nomi.Push("Mario");//The code then pushes three strings onto the stack using the Push() method: "Mario", "Luigi", and "Giovanni". 
        nomi.Push("Luigi");//This means that "Giovanni" is now at the top of the stack, followed by "Luigi", and then "Mario".
        nomi.Push("Giovanni");//la stampa avviene prima della rimozione dell'elemento.
        System.Console.WriteLine($"Ciao {nomi.Pop()}, {nomi.Pop()}, {nomi.Pop()}"); //viene rimosso perciò sempre dall'ultimo aggiunto in giu
    }
}