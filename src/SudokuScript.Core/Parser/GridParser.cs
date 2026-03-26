namespace SudokuScript.Core.Parser;

using SudokuScript.Core.Models;

// parse the input into a grid
public class GridParser
{
    private readonly string _input;

    public GridParser(string input)
    {
        this._input = input;
    }

    public Grid Parse()
    {
        if (_input.Length != 9*9)
        {
            // throw error
            throw new ArgumentException($"Input must be exactly 9x9 characters, but got {_input.Length}.");
        }
        Grid grid = new Grid();

        for (int i=0; i<9*9; i++)
        {
            int row = i/9;
            int column = i % 9;
            
            grid.UpdateBoard((row, column), _input[i] - '0');
        }

        return grid;
    }
}