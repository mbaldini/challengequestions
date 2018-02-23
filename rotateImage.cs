// Note: Try to solve this task in-place (with O(1) additional memory), since this is what you'll be asked to do during an interview.

// You are given an n x n 2D matrix that represents an image. Rotate the image by 90 degrees (clockwise).

// Example

// For

// a = [[1, 2, 3],
//      [4, 5, 6],
//      [7, 8, 9]]
// the output should be

// rotateImage(a) =
//     [[7, 4, 1],
//      [8, 5, 2],
//      [9, 6, 3]]
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.array.integer a

// Guaranteed constraints:
// 1 ≤ a.length ≤ 100,
// a[i].length = a.length,
// 1 ≤ a[i][j] ≤ 104.

// [output] array.array.integer

int[][] rotateImage(int[][] a) {
    int length = a.Length;
    
    // Top Left -> Top Right
    // Top Right -> Bottom Right
    // Bottom Right -> Bottom Left
    // Bottom Left -> Top Left
    for (int i = 0; i < length / 2; i++) {
        int last = length - 1 - i;
        for (int j = i; j < last; j++) {
            int delta = j - i;
            // save the first element into a temp variable
            int tmp = a[i][j];
            // move left to top
            a[i][j] = a[last - delta][i];
            // move bottom to left
            a[last - delta][i] = a[last][last - delta];
            // move right to bottom
            a[last][last - delta] = a[j][last];
            // move top to right
            a[j][last] = tmp;
        }
    }
    
    return a;
}
