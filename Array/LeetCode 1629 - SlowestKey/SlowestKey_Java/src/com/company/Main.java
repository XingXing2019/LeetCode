package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public char slowestKey(int[] releaseTimes, String keysPressed) {
        char res = keysPressed.charAt(0);
        int max = releaseTimes[0];
        for (int i = 1; i < releaseTimes.length; i++) {
            if(releaseTimes[i] - releaseTimes[i - 1] > max || releaseTimes[i] - releaseTimes[i - 1] == max && keysPressed.charAt(i) > res){
                max = releaseTimes[i] - releaseTimes[i - 1];
                res = keysPressed.charAt(i);
            }
        }
        return res;
    }
}
