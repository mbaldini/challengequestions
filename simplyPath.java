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

String simplifyPath(String path) {
    // break apart all of the paths into its parts.
    String[] parts = path.split("/");
    
    Stack<String> finalParts = new Stack<String>();
    
    // iterate through the parts of the string
    for(String part : parts) {
        // skip empty elements from '//' in the path
        if (part.equals("")) continue;
        
        if (part.equals("..")) {
            // back up a directory, so simply pop the top one off the stack
            if (!finalParts.empty()) {
                finalParts.pop();
            }
        } else if (part.equals(".")) {
            // do nothing, stay in the same directory
        } else {
            // this is a child directory, so push it onto the stack
            finalParts.push(part);
        }
    }
    
    // Now we reassemble the string. Simply pop all the directories off
    // the stack and prepend them to the reassembled string, joined with 
    // the proper Unix directory separator
    String reassembed = "";
    while(!finalParts.empty()) {
        reassembed = "/" + finalParts.pop() + reassembed;
    }
    
    // Ensure that we return at least the root directory (if path was originally "")
    if (reassembed.equals("")) reassembed = "/";
    
    return reassembed;
}
