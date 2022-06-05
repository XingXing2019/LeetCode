using System;
using System.Collections.Generic;
using System.Text;

namespace DesignATextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var editor = new TextEditor();
            editor.AddText("leetcode");
            Console.WriteLine(editor.DeleteText(4));
            editor.AddText("practice");
            Console.WriteLine(editor.CursorRight(3));
            Console.WriteLine(editor.CursorLeft(8));
            Console.WriteLine(editor.DeleteText(10));
            Console.WriteLine(editor.CursorLeft(2));
            Console.WriteLine(editor.CursorRight(6));
        }
    }

    public class TextEditor
    {
        private int cursor;
        private StringBuilder editor;
        public TextEditor()
        {
            editor = new StringBuilder();
        }

        public void AddText(string text)
        {
            editor.Insert(cursor, text);
            cursor += text.Length;
        }

        public int DeleteText(int k)
        {
            var len = Math.Min(cursor, k);
            editor.Remove(cursor - len, len);
            cursor -= len;
            return len;
        }

        public string CursorLeft(int k)
        {
            cursor -= Math.Min(cursor, k);
            var len = Math.Min(cursor, 10);
            return editor.ToString().Substring(cursor - len, len);
        }

        public string CursorRight(int k)
        {
            cursor += Math.Min(editor.Length - cursor, k);
            var len = Math.Min(cursor, 10);
            var res = editor.ToString().Substring(cursor - len, len);
            return res;
        }
    }

}
