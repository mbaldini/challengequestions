// Note: Try to solve this task without using recursion, since this is what you'll be asked to do during an interview.

// Given a binary tree of integers t, return its node values in the following format:

// The first element should be the value of the tree root;
// The next elements should be the values of the nodes at height 1 (i.e. the root children), ordered from the leftmost to the rightmost one;
// The elements after that should be the values of the nodes at height 2 (i.e. the children of the nodes at height 1) ordered in the same way;
// Etc.
// Example

// For

// t = {
//     "value": 1,
//     "left": {
//         "value": 2,
//         "left": null,
//         "right": {
//             "value": 3,
//             "left": null,
//             "right": null
//         }
//     },
//     "right": {
//         "value": 4,
//         "left": {
//             "value": 5,
//             "left": null,
//             "right": null
//         },
//         "right": null
//     }
// }
// the output should be
// traverseTree(t) = [1, 2, 4, 3, 5].

// This t looks like this:

//      1
//    /   \
//   2     4
//    \   /
//     3 5
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] tree.integer t

// Guaranteed constraints:
// 0 ≤ tree size ≤ 104.

// [output] array.integer

// An array that contains the values at t's nodes, ordered as described above.

//
// Definition for binary tree:
// class Tree<T> {
//   public T value { get; set; }
//   public Tree<T> left { get; set; }
//   public Tree<T> right { get; set; }
// }
int[] traverseTree(Tree<int> t) {
    if (t == null) return new int[0];
    
    // Map to hold the Depth of each node, and what values are at that depth
    Dictionary<int, List<int>> cache = new Dictionary<int, List<int>>();
    // traverse the tree to populate the cache and get the max depth
    int depth = traverse(t, cache, 1);
    
    List<int> values = new List<int>();
    // iterate through all the depths, adding them to the return list
    for (int i = 1; i <= depth; i++) {
        values.AddRange(cache[i]);
    }
    return values.ToArray();
}

int traverse(Tree<int> t, Dictionary<int, List<int>> cache, int depth) {
    if (!cache.ContainsKey(depth)) cache.Add(depth, new List<int>());
    cache[depth].Add(t.value);
    
    int maxDepth = depth;
    
    int currentDepth = depth + 1; 
    if (t.left != null) {
        maxDepth = Math.Max(maxDepth, traverse(t.left, cache, currentDepth));
    }
    if (t.right != null) {
        maxDepth = Math.Max(maxDepth, traverse(t.right, cache, currentDepth));
    }
    
    return maxDepth;
}
