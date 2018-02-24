// You have a collection of coins, and you know the values of the coins and the quantity of each type of coin in it. You want to know how many distinct sums you can make from non-empty groupings of these coins.

// Example

// For coins = [10, 50, 100] and quantity = [1, 2, 1], the output should be
// possibleSums(coins, quantity) = 9.

// Here are all the possible sums:

// 50 = 50;
// 10 + 50 = 60;
// 50 + 100 = 150;
// 10 + 50 + 100 = 160;
// 50 + 50 = 100;
// 10 + 50 + 50 = 110;
// 50 + 50 + 100 = 200;
// 10 + 50 + 50 + 100 = 210;
// 10 = 10;
// 100 = 100;
// 10 + 100 = 110.
// As you can see, there are 9 distinct sums that can be created from non-empty groupings of your coins.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.integer coins

// An array containing the values of the coins in your collection.

// Guaranteed constraints:
// 1 ≤ coins.length ≤ 20,
// 1 ≤ coins[i] ≤ 104.

// [input] array.integer quantity

// An array containing the quantity of each type of coin in your collection. quantity[i] indicates the number of coins that have a value of coins[i].

// Guaranteed constraints:
// quantity.length = coins.length,
// 1 ≤ quantity[i] ≤ 105.

// It is guaranteed that (quantity[0] + 1) * (quantity[1] + 1) * ... * (quantity[quantity.length - 1] + 1) <= 106.

// [output] integer

// The number of different possible sums that can be created from non-empty groupings of your coins

int possibleSums(int[] coins, int[] quantity) {
    // the number of coins and quantities must be the same
    if (coins.Length != quantity.Length) return 0;
    // We use a HashSet here so we cannot get duplicates, and we don't have to
    // even attempt to check for duplicates.
    HashSet<int> sums = new HashSet<int>();
    
    // we add a 0 in here to simplify our next loop
    sums.Add(0);
    
    // iterate through all of the coins and build up a list of possible sums
    for (int i = 0; i < coins.Length; i++) {
        // new list to hold the current sums
        List<int> sumsNow = new List<int>(sums);
        // iterate through all the current sums
        foreach (int sum in sumsNow) {
            for (int j = 1; j <= quantity[i]; ++j) {
                // add the sums into the HashSet here
                sums.Add(sum + j * coins[i]);
           }
        }
    }
    
    // return the hashset size - 1 (to compensate for the 0 we added)
    return sums.Count - 1;
}
