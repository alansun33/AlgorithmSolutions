public class Solution {
    public int NumIslands(char[,] grid) {
        if(grid == null || grid.GetLength(0) == 0 || grid.GetLength(1) == 0){
            return 0;
        }
        var rSize = grid.GetLength(0);
        var cSize = grid.GetLength(1);
        var visited = new bool[rSize, cSize];
        var count = 0;
        for(var r = 0; r < rSize; r++){
            for(var c = 0; c < cSize; c++){
                if(grid[r, c] == '1' && visited[r, c] == false){
                    Traverse(r, c, grid, visited);
                    count++;
                }
            }
        }
        return count;
    }
    
    private void Traverse(int row, int col, char[,] grid, bool[,] visited){
        if(row >= grid.GetLength(0) || col >= grid.GetLength(1) || row < 0 || col < 0
        || grid[row, col] == '0' || visited[row, col] == true){
            return;
        }
        visited[row, col] = true;
        Traverse(row-1, col, grid, visited);
        Traverse(row+1, col, grid, visited);
        Traverse(row, col-1, grid, visited);
        Traverse(row, col+1, grid, visited);
    }
}