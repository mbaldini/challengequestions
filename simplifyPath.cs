// Given an absolute file path (Unix-style), shorten it to the format /<dir1>/<dir2>/<dir3>/....

// Here is some info on Unix file system paths:

// / is the root directory; the path should always start with it even if it isn't there in the given path;
// / is also used as a directory separator; for example, /code/fights denotes a fights subfolder in the code folder in the root directory;
// this also means that // stands for "change the current directory to the current directory"
// . is used to mark the current directory;
// .. is used to mark the parent directory; if the current directory is root already, .. does nothing.
// Example

// For path = "/home/a/./x/../b//c/", the output should be
// simplifyPath(path) = "/home/a/b/c".

// Here is how this path was simplified:
// * /./ means "move to the current directory" and can be replaced with a single /;
// * /x/../ means "move into directory x and then return back to the parent directory", so it can replaced with a single /;
// * // means "move to the current directory" and can be replaced with a single /.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] string path

// A line containing a path presented in Unix style format. All directories in the path are guaranteed to consist only of English letters.

// Guaranteed constraints:
// 1 ≤ path.length ≤ 5 · 104.

// [output] string

// The simplified path.

string simplifyPath(string path) {
    // break apart all of the paths into its parts.
    // This will also address all '//' characters.
    string[] parts = path.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToArray();
    
    Stack<string> finalParts = new Stack<string>();
    
    // iterate through the parts of the string
    foreach(string part in parts) {
        if (part == "..") {
            // back up a directory, so simply pop the top one off the stack
            if (finalParts.Count > 0) {
                finalParts.Pop();
            }
        } else if (part == ".") {
            // do nothing, stay in the same directory
        } else {
            // this is a child directory, so push it onto the stack
            finalParts.Push(part);
        }
    }
    
    // Now we reassemble the string. Simply pop all the directories off
    // the stack and prepend them to the reassembled string, joined with 
    // the proper Unix directory separator
    string reassembed = "";
    while(finalParts.Count > 0) {
        reassembed = "/" + finalParts.Pop() + reassembed;
    }
    
    // Ensure that we return at least the root directory (if path was originally "")
    if (String.IsNullOrEmpty(reassembed)) reassembed = "/";
    
    return reassembed;
}
