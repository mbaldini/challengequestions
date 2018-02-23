// Note: Write a solution that only iterates over the string once and uses O(1) additional memory, since this is what you would be asked to do during a real interview.

// Given a string s, find and return the first instance of a non-repeating character in it. If there is no such character, return '_'.

// Example

// For s = "abacabad", the output should be
// firstNotRepeatingCharacter(s) = 'c'.

// There are 2 non-repeating characters in the string: 'c' and 'd'. Return c since it appears in the string first.

// For s = "abacabaabacaba", the output should be
// firstNotRepeatingCharacter(s) = '_'.

// There are no characters in this string that do not repeat.

// Input/Output

// [execution time limit] 3 seconds (java)

// [input] string s

// A string that contains only lowercase English letters.

// Guaranteed constraints:
// 1 ≤ s.length ≤ 105.

// [output] char

// The first non-repeating character in s, or '_' if there are no characters that do not repeat.

char firstNotRepeatingCharacter(String s) {
    // Keep a Map of the characters and their count
    HashMap<Character, Integer> charList = new HashMap<Character, Integer>();
    // Keep a Map of the characters and their first indicies
    HashMap<Character, Integer> charIndicies = new HashMap<Character, Integer>();
    
    char[] chars = s.toCharArray();
    // iterate through all the characters and populate the Maps
    for (int i = 0; i < chars.length; i++) {
        char c = chars[i];
        if (charList.containsKey(c)) {
            int v = charList.get(c);
            charList.put(c, v + 1);
        } else {
            charList.put(c, 1);
            charIndicies.put(c, i);
        }
    }
    
    // Keeps track of our lowest non-repeating index
    int curIndex = -1;
    char curChar = '_';
    // Now iterate through the keys of the character Map to find ones that have no duplicates
    for (char key : charList.keySet()) {
        if (charList.get(key) == 1) {
            int index = charIndicies.get(key);
            if (curIndex == -1 || index < curIndex) {
                curIndex = index;
                curChar = key;
            }
        }
    }
    
    return curChar;
}
