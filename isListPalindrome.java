// Note: Try to solve this task in O(n) time using O(1) additional space, where n is the number of elements in l, since this is what you'll be asked to do during an interview.

// Given a singly linked list of integers, determine whether or not it's a palindrome.

// Example

// For l = [0, 1, 0], the output should be
// isListPalindrome(l) = true;
// For l = [1, 2, 2, 3], the output should be
// isListPalindrome(l) = false.
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] linkedlist.integer l

// A singly linked list of integers.

// Guaranteed constraints:
// 0 ≤ list size ≤ 5 · 105,
// -109 ≤ element value ≤ 109.

// [output] boolean

// Return true if l is a palindrome, otherwise return false.

// Definition for singly-linked list:
// class ListNode<T> {
//   ListNode(T x) {
//     value = x;
//   }
//   T value;
//   ListNode<T> next;
// }
//
boolean isListPalindrome(ListNode<Integer> l) {
    if (l == null) return true;
    if (l.next == null) return true;
    
    ArrayList<Integer> intList = new ArrayList<Integer>();
    while (l != null) {
        intList.add(l.value);
        l = l.next;
    }
    
    int last = intList.size() -1;
    int i = -1;
    while (i++ < last - i) {
        if (!intList.get(i).equals(intList.get(last - i))) {
            return false;
        }
    }
    return true;
}
