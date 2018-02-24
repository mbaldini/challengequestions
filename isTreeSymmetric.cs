// Given a binary tree t, determine whether it is symmetric around its center, i.e. each side mirrors the other.

// Example

// For

// t = {
//     "value": 1,
//     "left": {
//         "value": 2,
//         "left": {
//             "value": 3,
//             "left": null,
//             "right": null
//         },
//         "right": {
//             "value": 4,
//             "left": null,
//             "right": null
//         }
//     },
//     "right": {
//         "value": 2,
//         "left": {
//             "value": 4,
//             "left": null,
//             "right": null
//         },
//         "right": {
//             "value": 3,
//             "left": null,
//             "right": null
//         }
//     }
// }
// the output should be isTreeSymmetric(t) = true.

// Here's what the tree in this example looks like:

//     1
//    / \
//   2   2
//  / \ / \
// 3  4 4  3
// As you can see, it is symmetric.

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
//         "value": 2,
//         "left": null,
//         "right": {
//             "value": 3,
//             "left": null,
//             "right": null
//         }
//     }
// }
// the output should be isTreeSymmetric(t) = false.

// Here's what the tree in this example looks like:

//     1
//    / \
//   2   2
//    \   \
//    3    3
// As you can see, it is not symmetric.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] tree.integer t

// A binary tree of integers.

// Guaranteed constraints:
// 0 ≤ tree size < 5 · 104,
// -1000 ≤ node value ≤ 1000.

// [output] boolean

// Return true if t is symmetric and false otherwise.

//
// Definition for binary tree:
// class Tree<T> {
//   public T value { get; set; }
//   public Tree<T> left { get; set; }
//   public Tree<T> right { get; set; }
// }
bool isTreeSymmetric(Tree<int> t) {
    if (t == null) return true;
    
    // if one of the nodes are null, then we can easily evaluate if it is symmetric
    if (t.left == null || t.right == null) {
        return t.left == null && t.right == null;
    }
    
    List<int?> left = new List<int?>();
    List<int?> right = new List<int?>();
    left.Add(t.value);
    right.Add(t.value);
    
    // we use an inOrderTraversal algorithm to get the values
    left.AddRange(inOrderTraversal(t.left, true));
    right.AddRange(inOrderTraversal(t.right, false));
    
    // the number of nodes must be equal on both sides to be symmetric
    if (left.Count != right.Count) return false;
    
    // then both sides of the tree must have the same values in the same order
    return left.SequenceEqual(right);
}

List<int?> inOrderTraversal(Tree<int> t, bool lToR) {
    List<int?> lst = new List<int?>();
    if (t == null) {
        return lst;
    }
    lst.Add(t.value);
    // we overcome the issue with symmetric by simply looking 
    // left to right or right to left in our traversal based on 
    // which side of the tree we are looking at
    if (lToR) {
        // if left to right, then look at the left side first
        lst.Add(getNodeValue(t.left));
        lst.Add(getNodeValue(t.right));
        lst.AddRange(inOrderTraversal(t.left, lToR));
        lst.AddRange(inOrderTraversal(t.right, lToR));
    } else {
        // otherwise, look at the right first
        lst.Add(getNodeValue(t.right));
        lst.Add(getNodeValue(t.left));
        lst.AddRange(inOrderTraversal(t.right, lToR));
        lst.AddRange(inOrderTraversal(t.left, lToR));
    }
    return lst;
}

int? getNodeValue(Tree<int> node) {
    return node == null ? (int?)null : node.value;
}
