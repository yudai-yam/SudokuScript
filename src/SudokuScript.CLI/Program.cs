namespace SudokuScript.CLI;

using SudokuScript.Core.Parser;

class Program {
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("add arg");
            return;
        }

        string input = args[0];

        var parser = new GridParser(input);
        var grid = parser.Parse();

        // solve here
        

    }
}
