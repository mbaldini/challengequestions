// Note: Try to solve this task in O(n) time using O(1) additional space, where n is the number of elements in the list, since this is what you'll be asked to do during an interview.

// Given a singly linked list of integers l and an integer k, remove all elements from list l that have a value equal to k.

// Example

// For l = [3, 1, 2, 3, 4, 5] and k = 3, the output should be
// removeKFromList(l, k) = [1, 2, 4, 5];
// For l = [1, 2, 3, 4, 5, 6, 7] and k = 10, the output should be
// removeKFromList(l, k) = [1, 2, 3, 4, 5, 6, 7].
// Input/Output

// [execution time limit] 3 seconds (java)

// [input] linkedlist.integer l

// A singly linked list of integers.

// Guaranteed constraints:
// 0 ≤ list size ≤ 105,
// -1000 ≤ element value ≤ 1000.

// [input] integer k

// An integer.

// Guaranteed constraints:
// -1000 ≤ k ≤ 1000.

// [output] linkedlist.integer

// Return l with all the values equal to k removed.

// Definition for singly-linked list:
// class ListNode<T> {
//   public T value { get; set; }
//   public ListNode<T> next { get; set; }
// }
//
ListNode<int> removeKFromList(ListNode<int> l, int k) {
    if (l == null) {
        return null;
    }
    
    ListNode<int> firstNode = null;
    ListNode<int> currentNode = null;
    ListNode<int> lastNode = null;
    
    ListNode<int> current = l;
    
    // iterate through the list, searching for the value k
    while (true) {
        if (current.value != k) {
            // since this node isnt k, set our variables and proceed on
            // set currentNode
            currentNode = current;
            // the set the previous nodes next = this node
            if (lastNode != null) lastNode.next = currentNode;
            // set lastNode to this current node
            lastNode = currentNode;
            // set the first node if it hasnt been set
            if (firstNode == null) firstNode = currentNode;
        }
        
        // when we hit the end, bail out.
        if (current.next == null) break;
        ListNode<int> next = current.next;
        current.next = null;
        current = next;
    }
    
    return firstNode;
}
