namespace SudokuScript.Core.Models;

public class Grid
{
    private readonly int[,] _cells;

    public Grid()
    {
        this._cells = new int[9,9];
    }

    public int GetCell(int row, int column)
    {
        return _cells[row, column];
    }
        
    public void UpdateBoard((int row, int column) move, int value)
    {
        _cells[move.row, move.column] = value;
    }

    public Boolean IsComplete()
    {
        for (int row=0; row<9; row++)
        {
           for (int column=0; column<9; column++)
            {
                if (GetCell(row, column) == 0)
                {
                    return false;
                }
            } 
        }
        return true;
    }

    public Boolean IsValid((int row, int column) move, int value)
    {
        int row = move.row;
        int column = move.column;

        int targetCell = GetCell(row, column);

        // check if it's empty
        if (targetCell != 0)
        {
            return false;
        } 

        // check if the square does not already have the value
        int squareRow = move.row / 3;
        int squareColumn = move.column / 3;

        for (int r=squareRow; r<squareRow+3; r++)
        {
            for (int c=squareColumn; r<squareColumn+3; c++)
            {
                if (GetCell(r, c) == value)
                {
                    return false;
                }
            }
        }

        // check if the row / column does not already have the value
        for (int r=0; r<9; r++)
        {
            if (GetCell(r, column) == value)
            {
                return false;
            }
        }
        for (int c=0; c<9; c++)
        {
            if (GetCell(row, c) == value)
            {
                return false;
            }
        }

        return true;

    }
}