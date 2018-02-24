// You have two arrays of strings, words and parts. Return an array that contains the strings from words, modified so that any occurrences of the substrings from parts are surrounded by square brackets [], following these guidelines:

// If several parts substrings occur in one string in words, choose the longest one. If there is still more than one such part, then choose the one that appears first in the string.

// Example

// For words = ["Apple", "Melon", "Orange", "Watermelon"] and parts = ["a", "mel", "lon", "el", "An"], the output should be
// findSubstrings(words, parts) = ["Apple", "Me[lon]", "Or[a]nge", "Water[mel]on"].

// While "Watermelon" contains three substrings from the parts array, "a", "mel", and "lon", "mel" is the longest substring that appears first in the string.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.string words

// An array of strings consisting only of uppercase and lowercase English letters.

// Guaranteed constraints:
// 0 ≤ words.length ≤ 104,
// 1 ≤ words[i].length ≤ 30.

// [input] array.string parts

// An array of strings consisting only of uppercase and lower English letters. Each string is no more than 5 characters in length.

// Guaranteed constraints:
// 0 ≤ parts.length ≤ 105,
// 1 ≤ parts[i].length ≤ 5,
// parts[i] ≠ parts[j].

// [output] array.string

string[] findSubstrings(string[] words, string[] parts) {
    // Create a new Trie to store the parts to find
    TrieNode root = new TrieNode();
    foreach(string part in parts) AddFragment(root, part);
    
    // iterate through the words and find the longest match 
    // using the trie
    for(int i = 0; i < words.Length; i++) {
        words[i] = findLongest(words[i], root);
    }
    return words;
}

string findLongest(string word, TrieNode root) {
    int longestLength = 0;
    int longestIndex = 0;
    
    // iterate through all the characters in the word, looking for matches
    // inside the Trie
    for (int startIndex = 0; startIndex < word.Length; startIndex++) {
        TrieNode current = root;
        
        for (int i = startIndex; i < word.Length; i++) {
            Char letter = word[i];
            TrieNode c = current.Get(letter);
            if (c == null) {
                // we didnt find a match, so increment the startIndex
                break;
            }
            
            // we found a match, so we can increase the length
            current = c;
            int length = i - startIndex + 1;
            // if we are at a terminal node, we can now compare lengths
            // if the current length > longestLength, we need to update
            // the longestLength and longestIndex variables
            if (current.Terminal && length > longestLength) {
                longestLength = length;
                longestIndex = startIndex;
            }
        }
    }
    
    if (longestLength == 0) return word;
    return word.Substring(0, longestIndex) + "[" + word.Substring(longestIndex, longestLength) + "]" + word.Substring(longestIndex + longestLength);
}

void AddFragment(TrieNode root, string fragment) {
    TrieNode node = root;
    foreach(Char letter in fragment) {
        node = node.GetOrAdd(letter);
    }
    node.Terminal = true;
}

class TrieNode {
    public Char Letter { get; set; }
    public bool Terminal { get; set; }
    
    public List<TrieNode> Children { get; set; }
    
    public TrieNode() {
        Children = new List<TrieNode>();
    }
    
    public TrieNode(Char letter) {
        this.Letter = letter;
        Children = new List<TrieNode>();
    }
    
    public TrieNode GetOrAdd(Char letter) {
        TrieNode node = Get(letter);
        if (node == null) {
            node = new TrieNode(letter);
            this.Children.Add(node);
        }
        return node;
    }
    
    public TrieNode Get(Char letter) {
        foreach (TrieNode t in Children) {
            if (t.Letter.Equals(letter)) return t;
        }
        return null;
    }
}
