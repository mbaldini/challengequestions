// Note: Avoid using built-in std::nth_element (or analogous built-in functions in languages other than C++) when solving this challenge. Implement them yourself, since this is what you would be asked to do during a real interview.

// Find the kth largest element in an unsorted array. This will be the kth largest element in sorted order, not the kth distinct element.

// Example

// For nums = [7, 6, 5, 4, 3, 2, 1] and k = 2, the output should be
// kthLargestElement(nums, k) = 6;
// For nums = [99, 99] and k = 1, the output should be
// kthLargestElement(nums, k) = 99.
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.integer nums

// Guaranteed constraints:
// 1 ≤ nums.length ≤ 105,
// -105 ≤ nums[i] ≤ 105.

// [input] integer k

// Guaranteed constraints:
// 1 ≤ k ≤ nums.length.

// [output] integer

int kthLargestElement(int[] nums, int k) {
    int heapSize = nums.Length - 1;
    
    // use heapsort to order the elements in the array
    for (int i = heapSize / 2; i >= 0; i--)
    {
        heapify(nums, i, heapSize);
    }
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        swap(nums, 0, i);
        heapSize--;
        heapify(nums, 0, heapSize);
    }
    
    return nums[nums.Length - k];
}

void swap(int[] nums, int a, int b) {
    // simply swap the values at indexes a and b
    int tmp = nums[a];
    nums[a] = nums[b];
    nums[b] = tmp;
}

void heapify(int[] nums, int index, int heapSize) {
    // Heapsort!
    
    int left = 2 * index;
    int right = 2 * index + 1;
    int largest = index;

    if (left <= heapSize && nums[left] > nums[index])
    {
        largest = left;
    }

    if (right <= heapSize && nums[right] > nums[largest])
    {
        largest = right;
    }

    if (largest != index)
    {
        swap(nums, index, largest);
        heapify(nums, largest, heapSize);
    }
}
