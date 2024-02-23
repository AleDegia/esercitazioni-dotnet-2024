using Spectre.Console; 
class Programm{
    static void Main(string[] args)
    {
        AnsiConsole.Markup("[underline red] Hello[/] World\n");       //

        var table = new Table();
        table.AddColumn("Column 1");
        table.AddColumn("Column 2");
        table.AddRow("Valore 1", "Valore 2");
        table.AddRow("Valore 3", "Valore 4");
        table.AddRow("Valore 3");

        AnsiConsole.Write(table);

        AnsiConsole.Markup("Hello :globe_showing_europe_africa:!");

        AnsiConsole.Progress()
            .Start(ctx =>
            {
                //define class
                var task1 = ctx.AddTask("[green]Reticulating splines[/]");
                var task2 = ctx.AddTask("[green]Folding space[/]");
                
                while(!ctx.IsFinished)
                {
                    task1.Increment(1.5);
                    task2.Increment(2.5);
                }
            });
    }
}

