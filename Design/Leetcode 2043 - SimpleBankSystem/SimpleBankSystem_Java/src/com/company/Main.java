package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class Bank {
    private long[] _balance;

    public Bank(long[] balance) {
        _balance = balance;
    }

    public boolean transfer(int account1, int account2, long money) {
        if (account1 - 1 < 0 || account1 - 1 >= _balance.length || account2 - 1 < 0 || account2 - 1 >= _balance.length)
            return false;
        if (_balance[account1 - 1] < money) return false;
        _balance[account1 - 1] -= money;
        _balance[account2 - 1] += money;
        return true;
    }

    public boolean deposit(int account, long money) {
        if (account - 1 < 0 || account - 1 >= _balance.length) return false;
        _balance[account - 1] += money;
        return true;
    }

    public boolean withdraw(int account, long money) {
        if (account - 1 < 0 || account - 1 >= _balance.length || _balance[account - 1] < money)
            return false;
        _balance[account - 1] -= money;
        return true;
    }
}
