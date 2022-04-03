package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public char nextGreatestLetter(char[] letters, char target) {
        int min = Integer.MAX_VALUE;
        for (char letter : letters) {
            if (letter == target) continue;
            if (letter < target)
                min = Math.min(min, letter + 26 - target);
            else
                min = Math.min(min, letter - target);
        }
        return (char) ((target - 'a' + min) % 26 + 'a');
    }

    public char nextGreatestLetter_binarySearch(char[] letters, char target) {
        int li = 0, hi = letters.length - 1;
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (letters[mid] > target)
                hi = mid - 1;
            else
                li = mid + 1;
        }
        return li == letters.length ? letters[0] : letters[li];
    }
}
