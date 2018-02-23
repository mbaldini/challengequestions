// A cryptarithm is a mathematical puzzle for which the goal is to find the correspondence between letters and digits, such that the given arithmetic equation consisting of letters holds true when the letters are converted to digits.

// You have an array of strings crypt, the cryptarithm, and an an array containing the mapping of letters and digits, solution. The array crypt will contain three non-empty strings that follow the structure: [word1, word2, word3], which should be interpreted as the word1 + word2 = word3 cryptarithm.

// If crypt, when it is decoded by replacing all of the letters in the cryptarithm with digits using the mapping in solution, becomes a valid arithmetic equation containing no numbers with leading zeroes, the answer is true. If it does not become a valid arithmetic solution, the answer is false.

// Example

// For crypt = ["SEND", "MORE", "MONEY"] and

// solution = [['O', '0'],
//             ['M', '1'],
//             ['Y', '2'],
//             ['E', '5'],
//             ['N', '6'],
//             ['D', '7'],
//             ['R', '8'],
//             ['S', '9']]
// the output should be
// isCryptSolution(crypt, solution) = true.

// When you decrypt "SEND", "MORE", and "MONEY" using the mapping given in crypt, you get 9567 + 1085 = 10652 which is correct and a valid arithmetic equation.

// For crypt = ["TEN", "TWO", "ONE"] and

// solution = [['O', '1'],
//             ['T', '0'],
//             ['W', '9'],
//             ['E', '5'],
//             ['N', '4']]
// the output should be
// isCryptSolution(crypt, solution) = false.

// Even though 054 + 091 = 145, 054 and 091 both contain leading zeroes, meaning that this is not a valid solution.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.string crypt

// An array of three non-empty strings containing only uppercase English letters.

// Guaranteed constraints:
// crypt.length = 3,
// 1 ≤ crypt[i].length ≤ 14.

// [input] array.array.char solution

// An array consisting of pairs of characters that represent the correspondence between letters and numbers in the cryptarithm. The first character in the pair is an uppercase English letter, and the second one is a digit in the range from 0 to 9.

// Guaranteed constraints:
// solution[i].length = 2,
// 'A' ≤ solution[i][0] ≤ 'Z',
// '0' ≤ solution[i][1] ≤ '9',
// solution[i][0] ≠ solution[j][0], i ≠ j,
// solution[i][1] ≠ solution[j][1], i ≠ j.

// It is guaranteed that solution only contains entries for the letters present in crypt and that different letters have different values.

// [output] boolean

// Return true if the solution represents the correct solution to the cryptarithm crypt, otherwise return false.

boolean isCryptSolution(String[] crypt, char[][] solution) {
    String[] values = new String[crypt.length];
    
    // iterate through the crypt
    for (int i = 0; i < crypt.length; i++) {
        char[] word = crypt[i].toCharArray();
        // ensure there is actually a word
        if (word.length == 0) return false;
        
        values[i] = "";
        // iterate through the crypt word
        for (int x = 0; x < word.length; x++) {
            // set the variable in the values array to the mapped value
            values[i] += GetMappedCharacter(word[x], solution);
        }
    }
    
    // ensure we have no leading zeros
    if (HasLeadingZero(values[0]) || HasLeadingZero(values[1]) || HasLeadingZero(values[2])) return false;
    
    // ensure we meet the word[1] + word[2] = word[3] restriction
    return Long.parseLong(values[0]) + Long.parseLong(values[1]) == Long.parseLong(values[2]);
}

boolean HasLeadingZero(String value) {
    char[] chars = value.toCharArray();
    if (chars.length > 1 && chars[0] == '0') return true;
    if (chars.length == 0) return true;
    return false;
}

char GetMappedCharacter(char c, char[][] map) {
    // check the map for the corresponding value
    for (int i = 0; i < map.length; i++) {
        if (map[i][0] == c) {
            return map[i][1];
        }
    }
    return '0';
}
