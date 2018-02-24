We're going to store numbers in a tree. Each node in this tree will store a single digit (from 0 to 9), and each path from root to leaf encodes a non-negative integer.

Given a binary tree t, find the sum of all the numbers encoded in it.

Example

For
t = {
    "value": 1,
    "left": {
        "value": 0,
        "left": {
            "value": 3,
            "left": null,
            "right": null
        },
        "right": {
            "value": 1,
            "left": null,
            "right": null
        }
    },
    "right": {
        "value": 4,
        "left": null,
        "right": null
    }
}
the output should be
digitTreeSum(t) = 218.
There are 3 numbers encoded in this tree:

Path 1->0->3 encodes 103
Path 1->0->1 encodes 101
Path 1->4 encodes 14
and their sum is 103 + 101 + 14 = 218.
t = {
    "value": 0,
    "left": {
        "value": 9,
        "left": null,
        "right": null
    },
    "right": {
        "value": 9,
        "left": {
            "value": 1,
            "left": null,
            "right": null
        },
        "right": {
            "value": 3,
            "left": null,
            "right": null
        }
    }
}
the output should be
digitTreeSum(t) = 193.
Because 09 + 091 + 093 = 193

Input/Output

[execution time limit] 3 seconds (cs)

[input] tree.integer t

A tree of integers. It's guaranteed that the sum of encoded integers won't exceed 252.

Guaranteed constraints:
1 ≤ tree size ≤ 2000,
1 ≤ tree depth ≤ 9,
0 ≤ node value ≤ 9.

[output] integer64

The sum of the integers encoded in t, as described above.

//
// Definition for binary tree:
// class Tree<T> {
//   public T value { get; set; }
//   public Tree<T> left { get; set; }
//   public Tree<T> right { get; set; }
// }
long digitTreeSum(Tree<int> t) {
    if (t == null) return 0;
    
    // create a cache to hold the digits in the tree
    List<long> treeValues = new List<long>();
    
    // evaluate the tree nodes to populate the cache
    evalTree(t, treeValues, 0);
    long sum = 0;
    
    // iterate through all the values and calculate the sum
    foreach(long v in treeValues) {
        sum += v;
    }
    return sum;
}

private void evalTree(Tree<int> t, List<long> values, long prefix) {
    long newPrefix = (10 * prefix) + t.value;
    
    if (t.left == null && t.right == null) {
        values.Add(newPrefix);
    } else {
        if (t.left != null) evalTree(t.left, values, newPrefix);
        if (t.right != null) evalTree(t.right, values, newPrefix);
    }
}
