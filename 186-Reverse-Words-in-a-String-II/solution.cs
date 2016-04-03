public class Solution {
    public void ReverseWords(char[] s) {
        if(s == null || s.Count() == 0){
            return;
        }
        ReverseChars(s, 0, s.Count()-1);
        var start = 0;
        var end = 0;
        for(var i = 0; i < s.Count(); i++){
            if(s[i] == ' '){
                end = i - 1;
                ReverseChars(s, start, end);
                start = i + 1;
            }
            else if(i == s.Count()-1){
                end = i;
                ReverseChars(s, start, end);
            }
        }
    }
    
    public void ReverseChars(char[] s, int start, int end){
        while(start < end){
            var temp = s[start];
            s[start] = s[end];
            s[end] = temp;
            start++;
            end--;
        }
    }
}