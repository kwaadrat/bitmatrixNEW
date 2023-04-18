// file: BitMatrixPartial.cs

using System;
using System.Collections;
using System.Collections.Generic;
public partial class BitMatrix
{
  public static explicit operator BitMatrix(int[,] b) => new BitMatrix(b);
    public static implicit operator int[,](BitMatrix b)
    {
        int[,] bits = new int[b.NumberOfRows, b.NumberOfColumns];
        int i = 0, j = 0;
        foreach (var bb in b)
        {
            bits[i, j] = bb;
            j++;
            if (j == b.NumberOfColumns)
            {
                j = 0;
                i++;
            }
        }
        return bits;
    }
    public static explicit operator BitMatrix(bool[,] b) => new BitMatrix(b);
    public static implicit operator bool[,](BitMatrix b)
    {
        bool[,] bits = new bool[b.NumberOfRows, b.NumberOfColumns];
        int i = 0, j = 0;
        foreach (var bb in b)
        {
            bits[i, j] = bb == 0 ? false : true;
            j++;
            if (j == b.NumberOfColumns)
            {
                j = 0;
                i++;
            }
        }
        return bits;
    }
    public static explicit operator BitArray(BitMatrix b)
    {
        bool[] adhesiveTape = new bool[b.NumberOfRows * b.NumberOfColumns];
        int i = 0, j = 0;
        foreach (var bb in b)
        {
            adhesiveTape[i * j + i] = bb == 0 ? false : true;
            i++;
            if (j == b.NumberOfColumns)
            {
               i = 0;
                j++;
            }
        }
        return new BitArray(adhesiveTape);
    }
}