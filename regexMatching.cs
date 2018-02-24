// Given a pattern string and a test string, your task is to implement regex substring matching. If pattern is preceded by a ^, the pattern, excluding the ^, will be matched with the starting position of the test string. If pattern is followed by a $, the pattern, excluding the $, will be matched with the ending position of the test string. If no such markers are present, check whether pattern is a substring of test, regardless of its position.

// Example

// For pattern = "^code" and test = "codefights", the output should be
// regexMatching(pattern, test) = true;
// For pattern = "hts$" and test = "codefights", the output should be
// regexMatching(pattern, test) = true;
// For pattern = "hello" and test = "world", the output should be
// regexMatching(pattern, test) = false.
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] string pattern

// A string that can contain lowercase English characters, ^, or $.

// Guaranteed constraints:
// 1 ≤ pattern.length ≤ 105.

// [input] string test

// A string composed of lowercase English characters.

// Guaranteed constraints:
// 1 ≤ test.length ≤ 105.

// [output] boolean

// Return true if the test string matches the given pattern, otherwise return false.

bool regexMatching(string pattern, string test) {
    // First, lets see if this is a pattern that requires that we have a
    // line start and/or end.
    bool startsWith = pattern[0] == '^';
    bool endsWith = pattern[pattern.Length -1] == '$';
    
    // If we require the start or end pattern, we can remove those characters
    // from the string, leaving only the text pattern.
    if (startsWith) pattern = pattern.Substring(1);
    if (endsWith) pattern = pattern.Substring(0, pattern.Length -1);
    
    // The pattern can't match if it is longer than the test string.
    if (pattern.Length > test.Length) return false;
    
    // If the pattern has both a start and end line requirement, then
    // we need to only do a simple equality comparison.
    if (startsWith && endsWith) return pattern == test;
    
    if (startsWith) {
        // If the pattern requires a line start, we can do a simple 
        // startsWith comparison and compare a substring starting
        // at index 0, going until pattern.Length
        return test.Substring(0, pattern.Length) == pattern;
    } else if (endsWith) {
        // If the pattern requires a line end, we can do a simple 
        // endsWith comparison and compare a substring starting
        // at index test.Length - pattern.Length, going until pattern.Length
        return test.Substring(test.Length - pattern.Length) == pattern;
    } else {
        // Since this requires neither start nor end line, we need to use
        // KMP to quickly search this string.
        return kmp(test, pattern);
    }
}

bool kmp(string test, string pattern) {
    int y = 0;
    int i = 2;
    int count = 0;
    
    int[] ax = new int[test.Length];
    ax[0] = -1;
    
    while (i < pattern.Length) 
    { 
        if (pattern[i - 1] == pattern[count]) 
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
    
    while (y + i < test.Length) {
        if (pattern[i] == test[y + i]) {
            if (i == pattern.Length - 1) {
                return true;
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
    return false;
}
