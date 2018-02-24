// Avoid using built-in functions to solve this challenge. Implement them yourself, since this is what you would be asked to do during a real interview.

// Implement a function that takes two strings, s and x, as arguments and finds the first occurrence of the string x in s. The function should return an integer indicating the index in s of the first occurrence of x. If there are no occurrences of x in s, return -1.

// Example

// For s = "CodefightsIsAwesome" and x = "IA", the output should be
// strstr(s, x) = -1;
// For s = "CodefightsIsAwesome" and x = "IsA", the output should be
// strstr(s, x) = 10.
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] string s

// A string containing only uppercase or lowercase English letters.

// Guaranteed constraints:
// 1 ≤ s.length ≤ 106.

// [input] string x

// String, containing only uppercase or lowercase English letters.

// Guaranteed constraints:
// 1 ≤ x.length ≤ 106.

// [output] integer

// An integer indicating the index of the first occurrence of the string x in s, or -1 if s does not contain x.

// [C#] Syntax Tips

int findFirstSubstringOccurrence(string s, string x) {
    int y = 0;
    int i = 2;
    int count = 0;
    
    int[] ax = new int[s.Length];
    ax[0] = -1;
    
    while (i < x.Length) 
    { 
        if (x[i - 1] == x[count]) 
        { 
            ++count; 
            ax[i] = count; 
            ++i; 
        } else if (count > 0) {
            count = ax[count];
        } else {
            ax[i] = 0;
            ++i;
        }
    }
    
    i = 0;
    
    while (y + i < s.Length) {
        if (x[i] == s[y + i]) {
            if (i == x.Length - 1) {
                return y;
            }
            ++i;
        } else {
            y = y + i - ax[i];
            if (ax[i] > -1){
                i = ax[i];
            }
            else {
                i = 0;
            }
        }
    }
    return -1;
}

