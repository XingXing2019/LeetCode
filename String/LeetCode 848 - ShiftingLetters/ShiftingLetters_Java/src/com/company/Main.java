package com.company;

public class Main {

    public static void main(String[] args) {
        String s = "ruu";
        int[] shifts = {26, 9, 17};
        System.out.println(shiftingLetters(s, shifts));
    }

    public static String shiftingLetters(String s, int[] shifts) {
        for (int i = shifts.length - 2; i >= 0; i--)
            shifts[i] += shifts[i + 1] % 26;
        char[] letters = s.toCharArray();
        for (int i = 0; i < shifts.length; i++) {
            var letter = letters[i] + shifts[i] % 26;
            if (letter > 'z')
                letter -= 26;
            letters[i] = (char) letter;
        }
        return String.valueOf(letters);
    }
}
