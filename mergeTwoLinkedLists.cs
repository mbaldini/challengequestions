// Note: Your solution should have O(l1.length + l2.length) time complexity, since this is what you will be asked to accomplish in an interview.

// Given two singly linked lists sorted in non-decreasing order, your task is to merge them. In other words, return a singly linked list, also sorted in non-decreasing order, that contains the elements from both original lists.

// Example

// For l1 = [1, 2, 3] and l2 = [4, 5, 6], the output should be
// mergeTwoLinkedLists(l1, l2) = [1, 2, 3, 4, 5, 6];
// For l1 = [1, 1, 2, 4] and l2 = [0, 3, 5], the output should be
// mergeTwoLinkedLists(l1, l2) = [0, 1, 1, 2, 3, 4, 5].
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] linkedlist.integer l1

// A singly linked list of integers.

// Guaranteed constraints:
// 0 ≤ list size ≤ 104,
// -109 ≤ element value ≤ 109.

// [input] linkedlist.integer l2

// A singly linked list of integers.

// Guaranteed constraints:
// 0 ≤ list size ≤ 104,
// -109 ≤ element value ≤ 109.

// [output] linkedlist.integer

// A list that contains elements from both l1 and l2, sorted in non-decreasing order.


// Definition for singly-linked list:
// class ListNode<T> {
//   public T value { get; set; }
//   public ListNode<T> next { get; set; }
// }
//
ListNode<int> mergeTwoLinkedLists(ListNode<int> l1, ListNode<int> l2) {
    if (l1 == null) return l2;
    if (l2 == null) return l1;
    
    if (l1.value < l2.value) {
        return mergeNodes(l1, l2);
    } else {
        return mergeNodes(l2, l1);
    }
}

ListNode<int> mergeNodes(ListNode<int> smaller, ListNode<int> larger) {
    if (smaller.next == null) {
        smaller.next = larger;
    } else {
        if (smaller.next.value < larger.value) {
            smaller.next = mergeNodes(smaller.next, larger);
        } else {
            smaller.next = mergeNodes(larger, smaller.next);
        }
    }
    return smaller;
}
