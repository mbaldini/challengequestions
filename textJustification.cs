// Given an array of words and a length l, format the text such that each line has exactly l characters and is fully justified on both the left and the right. Words should be packed in a greedy approach; that is, pack as many words as possible in each line. Add extra spaces when necessary so that each line has exactly l characters.

// Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right. For the last line of text and lines with one word only, the words should be left justified with no extra space inserted between them.

// Example

// For
// words = ["This", "is", "an", "example", "of", "text", "justification."]
// and l = 16, the output should be

// textJustification(words, l) = ["This    is    an",
//                                "example  of text",
//                                "justification.  "]
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.string words

// An array of words. Each word is guaranteed not to exceed l in length.

// Guaranteed constraints:
// 1 ≤ words.length ≤ 150,
// 0 ≤ words[i].length ≤ l.

// [input] integer l

// The length that all the lines in the output array should be.

// Guaranteed constraints:
// 1 ≤ l ≤ 60.

// [output] array.string

// The formatted text as an array containing lines of text, with each line having a length of l.

string[] textJustification(string[] words, int l) {
    // Cache to contain each line of text
    List<string> lines = new List<string>();
    
    // If there are no words, return a single padded string
    if (words.Length == 0) {
        lines.Add("".PadLeft(l, ' '));
        return lines.ToArray();
    }
    
    int i = 0;
    List<string> currentLine = new List<string>();
    int currentLength = 0;
    bool newLine = true;
    
    // Start processing the words into groups under the given width
    while (true) {
        if (currentLength + words[i].Length + (currentLine.Count -1) < l) {
            // the current line can be added without issue, with space left over. 
            // So we may be able to add more words.
            currentLine.Add(words[i]);
            // If this is not a new line, add an extra character to the width to
            // indicate a space before the word.
            currentLength += words[i].Length + (newLine ? 0 : 1);
            i++;
        } else if (currentLength + words[i].Length + (currentLine.Count -1) + 1 == l) {
            // the current line will be exactly the width required.
            // Add the line into the cache and reset to a new line.
            currentLine.Add(words[i]);
            lines.Add(padString(currentLine, l, i == words.Length));
            currentLine.Clear();
            currentLength = 0;
            i++;
        } else {
            // We cannot add this word to the current line. Start performing
            // the line padding to get the desired width, and reset to a new line.
            lines.Add(padString(currentLine, l, i == words.Length));
            currentLine.Clear();
            currentLength = 0;
            newLine = true;
        }
        
        if (i == words.Length) {
            // We are at the end of the word list. So lets add the current text
            // into the line cache, and break out.
            if (currentLine != null) {
                lines.Add(padString(currentLine, l, true));
            }
            break;
        }
    }
    
    return lines.ToArray();
}

string append(string s1, string s2) {
    if (s1 != "") s1 += " ";
    return s1 + s2;
}

string padString(List<string> parts, int l, bool lastLine) {
    int lineLength = 0;
    // Calculate the line length (without spaces)
    foreach (string p in parts) {
        lineLength += p.Length;
    }
    
    // Calculate the number of spaces we need to accomodate.
    int spaceCount = l - lineLength;
    
    // If this line contains only a single word, or if it is the
    // last line of the paragraph, we need to add a space between
    // each word then do a simple padRight with the remainder of
    // of the space on the line.
    if (parts.Count == 1 || lastLine) {
        string s = "";
        foreach(string p in parts) {
            s = append(s, p);
        }
        return s.PadRight(l, ' ');
    }
    
    // Now we need to actually start inserting the spaces.
    // We insert one space between each word, from left to right,
    // in order.
    for (int i = 0; i < spaceCount; i++) {
        int index = i % (parts.Count - 1);
        parts[index] = parts[index] + ' ';
    }
    
    // Build the actual string for the line.
    StringBuilder ret = new StringBuilder();
    foreach (string st in parts) {
        ret.Append(st);
    }
    
    return ret.ToString();
}
