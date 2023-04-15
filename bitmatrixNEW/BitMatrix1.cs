// file: BitMatrixPartial.cs

public partial class BitMatrix
{
 public override string ToString()
    {
        char[][] bits = new char[NumberOfRows][];
        int i = 0, j = 0;
        foreach (var b in data)
        {
            if (bits[i] == null)
                bits[i] = new char[NumberOfColumns];
            bits[i][j] = (bool)b ? '1' : '0';
            i++;
            if (i == NumberOfRows)
            {
                j++;
                i = 0;
            }
        }
        string r = "";
        foreach (var b in bits)
            r += new string(b) + "\n";
        return r;
    }
}