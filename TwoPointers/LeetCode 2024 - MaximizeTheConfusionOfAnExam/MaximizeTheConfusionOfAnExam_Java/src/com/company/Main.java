package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maxConsecutiveAnswers(String answerKey, int k) {
        return Math.max(count(answerKey, 'T', k), count(answerKey, 'F', k));
    }

    public int count(String answerKey, Character target, int k) {
        int li = 0, hi = 0, res = 0;
        var ans = answerKey.toCharArray();
        while (hi < ans.length) {
            if (ans[hi] != target) {
                res = Math.max(res, hi - li);
                while (li < hi && k == 0) {
                    k += ans[li++] == target ? 0 : 1;
                }
                k--;
            }
            hi++;
        }
        return Math.max(res, hi - li);
    }
}
