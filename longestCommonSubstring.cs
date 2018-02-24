// Given two strings, s and t, find the length of their longest common substring.

// Example

// For s = "abcdxyz" and t = "xyzabcd", the output should be
// longestCommonSubstring(s, t) = 4;

// For s = "zxabcdezy" and t = "yzabcdezx", the output should be
// longestCommonSubstring(s, t) = 6.

// The longest common substring is "abcdez" and has a length of 6.

// Input/Output

// [execution time limit] 5 seconds (cs)

// [input] string s

// A non-empty string.

// Guaranteed constraints:
// 1 ≤ s.length ≤ 105.

// [input] string t

// A non-empty string.

// Guaranteed constraints:
// 1 ≤ t.length ≤ 105.

// [output] integer

// The length of the longest common substring of s and t.

int longestCommonSubstring(string s, string t) {
    //  Populate the Trie with the strings
    TrieNode root = new TrieNode();
    char[] str = s.ToCharArray();
    for (int i = s.Length - 1; i >= 0; i--) {
        char[] data = new char[s.Length - i];
        Array.Copy(str, i, data, 0, data.Length);
        root.Add(data);
    }
    
    int longest = 0;
    // iterate through the string
    for (int i = 0; i < t.Length; i++) {
        // Generate the sample string one character at a time
        List<char> sample = new List<char>();
        for (int j = i; j < t.Length; j++) {
            sample.Add(t[j]);
            
            // check to see if the Trie contains this sample string
            if (root.Contains(sample.ToArray())) {
                longest = Math.Max(longest, sample.Count);
            } else {
                break;
            }
        }
    }
    
    return longest;
}

class TrieNode {
    public char Letter { get; set; }
    public Dictionary<char, TrieNode> Children { get; set; }
    
    public TrieNode() {
        Children = new Dictionary<char, TrieNode>();
    }
    
    public TrieNode(char letter) : this() {
        this.Letter = letter;
    }
    
    public TrieNode Add(char[] s) {
        char c = s[0];
        TrieNode n = null;
        if (this.Children.ContainsKey(c)) {
            n = this.Children[c];
        }
        
        if (n == null) {
            n = new TrieNode(c);
            this.Children.Add(c, n);
        }
        
        if (s.Length > 1) {
            char[] str = new char[s.Length - 1];
            Array.Copy(s, 1, str, 0, str.Length);
            n.Add(str);
        }
        return n;
    }
    
    public bool Contains(char[] s) {
        char c = s[0];
        if (this.Children.ContainsKey(c)) {
            if (s.Length == 1) return true;
            char[] data = new char[s.Length - 1];
            Array.Copy(s, 1, data, 0, data.Length);
            return this.Children[c].Contains(data);
        }
        
        return false;
    }
    
    public override bool Equals(Object obj) {
        if (obj == null) return false;
        TrieNode n = (TrieNode) obj;
        return n.Letter == this.Letter;
    }
    
    public override int GetHashCode() {
        return this.Letter == null ? 0 : this.Letter.GetHashCode();
    }
}
