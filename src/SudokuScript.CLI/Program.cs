namespace SudokuScript.CLI;

using SudokuScript.Core.Parser;
using SudokuScript.Core.Solver;

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
        var solver = new Solver(grid);
        var result = solver.Solve();

        if (result == null)
            Console.WriteLine("No solution found.");
        else
            Console.WriteLine(result);
         
    }
}
