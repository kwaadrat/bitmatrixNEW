// file: BitMatrixPartial.cs
using System;
using System.Collections;
using System.Collections.Generic;
public partial class BitMatrix :  IEquatable<BitMatrix>
{
    public override bool Equals(object obj)
    {
        return Equals(obj as BitMatrix);
    }

    public bool Equals(BitMatrix other)
    {
        bool equals = other != null &&
               NumberOfRows == other.NumberOfRows &&
               NumberOfColumns == other.NumberOfColumns;
        if (!equals) return false;
        for (int i = 0; i < NumberOfColumns * NumberOfRows; i++)
            if (data[i] != other.data[i]) return false;
        return true;
    }

    public static bool operator ==(BitMatrix left, BitMatrix right)
    {
        return EqualityComparer<BitMatrix>.Default.Equals(left, right);
    }

    public static bool operator !=(BitMatrix left, BitMatrix right)
    {
        return !(left == right);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(data, NumberOfRows, NumberOfColumns, IsReadOnly);
    }
}