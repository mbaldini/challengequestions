// You have an unsorted array arr of non-negative integers and a number s. Find a longest contiguous subarray in arr that has a sum equal to s. Return two integers that represent its inclusive bounds. If there are several possible answers, return the one with the smallest left bound. If there are no answers, return [-1].

// Your answer should be 1-based, meaning that the first position of the array is 1 instead of 0.

// Example

// For s = 12 and arr = [1, 2, 3, 7, 5], the output should be
// findLongestSubarrayBySum(s, arr) = [2, 4].

// The sum of elements from the 2nd position to the 4th position (1-based) is equal to 12: 2 + 3 + 7.

// For s = 15 and arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], the output should be
// findLongestSubarrayBySum(s, arr) = [1, 5].

// The sum of elements from the 1st position to the 5th position (1-based) is equal to 15: 1 + 2 + 3 + 4 + 5.

// For s = 15 and arr = [1, 2, 3, 4, 5, 0, 0, 0, 6, 7, 8, 9, 10], the output should be
// findLongestSubarrayBySum(s, arr) = [1, 8].

// The sum of elements from the 1st position to the 8th position (1-based) is equal to 15: 1 + 2 + 3 + 4 + 5 + 0 + 0 + 0.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] integer s

// The sum of the subarray that you are searching for.

// Guaranteed constraints:
// 0 ≤ s ≤ 109.

// [input] array.integer arr

// The given array.

// Guaranteed constraints:
// 1 ≤ arr.length ≤ 105,
// 0 ≤ arr[i] ≤ 104.

// [output] array.integer

// An array that contains two elements that represent the left and right bounds of the subarray, respectively (1-based). If there is no such subarray, return [-1].

int[] findLongestSubarrayBySum(int s, int[] arr) {
    // variables to hold our running largest value, our 
    // upper/lower bounds, current value, and current 
    // lower index
    int largestValue = 0;
    int lowerBound = -1;
    int upperBound = -1;
    int currentValue = 0;
    int currentLower = 0;
    
    // iterate through the array to
    for (int i = 0; i < arr.Length; i++) {
        if (currentValue + arr[i] > s) {
            // iterate through the items until the currentValue + arr[i] is
            // greater than the provided s value
            while (currentValue + arr[i] > s) {
                // since we exceeded the current value, we need to subtract our 
                // currentLower value from the sum, and increment the index that
                // marks our current lowest bound
                currentValue -= arr[currentLower];
                currentLower++;
            }
        }
        
        // add the current item to the currentValue
        currentValue += arr[i];
        if (currentValue == s) {
            // now that we found the sum we are looking for, 
            // calculate how long our subarray is
            int curDiff = upperBound - lowerBound;
            int newDiff = i - currentLower;
            // if this is the longest subarray, then lets 
            // update our variables to reflect that.
            if (lowerBound == -1 || newDiff > curDiff) {
                lowerBound = currentLower;
                upperBound = i;
            }
        }
    }
    
    // if we didn't find any subarrays that have a sum of s, 
    // return an array containing -1
    if (lowerBound == -1) return new int[] { -1 };
    
    // return an array containing the upper and lower bounds, 
    // converted to a 1-based index
    return new int[] { lowerBound + 1, upperBound + 1 };
}
