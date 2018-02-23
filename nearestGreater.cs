// Given an array of integers a, return a new array b using the following guidelines:

// For each index i in b, the value of bi is the index of the aj nearest to ai and is also greater than ai.
// If there are two options for bi, put the leftmost one in bi.
// If there are no options for bi, put -1 in bi.

// Example
// For a = [1, 4, 2, 1, 7, 6], the output should be
// nearestGreater(a) = [1, 4, 1, 2, -1, 4].

// for a[0], the nearest larger element is 4 at index a[1] -> b[0] contains the value 1.
// for a[1], the nearest larger element is 7 at a[4] -> b[1] contains the value 4.
// for a[2], the nearest larger element is 4 at a[1] (7 is also larger, but 4 has the minimal position) -> b[2] contains the value 1.
// for a[3], the nearest larger element is 2 at a[2] (7 is also larger, but 2 has the minimal position) -> b[3] contains the value 2.
// for a[4], there is no element larger than 7 -> b[4] contains the value -1.
// for a[5], the nearest larger element is 7 at a[4] -> b[5] contains the value 4.
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.integer a

// An unsorted array of integers.

// Guaranteed constraints:
// 1 ≤ a.length ≤ 4 · 104,
// 1 ≤ a[i] ≤ 109.

// [output] array.integer

// An array b, where for each index i, bi is the index of the nearest number in a that is greater than ai.

int[] nearestGreater(int[] a) {
    int[] nearest = new int[a.Length];
    
    // we will want to store the last value just for a quick check if the last value
    // was larger than the current. Super small optimization, but every bit helps.
    int lastValue = int.MinValue;
    
    // Store the largest value we have yet to come across, that way we can optimize
    // our search by not searching left if there have not been any values larger
    // than the current one.
    int leftLargest = int.MinValue;
    
    // main iteration loop. 
    for(int i = 0; i < a.Length; i++) {
        if (a[i] < lastValue) {
            // The last value we looked at was larger than this, so we can simply
            // use its index.
            nearest[i] = i - 1;
        } else {
            if (leftLargest > a[i]) {
                // there was a value larger somewhere back there
                // so we must search both forward and backward to find the closest.
                int count = Math.Max(a.Length - i, a.Length - (a.Length - i));
                int index = -1;
                for (int x = 1; x < count; x++) {
                    // as per the docs, look left first
                    if (i - x >= 0) {
                        if (a[i] < a[i - x]) {
                            index = i - x;
                            break;
                        }
                    }
                    if (i + x < a.Length) {
                        if (a[i] < a[i + x]) {
                            index = i + x;
                            break;
                        }
                    }
                }
                
                // set the nearest
                nearest[i] = index;
            } else {
                // There has not yet been a value larger than the current one.
                // Therefore there is no need to search backward, only forward.
                // This also means that the current value is the larges we have 
                // yet come across, so lets store it for future reference.
                leftLargest = a[i];
                
                int index = -1;
                for (int x = 1; x < a.Length - i; x++) {
                    if (a[i + x] > a[i]) {
                        index = i + x;
                        break;
                    }
                }
                
                // set the nearest
                nearest[i] = index;
            }
        }
        
        // keep what our last value was for reference
        lastValue = a[i];
    }
    
    return nearest;
}
