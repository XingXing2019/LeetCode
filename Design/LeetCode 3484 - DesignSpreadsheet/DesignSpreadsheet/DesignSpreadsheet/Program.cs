var spreadsheet = new Spreadsheet(458);
Console.WriteLine(spreadsheet.GetValue("=O126+10272"));

public class Spreadsheet
{
    private int[][] excel;
    public Spreadsheet(int rows)
    {
        excel = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            excel[i] = new int[26];
            Array.Fill(excel[i], -1);
        }
    }

    public void SetCell(string cell, int value)
    {
        var pos = GetCell(cell);
        int row = pos[0], col = pos[1];
        excel[row][col] = value;
    }

    public void ResetCell(string cell)
    {
        var pos = GetCell(cell);
        int row = pos[0], col = pos[1];
        excel[row][col] = 0;
    }

    public int GetValue(string formula)
    {
        var parts = formula.Substring(1).Split('+');
        int x = GetCellValue(parts[0]), y = GetCellValue(parts[1]);
        if (x == -1 || y == -1)
            return 0;
        return x + y;
    }

    private int GetCellValue(string cell)
    {
        if (int.TryParse(cell, out var num))
            return num;
        var pos = GetCell(cell);
        return excel[pos[0]][pos[1]];
    }

    private int[] GetCell(string cell)
    {
        int row = int.Parse(cell.Substring(1)) - 1, col = cell[0] - 'A';
        return new[] { row, col };
    }
}