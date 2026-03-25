namespace SudokuScript.Core.Solver;

using SudokuScript.Core.Models;

public class Solver
{
    private readonly Grid _grid;

    public Solver(Grid grid)
    {
       this._grid = grid; 
    }

    public Grid? Solve()
    {
        for (int row=0; row<9; row++)
        {
            for (int column=0; column<9; column++)
            {
                // skip prefilled values
                if (_grid.GetCell(row, column) != 0)
                {
                    continue;
                }

                for (int value=1; value<=9; value++)
                {
                    if (_grid.IsValid((row, column), value))
                    {
                        _grid.UpdateBoard((row, column), value);

                        if (_grid.IsComplete())
                        {
                            return _grid;
                        }

                        var result = Solve();
                        if (result != null)
                        {
                            return result;
                        }

                        _grid.UpdateBoard((row, column), 0); //backtrack
                    }
                }
                return null;
            }
        } 
        return _grid;
    }
}