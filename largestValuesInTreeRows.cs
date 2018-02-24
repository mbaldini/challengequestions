// You have a binary tree t. Your task is to find the largest value in each row of this tree. In a tree, a row is a set of nodes that have equal depth. For example, a row with depth 0 is a tree root, a row with depth 1 is composed of the root's children, etc.

// Return an array in which the first element is the largest value in the row with depth 0, the second element is the largest value in the row with depth 1, the third element is the largest element in the row with depth 2, etc.

// Example

// For

// t = {
//     "value": -1,
//     "left": {
//         "value": 5,
//         "left": null,
//         "right": null
//     },
//     "right": {
//         "value": 7,
//         "left": null,
//         "right": {
//             "value": 1,
//             "left": null,
//             "right": null
//         }
//     }
// }
// the output should be largestValuesInTreeRows(t) = [-1, 7, 1].

// The tree in the example looks like this:

//     -1
//    / \
//   5   7
//        \
//         1
// In the row with depth 0, there is only one vertex - the root with value -1;
// In the row with depth 1, there are two vertices with values 5 and 7, so the largest value here is 7;
// In the row with depth 2, there is only one vertex with value 1.
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] tree.integer t

// A binary tree of integers.

// Guaranteed constraints:
// 0 ≤ tree size ≤ 5 · 104,
// -1000 ≤ node value ≤ 1000.

// [output] array.integer

// An array of the largest values in each row of t.

//
// Definition for binary tree:
// class Tree<T> {
//   public T value { get; set; }
//   public Tree<T> left { get; set; }
//   public Tree<T> right { get; set; }
// }
int[] largestValuesInTreeRows(Tree<int> t) {
    if (t == null) return new int[0];
    
    // Create a Map to cache the largest value at any given depth
    Dictionary<int, int> cache = new Dictionary<int, int>();
    
    // evaluate the nodes to populate the cache and find max depth
    int depth = evalNode(t, cache, 1);
    
    List<int> values = new List<int>();
    // iterate through each depth and find the largest value
    for (int i = 1; i <= depth; i++) {
        values.Add(cache[i]);
    }
    return values.ToArray();
}

int evalNode(Tree<int> t, Dictionary<int, int> cache, int depth) {
    // populate the cache with this node's depth
    if (!cache.ContainsKey(depth)) cache.Add(depth, int.MinValue);
    
    // if this node's value > current depth, update the cache
    if (cache[depth] < t.value) cache[depth] = t.value;
    
    int currentDepth = depth + 1;
    int maxDepth = depth;
    // recursively evaluate the left & right child nodes
    if (t.left != null) {
        maxDepth = Math.Max(maxDepth, evalNode(t.left, cache, currentDepth));
    }
    if (t.right != null) {
        maxDepth = Math.Max(maxDepth, evalNode(t.right, cache, currentDepth));
    }
    
    // return the max depth reached
    return maxDepth;
}
