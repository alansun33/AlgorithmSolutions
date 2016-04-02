public class Solution {
    public void Rotate(int[,] matrix) {
        var dimension = matrix.GetLength(0);
        
        for(int x = 0; x < dimension; x++){
            for(int y = 0; y < x; y++){
                var temp = matrix[x, y];
                matrix[x, y] = matrix[y, x];
                matrix[y, x] = temp;
            }
        }
        
        for(int x = 0; x < dimension; x++){
            for(int y = 0; y < dimension/2; y++){
                var temp = matrix[x, y];
                matrix[x, y] = matrix[x, dimension-y-1];
                matrix[x, dimension-y-1] = temp;
            }
        }
    }
}