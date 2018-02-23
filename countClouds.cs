// Given a 2D grid skyMap composed of '1's (clouds) and '0's (clear sky), count the number of clouds. A cloud is surrounded by clear sky, and is formed by connecting adjacent clouds horizontally or vertically. You can assume that all four edges of the skyMap are surrounded by clear sky.

// Example

// For

// skyMap = [['0', '1', '1', '0', '1'],
//           ['0', '1', '1', '1', '1'],
//           ['0', '0', '0', '0', '1'],
//           ['1', '0', '0', '1', '1']]
// the output should be
// countClouds(skyMap) = 2;

// For

// skyMap = [['0', '1', '0', '0', '1'],
//           ['1', '1', '0', '0', '0'],
//           ['0', '0', '1', '0', '1'],
//           ['0', '0', '1', '1', '0'],
//           ['1', '0', '1', '1', '0']]
// the output should be
// countClouds(skyMap) = 5.

// Input/Output

// [execution time limit] 3 seconds (cs)

// [input] array.array.char skyMap

// A 2D grid that represents a map of the sky, as described above.

// Guaranteed constraints:

// 0 ≤ skyMap.length ≤ 300,
// 0 ≤ skyMap[i].length ≤ 300.

// [output] integer

// The number of clouds in the given skyMap, as described above.

int countClouds(char[][] skyMap) {
    if (skyMap.Length == 0) return 0;
    if (skyMap[0].Length == 0) return 0;
    
    int height = skyMap.Length;
    int width = skyMap[0].Length;
    
    // array to keep track of which nodes we have visited
    bool[][] visited = new bool[height][];
    
    // keeps track of the number of cloud groups we have found
    int cloudsFound = 0;
    
    // initialize the array of arrays (that just sounds dumb doesnt it?)
    for (int y = 0; y < height; y++) {
        visited[y] = new bool[width];
    }
    
    // loop through all x,y coordinates and evaluate the node (if we haven't yet done so)
    for (int y = 0; y < height; y++) {
        for (int x = 0; x < width; x++) {
            // ensure we dont visit any node twice
            if (!visited[y][x]) {
                visited[y][x] = true;
                // if this is a cloudy node, evaluate it
                if (skyMap[y][x] == '1') {
                    // we didnt actually need to store the points of the cloud, but
                    // it is nice to do so in case we need to calculate its size
                    Point[] cloud = findCloudyNeighbors(skyMap, visited, new Point(x, y));
                    
                    // we found a cloud, so increment!
                    cloudsFound++;
                }
            }
        }
    }
    
    return cloudsFound;
}

Point[] findCloudyNeighbors(char[][] skyMap, bool[][] visited, Point location) {
    // so a cloud is only defined by its N,S,E,W neighbors, diagonals do not count.
    // We use as HashSet so we can ensure there are no duplicates in the list. 
    // This shouldn't be a problem since we are marking which have been visited, 
    // but this is an extra guarantee.
    HashSet<Point> points = new HashSet<Point>();
    
    // this node is a cloud, so add this point to the list.
    points.Add(location);
    
    // ensure that we mark the node as visited
    visited[location.Y][location.X] = true;
    
    // west node check
    if(location.X > 0) {
        Point p = new Point(location.X - 1, location.Y);
        if (skyMap[p.Y][p.X] == '1' && !visited[p.Y][p.X])
            points.UnionWith(findCloudyNeighbors(skyMap, visited, p));
    }
    
    // east node check
    if (location.X < skyMap[location.Y].Length - 1) {
        Point p = new Point(location.X + 1, location.Y);
        if (skyMap[p.Y][p.X] == '1' && !visited[p.Y][p.X])
            points.UnionWith(findCloudyNeighbors(skyMap, visited, p));
    }
    
    // north node check
    if (location.Y > 0) {
        Point p = new Point(location.X, location.Y - 1);
        if (skyMap[p.Y][p.X] == '1' && !visited[p.Y][p.X])
            points.UnionWith(findCloudyNeighbors(skyMap, visited, p));
    }
    
    // south node check
    if (location.Y < skyMap.Length - 1) {
        Point p = new Point(location.X, location.Y + 1);
        if (skyMap[p.Y][p.X] == '1' && !visited[p.Y][p.X])
            points.UnionWith(findCloudyNeighbors(skyMap, visited, p));
    }
    
    return points.ToArray();
}

class Point {
    public int X { get; set; }
    public int Y { get; set; }
    
    public Point(int x, int y) {
        this.X = x;
        this.Y = y;
    }
    
    public override int GetHashCode() {
        return this.X ^ this.Y;
    }
    
    public override bool Equals(Object obj) {
        if (obj == null) return false;
        if (!(obj is Point)) return false;
        Point p = (Point)obj;
        return this.X == p.X && this.Y == p.Y;
    }
}
