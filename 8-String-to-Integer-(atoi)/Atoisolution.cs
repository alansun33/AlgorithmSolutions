public class Solution {
    public int MyAtoi(string str) {
        if(string.IsNullOrEmpty(str)){
            return 0;
        }
        var pos = 0;
        var start = 0;
        
        while(pos < str.Length && str[pos] == ' '){
            pos++;
        }
        
        if(str[pos] != '+' && str[pos] != '-' && !IsNumber(str[pos])){
            return 0;
        }
        
        bool isPositive;
        if(str[pos] == '+'){
            isPositive = true;
            start = pos + 1;
        }
        else if(str[pos] == '-'){
            isPositive = false;
            start = pos + 1;
        }
        else{
            isPositive = true;
            start = pos;
        }
        
        var value = 0;
        for(var i = start; i < str.Length; i++){
            if(!IsNumber(str[i])){
                return value;
            }
            var current = ValueOf(str[i]);
            if(value == 0){
                value = isPositive ? current : 0 - current;
                continue;
            }
            
            if(Int32.MaxValue / Math.Abs(value) < 10 
            ||(isPositive && Int32.MaxValue - 10 * value <= current)
            ||(!isPositive && Int32.MaxValue - 10 * Math.Abs(value) <= current - 1)){
                return isPositive ? Int32.MaxValue : Int32.MinValue;  
            }
            value = Math.Abs(value * 10) + current;
            value = isPositive ? value : 0 - value;
        }
        return value;
    }
    
    private bool IsNumber(char c){
        return c - '0' >= 0 && c - '0' <= 9;
    }
    
    private int ValueOf(char c){
        if(!IsNumber(c)){
            return Int32.MaxValue;
        }
        return c - '0';
    }
    
}