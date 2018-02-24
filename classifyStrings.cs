// You categorize strings into three types: good, bad, or mixed. If a string has 3 consecutive vowels or 5 consecutive consonants, or both, then it is categorized as bad. Otherwise it is categorized as good. Vowels in the English alphabet are ["a", "e", "i", "o", "u"] and all other letters are consonants.

// The string can also contain the character ?, which can be replaced by either a vowel or a consonant. This means that the string "?aa" can be bad if ? is a vowel or good if it is a consonant. This kind of string is categorized as mixed.

// Implement a function that takes a string s and returns its category: good, bad, or mixed.

// Example

// For s = "aeu", the output should be
// classifyStrings(s) = "bad";

// For s = "a?u", the output should be
// classifyStrings(s) = "mixed";

// For s = "aba", the output should be
// classifyStrings(s) = "good".

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] string s

// A string that can contain only lowercase English letters and the character ?.

// Guaranteed constraints:
// 1 ≤ s.length ≤ 50.

// [output] string

// good, bad or mixed.

string classifyStrings(string s) {
    // define what our vowels are
    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
    
    char[] tmp = s.ToCharArray();
    s = "";
    
    // iterate through the string and determine if each char is
    // a vowel, constanant, or wildcard. Replace vowels and 
    // constanants with known characters to simplify processing
    // in our next step
    foreach(char c in tmp) {
        if (c == '?') {
            s += c;
        } else if (vowels.Contains(c)) {
            s += 'v';
        } else {
            s += 'c';
        }
    }
    
    // create a list of all permutations of the string
    List<string> mutated = mutate(s);
    string current = "";
    
    // variables to hold how many good/bad strings were generated
    int goodCount = 0;
    int badCount = 0;
    
    // iterate through all of the permutations
    foreach(string word in mutated) {
        // look for 3 vowels or 5 constanants, and increment badCount if there are any
        // otherwise increment goodCount
        if (word.Contains("vvv") || word.Contains("ccccc")) {
            badCount++;
        } else {
            goodCount++;
        }
    }
    
    // if there are both bad and good strings, then it is classified as 'mixed'.
    // If there are only bad strings, then it is classified as 'bad'.
    // If there are only good strings, then it is classified as 'good'.
    if (badCount > 0 && goodCount > 0) {
        return "mixed";
    } else if (badCount > 0) {
        return "bad";
    }
    return "good";
}

List<string> mutate(string s) {
    // recursively mutate the string one wildcard at a time.
    
    // cache of words generated
    List<string> words = new List<string>();
    
    // Find the first index of a wildcard character in the string.
    int index = s.IndexOf('?');
    
    // if there are no wildcards left, simply return a list
    // containing only this string.
    if (index == -1) {
        words.Add(s);
        return words;
    }
    
    // Variables to hold the two permutations
    char[] vowels = s.ToCharArray();
    char[] cons = s.ToCharArray();
    
    // Create a permutation that replaced the wildcard with a vowel
    vowels[index] = 'v';
    // Create a permutation that replaced the wildcard with a constanant
    cons[index] = 'c';
    
    // re-evaluate the strings to generate more permutations until there are
    // no more wildcard characters left.
    words.AddRange(mutate(new string(vowels)));
    words.AddRange(mutate(new string(cons)));
    
    return words;
}
