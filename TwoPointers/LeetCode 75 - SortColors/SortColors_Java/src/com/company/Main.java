package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public void sortColors(int[] nums) {
        int zero = 0, one = 0, two = nums.length - 1;
        while (one <= two){
            if (nums[one] == 0){
                int temp = nums[zero];
                nums[zero++] = nums[one];
                nums[one++] = temp;
            }
            else if (nums[one] == 1)
                one++;
            else {
                int temp = nums[two];
                nums[two--] = nums[one];
                nums[one] = temp;
            }
        }
    }
}
