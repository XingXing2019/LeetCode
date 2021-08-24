package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        String num1 = "1+1i", num2 = "1+1i";
        System.out.println(complexNumberMultiply(num1, num2));
    }

    public static String complexNumberMultiply(String num1, String num2) {
        int[] nums1 = getNums(num1), nums2 = getNums(num2);
        int real = nums1[0] * nums2[0] - nums1[1] * nums2[1];
        int imaginary = nums1[0] * nums2[1] + nums1[1] * nums2[0];
        return Integer.toString(real) + '+' + Integer.toString(imaginary) + 'i';
    }

    public static int[] getNums(String num) {
        String[] parts = num.split("[+|i|-]");
        int[] nums = new int[2];
        int index = 0;
        for (String part : parts) {
            if (part.equals("")) continue;
            nums[index++] = Integer.parseInt(part);
        }
        if (num.charAt(0) == '-')
            nums[0] *= -1;
        for (int i = 1; i < num.length(); i++) {
            if (num.charAt(i) == '-') {
                nums[1] *= -1;
                break;
            }
        }
        return nums;
    }
}
