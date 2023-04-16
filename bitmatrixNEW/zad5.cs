// file: BitMatrixPartial.cs

using System;
using System.Collections;
using System.Collections.Generic;

public partial class BitMatrix : ICloneable
{
  public object Clone()
    {
        int[,] bits = new int[NumberOfRows,NumberOfColumns];
        int i = 0, j = 0;
        foreach (var b in data)
        {
            bits[i,j] = BoolToBit((bool)b);
            i++;
            if (i == NumberOfRows)
            {
                j++;
                i = 0;
            }
        }
        return new BitMatrix(bits);
    }
}