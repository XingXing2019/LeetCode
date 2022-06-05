package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class TextEditor {

    private int cursor;
    private StringBuilder editor;
    public TextEditor()
    {
        editor = new StringBuilder();
    }

    public void addText(String text)
    {
        editor.insert(cursor, text);
        cursor += text.length();
    }

    public int deleteText(int k)
    {
        var len = Math.min(cursor, k);
        editor.delete(cursor - len, cursor);
        cursor -= len;
        return len;
    }

    public String cursorLeft(int k)
    {
        cursor -= Math.min(cursor, k);
        var len = Math.min(cursor, 10);
        return editor.toString().substring(cursor - len, cursor);
    }

    public String cursorRight(int k)
    {
        cursor += Math.min(editor.length() - cursor, k);
        var len = Math.min(cursor, 10);
        var res = editor.toString().substring(cursor - len, cursor);
        return res;
    }
}

