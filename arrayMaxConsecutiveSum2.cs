// Given an array of integers, find the maximum possible sum you can get from one of its contiguous subarrays. The subarray from which this sum comes must contain at least 1 element.

// Example

// For inputArray = [-2, 2, 5, -11, 6], the output should be
// arrayMaxConsecutiveSum2(inputArray) = 7.

// The contiguous subarray that gives the maximum possible sum is [2, 5], with a sum of 7.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.integer inputArray

// An array of integers.

// Guaranteed constraints:
// 3 ≤ inputArray.length ≤ 105,
// -1000 ≤ inputArray[i] ≤ 1000.

// [output] integer

// The maximum possible sum of a subarray within inputArray.

int arrayMaxConsecutiveSum2(int[] inputArray) {
    int count = inputArray.Length;
    // holds the maximum value we found so far
    int maxSoFar = int.MinValue;
    // hold the current maximum value
    int maxHere = 0;
    
    // iterate through the input array and calculate the
    // overall largest and running totals
    for (int i = 0; i < count; i++) {
        maxHere += inputArray[i];
        maxSoFar = Math.Max(maxSoFar, maxHere);
        maxHere = Math.Max(maxHere, 0);
    }
    
    return maxSoFar;
}
