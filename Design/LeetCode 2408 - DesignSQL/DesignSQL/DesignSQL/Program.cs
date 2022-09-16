using System;
using System.Collections.Generic;

namespace DesignSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class SQL
    {
        class Row
        {
            private IList<string> colums;
            public Row(IList<string> colums)
            {
                this.colums = colums;
            }

            public string GetColumn(int id)
            {
                return colums[id - 1];
            }
        }

        class Table
        {
            private Dictionary<int, Row> rows;
            private int index;
            public Table()
            {
                rows = new Dictionary<int, Row>();
                index = 1;
            }

            public void Add(Row row)
            {
                rows[index++] = row;
            }

            public void Delete(int id)
            {
                rows.Remove(id);
            }

            public Row GetRow(int id)
            {
                return rows[id];
            }
        }

        private Dictionary<string, Table> tables;
        public SQL(IList<string> names, IList<int> columns)
        {
            tables = new Dictionary<string, Table>();
            foreach (var name in names)
            {
                tables[name] = new Table();
            }
        }

        public void InsertRow(string name, IList<string> row)
        {
            tables[name].Add(new Row(row));
        }

        public void DeleteRow(string name, int rowId)
        {
            tables[name].Delete(rowId);
        }

        public string SelectCell(string name, int rowId, int columnId)
        {
            var row = tables[name].GetRow(rowId);
            return row.GetColumn(columnId);
        }
    }
}
