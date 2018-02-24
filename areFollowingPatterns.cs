// Given an array strings, determine whether it follows the sequence given in the patterns array. In other words, there should be no i and j for which strings[i] = strings[j] and patterns[i] ≠ patterns[j] or for which strings[i] ≠ strings[j] and patterns[i] = patterns[j].

// Example

// For strings = ["cat", "dog", "dog"] and patterns = ["a", "b", "b"], the output should be
// areFollowingPatterns(strings, patterns) = true;
// For strings = ["cat", "dog", "doggy"] and patterns = ["a", "b", "b"], the output should be
// areFollowingPatterns(strings, patterns) = false.
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.string strings

// An array of strings, each containing only lowercase English letters.

// Guaranteed constraints:
// 1 ≤ strings.length ≤ 105,
// 1 ≤ strings[i].length ≤ 10.

// [input] array.string patterns

// An array of pattern strings, each containing only lowercase English letters.

// Guaranteed constraints:
// patterns.length = strings.length,
// 1 ≤ patterns[i].length ≤ 10.

// [output] boolean

// Return true if strings follows patterns and false otherwise.

bool areFollowingPatterns(string[] strings, string[] patterns) {
    if (strings == null || patterns == null) return false;
    if (strings.Length != patterns.Length) return false;
    
    // Create Maps to group indicies for each pattern and string
    Dictionary<String, List<int>> patternIndicies = new Dictionary<String, List<int>>();
    Dictionary<String, List<int>> stringIndicies = new Dictionary<String, List<int>>();
    
    // Build out the index map for the patterns
    for (int i = 0; i < patterns.Length; i++) {
        if (!patternIndicies.ContainsKey(patterns[i])) patternIndicies.Add(patterns[i], new List<int>());
        patternIndicies[patterns[i]].Add(i);
    }
    
    // Build out the index map for the strings
    for (int i = 0; i < strings.Length; i++) {
        if (!stringIndicies.ContainsKey(strings[i])) stringIndicies.Add(strings[i], new List<int>());
        stringIndicies[strings[i]].Add(i);
    }
    
    String[] patternKeys = patternIndicies.Keys.ToArray();
    String[] stringKeys = stringIndicies.Keys.ToArray();
    
    // if the number of unique patterns != number of unique strings, return false
    if (patternKeys.Length != stringKeys.Length) return false;
    
    for (int i = 0; i < patternKeys.Length; i++) {
        // iterate through the maps to ensure the indexes are equal for each string/pattern combo
        if (!arrayValuesEqual(patternIndicies[patternKeys[i]], stringIndicies[stringKeys[i]])) {
            return false;
        }
    }
    
    return true;
}

bool arrayValuesEqual(List<int> a1, List<int> a2) {
    // both maps must contain the same number of indexes
    if (a1.Count != a2.Count) return false;
    
    // and each set of indexes must be the same.
    for (int i = 0; i < a1.Count; i++) {
        Console.WriteLine("a1: " + a1[i] + ", a2: " + a2[i]);
        if (!a1[i].Equals(a2[i])) return false;
    }
    return true;
}
