// Note: Your solution should have O(n) time complexity, where n is the number of element in l, and O(1) additional space complexity, since this is what you would be asked to accomplish in an interview.

// Given a linked list l, reverse its nodes k at a time and return the modified list. k is a positive integer that is less than or equal to the length of l. If the number of nodes in the linked list is not a multiple of k, then the nodes that are left out at the end should remain as-is.

// You may not alter the values in the nodes - only the nodes themselves can be changed.

// Example

// For l = [1, 2, 3, 4, 5] and k = 2, the output should be
// reverseNodesInKGroups(l, k) = [2, 1, 4, 3, 5];
// For l = [1, 2, 3, 4, 5] and k = 1, the output should be
// reverseNodesInKGroups(l, k) = [1, 2, 3, 4, 5];
// For l = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] and k = 3, the output should be
// reverseNodesInKGroups(l, k) = [3, 2, 1, 6, 5, 4, 9, 8, 7, 10, 11].
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] linkedlist.integer l

// A singly linked list of integers.

// Guaranteed constraints:
// 1 ≤ list size ≤ 104,
// -109 ≤ element value ≤ 109.

// [input] integer k

// The size of the groups of nodes that need to be reversed.

// Guaranteed constraints:
// 1 ≤ k ≤ l size.

// [output] linkedlist.integer

// The initial list, with reversed groups of k elements.

// Definition for singly-linked list:
// class ListNode<T> {
//   public T value { get; set; }
//   public ListNode<T> next { get; set; }
// }
//
ListNode<int> reverseNodesInKGroups(ListNode<int> l, int k) {
    if (l == null || l.next == null || k == 1) return l;
    
    // create a new root
    ListNode<int> list = new ListNode<int>() { value = 0 };
    list.next = l;
    ListNode<int> startNode = list;
    int i = 0;
    
    // iterate through the nodes
    while (l != null) {
        i++;
        // reverse the nodes if we meet the requirements
        if (i % k == 0) {
            startNode = reverse(startNode, l.next);
            l = startNode.next;
        } else {
            l = l.next;
        }
    }
    return list.next;
}

ListNode<int> reverse(ListNode<int> start, ListNode<int> end) {
    ListNode<int> previous = end;
    ListNode<int> nextStart = start.next;
    ListNode<int> current = start.next;
    
    // basic linkedlist reversal algo
    while (current != end) {
        ListNode<int> x  = current.next;
        current.next = previous;
        previous = current;
        current = x;
    }
    start.next = previous;
    return nextStart;
}
