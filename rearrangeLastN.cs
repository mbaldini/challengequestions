// Note: Try to solve this task in O(list size) time using O(1) additional space, since this is what you'll be asked during an interview.

// Given a singly linked list of integers l and a non-negative integer n, move the last n list nodes to the beginning of the linked list.

// Example

// For l = [1, 2, 3, 4, 5] and n = 3, the output should be
// rearrangeLastN(l, n) = [3, 4, 5, 1, 2];
// For l = [1, 2, 3, 4, 5, 6, 7] and n = 1, the output should be
// rearrangeLastN(l, n) = [7, 1, 2, 3, 4, 5, 6].
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] linkedlist.integer l

// A singly linked list of integers.

// Guaranteed constraints:
// 0 ≤ list size ≤ 105,
// -1000 ≤ element value ≤ 1000.

// [input] integer n

// A non-negative integer.

// Guaranteed constraints:
// 0 ≤ n ≤ list size.

// [output] linkedlist.integer

// Return l with the n last elements moved to the beginning.

// Definition for singly-linked list:
// class ListNode<T> {
//   public T value { get; set; }
//   public ListNode<T> next { get; set; }
// }
//
ListNode<int> rearrangeLastN(ListNode<int> l, int n) {
    if (l == null || l.next == null || n == 0) return l;
    // setup a temporary pointer
    ListNode<int> temp = l;
    
    // figure out the total length of the array
    int length = 1;
    while (temp.next != null) { temp = temp.next; length++; }
    
    // create a ring to point back at the beginning
    temp.next = l;
    
    // calculate number of items to skip to create new start
    n = n % length;
    
    for (int i = 0; i < length - n; i++) {
        temp = temp.next;
    }
    
    // setup new start node
    l = temp.next;
    // null out pointer to new start node
    temp.next = null;
    
    return l;
}
