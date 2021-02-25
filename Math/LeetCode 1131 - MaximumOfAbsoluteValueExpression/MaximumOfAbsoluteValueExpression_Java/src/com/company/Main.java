/*      arr1[i] - arr1[j] + arr2[i] - arr2[j] + i - j
        arr1[i] - arr1[j] - arr2[i] + arr2[j] + i - j
        arr1[i] - arr1[j] + arr2[i] - arr2[j] - i + j
        arr1[i] - arr1[j] - arr2[i] + arr2[j] - i + j
        -arr1[i] + arr1[j] + arr2[i] - arr2[j] + i - j
        -arr1[i] + arr1[j] - arr2[i] + arr2[j] + i - j
        -arr1[i] + arr1[j] + arr2[i] - arr2[j] - i + j
        -arr1[i] + arr1[j] - arr2[i] + arr2[j] - i + j

        arr1[i] + arr2[i] + i - ( arr1[j] + arr2[j] + j )
        arr1[i] - arr2[i] + i - ( arr1[j] - arr2[j] + j )
        arr1[i] + arr2[i] - i - ( arr1[j] + arr2[j] - j )
        arr1[i] - arr2[i] - i - ( arr1[j] - arr2[j] - j )

        arr1[i] + arr2[i] + i
        arr1[i] - arr2[i] + i
        arr1[i] + arr2[i] - i
        arr1[i] - arr2[i] - i
*/

package com.company;
public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maxAbsValExpr(int[] arr1, int[] arr2) {
        int[] max = {Integer.MIN_VALUE, Integer.MIN_VALUE, Integer.MIN_VALUE, Integer.MIN_VALUE};
        int[] min = {Integer.MAX_VALUE, Integer.MAX_VALUE, Integer.MAX_VALUE, Integer.MAX_VALUE};
        int[] sign = {1, 1, -1, -1, 1};
        int res = Integer.MIN_VALUE;
        for (int i = 0; i < arr1.length; i++) {
            for (int j = 0; j < 4; j++) {
                max[j] = Math.max(max[j], arr1[i] + arr2[i] * sign[j] + i * sign[j + 1]);
                min[j] = Math.min(min[j], arr1[i] + arr2[i] * sign[j] + i * sign[j + 1]);
                res = Math.max(res, max[j] - min[j]);
            }
        }
        return res;
    }
}
