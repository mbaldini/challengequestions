// Given an array of integers, write a function that determines whether the array contains any duplicates. Your function should return true if any element appears at least twice in the array, and it should return false if every element is distinct.

// Example

// For a = [1, 2, 3, 1], the output should be
// containsDuplicates(a) = true.

// There are two 1s in the given array.

// For a = [3, 1], the output should be
// containsDuplicates(a) = false.

// The given array contains no duplicates.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.integer a

// Guaranteed constraints:
// 0 ≤ a.length ≤ 105,
// -2 · 109 ≤ a[i] ≤ 2 · 109.

// [output] boolean

bool containsDuplicates(int[] a) {
    // we can use a HashSet to ensure we cannot have duplicates.
    // So all we have to do is add everything to the list, and then
    // compare the number of items at the end to the original list.
    HashSet<int> cache = new HashSet<int>();
    for (int i = 0; i < a.Length; i++) {
        cache.Add(a[i]);
    }
    return cache.Count != a.Length;
}
