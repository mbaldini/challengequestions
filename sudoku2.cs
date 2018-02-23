Sudoku is a number-placement puzzle. The objective is to fill a 9 × 9 grid with numbers in such a way that each column, each row, and each of the nine 3 × 3 sub-grids that compose the grid all contain all of the numbers from 1 to 9 one time.

Implement an algorithm that will check whether the given grid of numbers represents a valid Sudoku puzzle according to the layout rules described above. Note that the puzzle represented by grid does not have to be solvable.

Example

For

grid = [['.', '.', '.', '1', '4', '.', '.', '2', '.'],
        ['.', '.', '6', '.', '.', '.', '.', '.', '.'],
        ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
        ['.', '.', '1', '.', '.', '.', '.', '.', '.'],
        ['.', '6', '7', '.', '.', '.', '.', '.', '9'],
        ['.', '.', '.', '.', '.', '.', '8', '1', '.'],
        ['.', '3', '.', '.', '.', '.', '.', '.', '6'],
        ['.', '.', '.', '.', '.', '7', '.', '.', '.'],
        ['.', '.', '.', '5', '.', '.', '.', '7', '.']]
the output should be
sudoku2(grid) = true;

For

grid = [['.', '.', '.', '.', '2', '.', '.', '9', '.'],
        ['.', '.', '.', '.', '6', '.', '.', '.', '.'],
        ['7', '1', '.', '.', '7', '5', '.', '.', '.'],
        ['.', '7', '.', '.', '.', '.', '.', '.', '.'],
        ['.', '.', '.', '.', '8', '3', '.', '.', '.'],
        ['.', '.', '8', '.', '.', '7', '.', '6', '.'],
        ['.', '.', '.', '.', '.', '2', '.', '.', '.'],
        ['.', '1', '.', '2', '.', '.', '.', '.', '.'],
        ['.', '2', '.', '.', '3', '.', '.', '.', '.']]
the output should be
sudoku2(grid) = false.

The given grid is not correct because there are two 1s in the second column. Each column, each row, and each 3 × 3 subgrid can only contain the numbers 1 through 9 one time.

Input/Output

[execution time limit] 3 seconds (cs)

[input] array.array.char grid

A 9 × 9 array of characters, in which each character is either a digit from '1' to '9' or a period '.'.

[output] boolean

Return true if grid represents a valid Sudoku puzzle, otherwise return false.

bool sudoku2(char[][] grid) {
    
    // iterate through the x-axis
    for (int x = 0; x < 9; x++) {
        // check for duplicate values along the x-axis
        HashSet<int> values = new HashSet<int>();
        for (int y = 0; y < 9; y++) {
            int value = parseValue(grid[x][y]);
            // if duplicates exist, return false
            if (value > 0 && values.Contains(value)) return false;
            values.Add(value);
        }
    }
    
    for (int y = 0; y < 9; y++) {
        // check for duplicate values along the y-axis
        HashSet<int> values = new HashSet<int>();
        for (int x = 0; x < 9; x++) {
            int value = parseValue(grid[x][y]);
            // if duplicates exist, return false
            if (value > 0 && values.Contains(value)) return false;
            values.Add(value);
        }
    }
    
    for (int dx = 0; dx < 3; dx++) {
        for (int dy = 0; dy < 3; dy++) {
            HashSet<int> values = new HashSet<int>();
            // ensure the 3x3 subgrid contains numbers 1-9
            for (int ix = 0; ix < 3; ix++) {
                for (int iy = 0; iy < 3; iy++) {
                    int x = (dx * 3) + ix;
                    int y = (dy * 3) + iy;
                    int value = parseValue(grid[x][y]);
                    // if we have a duplicate number in the grid, return false
                    if (value > 0 && values.Contains(value)) return false;
                    values.Add(value);
                }
            }
        }
    }
    
    return true;
}

int parseValue(char c) {
    int value = 0;
    int.TryParse(c.ToString(), out value);
    if (value > 9 || value < 0) {
        return 0;
    }
    return value;
}
