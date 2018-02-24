// Given an array of integers nums and an integer k, determine whether there are two distinct indices i and j in the array where nums[i] = nums[j] and the absolute difference between i and j is less than or equal to k.

// Example

// For nums = [0, 1, 2, 3, 5, 2] and k = 3, the output should be
// containsCloseNums(nums, k) = true.

// There are two 2s in nums, and the absolute difference between their positions is exactly 3.

// For nums = [0, 1, 2, 3, 5, 2] and k = 2, the output should be

// containsCloseNums(nums, k) = false.

// The absolute difference between the positions of the two 2s is 3, which is more than k.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.integer nums

// Guaranteed constraints:
// 0 ≤ nums.length ≤ 55000,
// -231 - 1 ≤ nums[i] ≤ 231 - 1.

// [input] integer k

// Guaranteed constraints:
// 0 ≤ k ≤ 35000.

// [output] boolean

bool containsCloseNums(int[] nums, int k) {
    Dictionary<int, List<int>> indicies = new Dictionary<int, List<int>>();
    for (int i = 0; i < nums.Length; i++) {
        // store the indexes for each value in the dictionary
        if(!indicies.ContainsKey(nums[i])) indicies.Add(nums[i], new List<int>());
        indicies[nums[i]].Add(i);
    }
    
    // iterate through the indicies to find close matches
    foreach (KeyValuePair<int, List<int>> kvp in indicies) {
        if (kvp.Value.Count < 2) continue;
        
        int previousIndex = -1;
        foreach (int index in kvp.Value) {
            if (previousIndex > -1) {
                if (index - previousIndex <= k) return true;
            }
            previousIndex = index;
        }
    }
    
    return false;
}
