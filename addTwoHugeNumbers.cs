You're given 2 huge integers represented by linked lists. Each linked list element is a number from 0 to 9999 that represents a number with exactly 4 digits. The represented number might have leading zeros. Your task is to add up these huge integers and return the result in the same format.

Example

For a = [9876, 5432, 1999] and b = [1, 8001], the output should be
addTwoHugeNumbers(a, b) = [9876, 5434, 0].

Explanation: 987654321999 + 18001 = 987654340000.

For a = [123, 4, 5] and b = [100, 100, 100], the output should be
addTwoHugeNumbers(a, b) = [223, 104, 105].

Explanation: 12300040005 + 10001000100 = 22301040105.

Input/Output

[execution time limit] 3 seconds (cs)

[input] linkedlist.integer a

The first number, without its leading zeros.

Guaranteed constraints:
0 ≤ a size ≤ 104,
0 ≤ element value ≤ 9999.

[input] linkedlist.integer b

The second number, without its leading zeros.

Guaranteed constraints:
0 ≤ b size ≤ 104,
0 ≤ element value ≤ 9999.

[output] linkedlist.integer

The result of adding a and b together, returned without leading zeros in the same format.

// Definition for singly-linked list:
// class ListNode<T> {
//   public T value { get; set; }
//   public ListNode<T> next { get; set; }
// }
//
ListNode<int> addTwoHugeNumbers(ListNode<int> a, ListNode<int> b) {
    if (b == null) return a;
    if (a == null) return b;
    
    List<int> aList = new List<int>();
    List<int> bList = new List<int>();
    List<int> output = new List<int>();
    
    while (a != null) {
        aList.Add(a.value);
        a = a.next;
    }
    while (b != null) {
        bList.Add(b.value);
        b = b.next;
    }
    
    aList.Reverse();
    bList.Reverse();
    
    int overflow = 0;
    int count = Math.Max(aList.Count, bList.Count);
    
    for (int i = 0; i < count; i++) {
        int aVal = 0;
        int bVal = 0;
        if (aList.Count > i) aVal = aList[i];
        if (bList.Count > i) bVal = bList[i];
        
        int value = aVal + bVal + overflow;
        overflow = 0;
        if (value > 9999) {
            overflow = value / 9999;
            value = value % 10000;
        }
        output.Add(value);
    }
    
    if (overflow > 0) output.Add(overflow);
    
    output.Reverse();
    
    if (output.Count > 0) {
        ListNode<int> ret = new ListNode<int>() { value = output[0] };
        ListNode<int> current = ret;
        for (int i = 1; i < output.Count; i++) {
            current.next = new ListNode<int>() { value = output[i] };
            current = current.next;
        }
        return ret;
    }
    return new ListNode<int>() { value = 0 };
}
