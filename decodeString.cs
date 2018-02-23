// Given an encoded string, return its corresponding decoded string.

// The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is repeated exactly k times. Note: k is guaranteed to be a positive integer.

// Note that your solution should have linear complexity because this is what you will be asked during an interview.

// Example

// For s = "4[ab]", the output should be

// decodeString(s) = "abababab";

// For s = "2[b3[a]]", the output should be

// decodeString(s) = "baaabaaa";

// For s = "z1[y]zzz2[abc]", the output should be

// decodeString(s) = "zyzzzabcabc".

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] string s

// A string encoded as described above. It is guaranteed that:

// the string consists only of digits, square brackets and lowercase English letters;
// the square brackets form a regular bracket sequence;
// all digits that appear in the string represent the number of times the content in the brackets that follow them repeats, i.e. k in the description above;
// there are at most 20 pairs of square brackets in the given string.
// Guaranteed constraints:

// 0 ≤ s.length ≤ 80.

// [output] string

char[] numbers = "0123456789".ToCharArray();

string decodeString(string s) {
    if (s == null) return null;
    
    // lets keep a Stack of StringBuilders to keep track of where we are writing
    Stack<StringBuilder> builders = new Stack<StringBuilder>();
    // and a stack of numbers to keep track of how many of each stringBuilder to write
    Stack<int> numbers = new Stack<int>();
    
    StringBuilder sb = new StringBuilder();
    int repeat = 0;
    
    for (int i = 0; i < s.Length; i++) {
        char c = s[i];
        if (c >= '0' && c <= '9') {
            // This is a value of how many times to repeat the following string
            repeat = (repeat * 10) + int.Parse(c.ToString());
        } else if (c == '[') {
            // start bracket. So start of a new string. Push the existing StringBuilder and repeat value
            builders.Push(sb);
            numbers.Push(repeat);
            sb = new StringBuilder();
            repeat = 0;
        } else if (c == ']') {
            // end of a block. Pop the last stringBuilder and repeat value and
            // use those to build the string
            StringBuilder temp = sb;
            sb = builders.Pop();
            repeat = numbers.Pop();
            for (int x = 0; x < repeat; x++) sb.Append(temp);
            repeat = 0;
        } else {
            // normal char, append it to the stringBuilder
            sb.Append(c);
        }
    }
    
    return sb.ToString();
}
