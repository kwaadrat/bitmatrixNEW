// file: BitMatrixPartial.cs
using System;
using System.Collections;
using System.Collections.Generic;
public partial class BitMatrix
{
   public static BitMatrix Parse(string s)
    {
        if (s == null || s == String.Empty) throw new ArgumentNullException();
        string[] input = s.Split(@"
");
        bool[,] bits = new bool[input.Length,input[0].Length];
        for (int i = 0; i < input.Length; i++)
        {
            if(input[i].Length != input[0].Length)throw new FormatException();
            for(int j = 0; j < input[0].Length; j++)
            {
                if(input[i][j] != '0' && input[i][j] != '1') throw new FormatException();
                    bits[i, j] = input[i][j] != '0';
            }
        }
        return new BitMatrix(bits);
    }
    public static bool TryParse(string s, out BitMatrix result)
    {
        try
        {
            result = Parse(s);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

}