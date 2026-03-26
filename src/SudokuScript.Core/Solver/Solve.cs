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
        // Base case: if the grid is fully filled, we found a solution
        if (_grid.IsComplete())
        {
            return _grid;
        }

        // Find the next empty cell to fill
        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                // Skip cells that are already filled
                if (_grid.GetCell(row, column) != 0)
                {
                    continue;
                }

                // Try each candidate digit (1-9) for this empty cell.
                // Stop the loop early if a solution is found (result != null).
                Grid? result = null;
                for (int value = 1; value <= 9 && result == null; value++)
                {
                    // If this value violates Sudoku CONSTRAINTS, skip it
                    if (!_grid.IsValid((row, column), value))
                    {
                        continue;
                    }

                    // Make the choice: place the value in this cell
                    _grid.UpdateBoard((row, column), value);

                    // Recurse: attempt to solve the rest of the grid
                    result = Solve();

                    // Undo the choice (backtrack) if this path led to no solution
                    if (result == null)
                    {
                        _grid.UpdateBoard((row, column), 0);
                    }
                }

                // Return the solution if found, or null if no valid value worked
                return result;
            }
        }

        return _grid;
    }
}