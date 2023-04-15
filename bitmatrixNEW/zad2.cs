using System;
using System.Collections;
public partial class BitMatrix
{

   public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
    {
        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(numberOfRows * numberOfColumns, false);
        if (bits != null)
            for (int i = 0; i < numberOfRows * numberOfColumns && i < bits.Length; i++)
                data.Set(i, BitToBool(bits[i]));
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }
    public BitMatrix(int[,] bits)
    {
        if (bits.GetLength(0) < 1 || bits.GetLength(1) < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(bits.GetLength(0) * bits.GetLength(1), false);
        NumberOfRows = bits.GetLength(0);
        NumberOfColumns = bits.GetLength(1);
        for (int i = 0; i < bits.GetLength(0); i++)
            for (int j = 0; j < bits.GetLength(1); j++)
                data.Set(i * NumberOfColumns + j, BitToBool(bits[i, j]));
    }

    public BitMatrix(bool[,] bits)
    {
        if (bits.GetLength(0) < 1 || bits.GetLength(1) < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(bits.GetLength(0) * bits.GetLength(1), false);
        NumberOfRows = bits.GetLength(0);
        NumberOfColumns = bits.GetLength(1);
        for (int i = 0; i < bits.GetLength(0); i++)
            for (int j = 0; j < bits.GetLength(1); j++)
                data.Set(i * NumberOfColumns + j, bits[i, j]);
    }
}