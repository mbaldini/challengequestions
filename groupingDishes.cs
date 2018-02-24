// You have a list of dishes. Each dish is associated with a list of ingredients used to prepare it. You want to group the dishes by ingredients, so that for each ingredient you'll be able to find all the dishes that contain it (if there are at least 2 such dishes).

// Return an array where each element is a list with the first element equal to the name of the ingredient and all of the other elements equal to the names of dishes that contain this ingredient. The dishes inside each list should be sorted lexicographically. The result array should be sorted lexicographically by the names of the ingredients in its elements.

// Example

// For
//   dishes = [["Salad", "Tomato", "Cucumber", "Salad", "Sauce"],
//             ["Pizza", "Tomato", "Sausage", "Sauce", "Dough"],
//             ["Quesadilla", "Chicken", "Cheese", "Sauce"],
//             ["Sandwich", "Salad", "Bread", "Tomato", "Cheese"]]
// the output should be
//   groupingDishes(dishes) = [["Cheese", "Quesadilla", "Sandwich"],
//                             ["Salad", "Salad", "Sandwich"],
//                             ["Sauce", "Pizza", "Quesadilla", "Salad"],
//                             ["Tomato", "Pizza", "Salad", "Sandwich"]]
// For
//   dishes = [["Pasta", "Tomato Sauce", "Onions", "Garlic"],
//             ["Chicken Curry", "Chicken", "Curry Sauce"],
//             ["Fried Rice", "Rice", "Onions", "Nuts"],
//             ["Salad", "Spinach", "Nuts"],
//             ["Sandwich", "Cheese", "Bread"],
//             ["Quesadilla", "Chicken", "Cheese"]]
// the output should be
//   groupingDishes(dishes) = [["Cheese", "Quesadilla", "Sandwich"],
//                             ["Chicken", "Chicken Curry", "Quesadilla"],
//                             ["Nuts", "Fried Rice", "Salad"],
//                             ["Onions", "Fried Rice", "Pasta"]]
// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.array.string dishes

// An array of dishes. dishes[i] for each valid i contains information about the ith dish: the first element of dishes[i] is the name of the dish and the following elements are the ingredients of that dish. Both the dish name and the ingredient names consist of English letters and spaces. It is guaranteed that all dish names are different. It is also guaranteed that ingredient names for one dish are also pairwise different.

// Guaranteed constraints:
// 1 ≤ dishes.length ≤ 500,
// 2 ≤ dishes[i].length ≤ 10,
// 1 ≤ dishes[i][j].length ≤ 50.

// [output] array.array.string

// The array containing the grouped dishes.

string[][] groupingDishes(string[][] dishes) {
    // Create a Dictionary to hold the dishes and ingredients
    Dictionary<String, List<String>> ht = new Dictionary<String, List<String>>();
    
    // iterate through the dishes
    for (int i = 0; i < dishes.Length; i++) {
        if (dishes[i] == null) continue;
        
        String dishName = (dishes[i][0]);
        
        // iterate through the ingrediente
        for (int k = 1; k < dishes[i].Length; k++) {
            // start compiling a Dictionary<ingredient, List<dish>>
            String ingredient = dishes[i][k];
            if (!ht.ContainsKey(ingredient)) ht.Add(ingredient, new List<String>());
            ht[ingredient].Add(dishName);
        }
    }
    
    // Get a list<ingredient> from the hashmap's keys
    List<String> keys = ht.Keys.ToArray().ToList();
    // sort them by name lexicographically
    keys.Sort((x,y) => String.CompareOrdinal(x,y));
    
    // build a new, hashmap containing the sorted values
    Dictionary<String, List<String>> ret = new Dictionary<String, List<String>>();
    foreach(String key in keys) {
        ret.Add(key, ht[key]);
    }
    
    // convert them back to a string[][] and return it
    return toTwoDimensionalArray(ret);
}

string[][] toTwoDimensionalArray(Dictionary<String, List<String>> map) {
    List<string[]> ret = new List<string[]>();
    foreach (String key in map.Keys) {
        List<String> items = map[key];
        if (items.Count > 1) {
            items.Sort((x,y) => String.CompareOrdinal(x, y));
            items.Insert(0, key);
            ret.Add(items.ToArray());
        }
    }
    return ret.ToArray();
}

