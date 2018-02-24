// Given two binary trees t1 and t2, determine whether the second tree is a subtree of the first tree. A subtree for vertex v in a binary tree t is a tree consisting of v and all its descendants in t. Determine whether or not there is a vertex v (possibly none) in tree t1 such that a subtree for vertex v (possibly empty) in t1 equals t2.

// Example

// For

// t1 = {
//     "value": 5,
//     "left": {
//         "value": 10,
//         "left": {
//             "value": 4,
//             "left": {
//                 "value": 1,
//                 "left": null,
//                 "right": null
//             },
//             "right": {
//                 "value": 2,
//                 "left": null,
//                 "right": null
//             }
//         },
//         "right": {
//             "value": 6,
//             "left": null,
//             "right": {
//                 "value": -1,
//                 "left": null,
//                 "right": null
//             }
//         }
//     },
//     "right": {
//         "value": 7,
//         "left": null,
//         "right": null
//     }
// }
// and

// t2 = {
//     "value": 10,
//     "left": {
//         "value": 4,
//         "left": {
//             "value": 1,
//             "left": null,
//             "right": null
//         },
//         "right": {
//             "value": 2,
//             "left": null,
//             "right": null
//         }
//     },
//     "right": {
//         "value": 6,
//         "left": null,
//         "right": {
//             "value": -1,
//             "left": null,
//             "right": null
//         }
//     }
// }
// the output should be isSubtree(t1, t2) = true.

// This is what these trees look like:

//       t1:             t2:
//        5              10
//       / \            /  \
//     10   7          4    6
//    /  \            / \    \
//   4    6          1   2   -1
//  / \    \
// 1   2   -1
// As you can see, t2 is a subtree of t1 (the vertex in t1 with value 10).

// For

// t1 = {
//     "value": 5,
//     "left": {
//         "value": 10,
//         "left": {
//             "value": 4,
//             "left": {
//                 "value": 1,
//                 "left": null,
//                 "right": null
//             },
//             "right": {
//                 "value": 2,
//                 "left": null,
//                 "right": null
//             }
//         },
//         "right": {
//             "value": 6,
//             "left": {
//                 "value": -1,
//                 "left": null,
//                 "right": null
//             },
//             "right": null
//         }
//     },
//     "right": {
//         "value": 7,
//         "left": null,
//         "right": null
//     }
// }
// and

// t2 = {
//     "value": 10,
//     "left": {
//         "value": 4,
//         "left": {
//             "value": 1,
//             "left": null,
//             "right": null
//         },
//         "right": {
//             "value": 2,
//             "left": null,
//             "right": null
//         }
//     },
//     "right": {
//         "value": 6,
//         "left": null,
//         "right": {
//             "value": -1,
//             "left": null,
//             "right": null
//         }
//     }
// }
// the output should be isSubtree(t1, t2) = false.

// This is what these trees look like:

//         t1:            t2:
//          5             10
//        /   \          /  \
//      10     7        4    6
//    /    \           / \    \
//   4     6          1   2   -1
//  / \   / 
// 1   2 -1
// As you can see, there is no vertex v such that the subtree of t1 for vertex v equals t2.

// For

// t1 = {
//     "value": 1,
//     "left": {
//         "value": 2,
//         "left": null,
//         "right": null
//     },
//     "right": {
//         "value": 2,
//         "left": null,
//         "right": null
//     }
// }
// and

// t2 = {
//     "value": 2,
//     "left": {
//         "value": 1,
//         "left": null,
//         "right": null
//     },
//     "right": null
// }
// the output should be isSubtree(t1, t2) = false.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] tree.integer t1

// A binary tree of integers.

// Guaranteed constraints:
// 0 ≤ tree size ≤ 6 · 104,
// -1000 ≤ node value ≤ 1000.

// [input] tree.integer t2

// Another binary tree of integers.

// Guaranteed constraints:
// 0 ≤ tree size ≤ 6 · 104,
// -1000 ≤ node value ≤ 1000.

// [output] boolean

// Return true if t2 is a subtree of t1, otherwise return false.

//
// Definition for binary tree:
// class Tree<T> {
//   public T value { get; set; }
//   public Tree<T> left { get; set; }
//   public Tree<T> right { get; set; }
// }
bool isSubtree(Tree<int> t1, Tree<int> t2) {
    // if one of the trees is null, the only way it can return true is
    // if the other tree is null as well.
    if (t1 == null) return t2 == null;
    
    // A null tree can technically be a subtree of a non-null tree in this test
    if (t2 == null) return true;
    
    // create a list to hold all possible subtrees
    List<Tree<int>> possibleSubtrees = new List<Tree<int>>();
    // and populate it with all potential matches
    findPotentialMatches(t1, t2.value, possibleSubtrees);
    
    // then iterate through all the possible matches to see if
    // any are infact a matching subtree
    foreach(Tree<int> current in possibleSubtrees) {
        if (compareSubtrees(current, t2))
            return true;
    }
    
    return false;
}

void findPotentialMatches(Tree<int> t1, int value, List<Tree<int>> possibleSubtrees) {
    // to simplify our match, we simply look for nodes where the
    // value is equal to the root node of our subtree
    if (t1.value == value) {
        possibleSubtrees.Add(t1);
    }
    
    // then we recursively build our list from our left and right nodes
    if (t1.left != null) findPotentialMatches(t1.left, value, possibleSubtrees);
    if (t1.right != null) findPotentialMatches(t1.right, value, possibleSubtrees);
}

bool compareSubtrees(Tree<int> t1, Tree<int> t2) {
    if (t1 == null && t2 == null) return true;
    if (t1 == null ^ t2 == null) return false; // finally get to use xor!
    
    return t1.value == t2.value && compareSubtrees(t1.left, t2.left) && compareSubtrees(t1.right, t2.right);
}
