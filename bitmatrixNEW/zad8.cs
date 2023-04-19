// file: BitMatrixPartial.cs

using System;
using System.Collections;
using System.Collections.Generic;

public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
{
    public BitMatrix And(BitMatrix other)
    {
        if (other == null) throw new ArgumentNullException();
        if (other.NumberOfRows != NumberOfRows || other.NumberOfColumns != NumberOfColumns) throw new ArgumentException();
        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                int currentIndex = i * NumberOfColumns + j;
                if(other.data[currentIndex] == BitMatrix.BitToBool(1) && this.data[currentIndex] ==  BitMatrix.BitToBool(1))
                {
                    this.data[currentIndex] = BitMatrix.BitToBool(1);
                } else this.data[currentIndex] = BitMatrix.BitToBool(0);
            }
        }
        return this;
    }

    public BitMatrix Or(BitMatrix other)
    {
        if (other == null) throw new ArgumentNullException();
        if (other.NumberOfRows != NumberOfRows || other.NumberOfColumns != NumberOfColumns) throw new ArgumentException();
        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                int currentIndex = i * NumberOfColumns + j;
                if (other.data[currentIndex] == BitMatrix.BitToBool(0) && this.data[currentIndex] == BitMatrix.BitToBool(0))
                {
                    this.data[currentIndex] = BitMatrix.BitToBool(0);
                }
                else this.data[currentIndex] = BitMatrix.BitToBool(1);
            }
        }
        return this;
    }

    public BitMatrix Xor(BitMatrix other)
    {
        if (other == null) throw new ArgumentNullException();
        if (other.NumberOfRows != NumberOfRows || other.NumberOfColumns != NumberOfColumns) throw new ArgumentException();

        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                int currentIndex = i * NumberOfColumns + j;
                if (other.data[currentIndex] == this.data[currentIndex])
                {
                    this.data[currentIndex] = BitMatrix.BitToBool(0);
                }
                else this.data[currentIndex] = BitMatrix.BitToBool(1);
            }
        }
        return this;
    }

    public BitMatrix Not()
    {
        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                int currentIndex = i * NumberOfColumns + j;
                bool temp = data[currentIndex];
                data[currentIndex] = !temp;
            }
        }

        return this;
    }

    public static BitMatrix operator &(BitMatrix firstMatrix, BitMatrix secondMatrix)
    {
        if (firstMatrix == null || secondMatrix == null) throw new ArgumentNullException();
        BitMatrix clone = (BitMatrix)firstMatrix.Clone();
        clone.And(secondMatrix);

        return clone;
    }

    public static BitMatrix operator |(BitMatrix firstMatrix, BitMatrix secondMatrix)
    {
        if (firstMatrix == null || secondMatrix == null) throw new ArgumentNullException();
        BitMatrix clone = (BitMatrix)firstMatrix.Clone();
        clone.Or(secondMatrix);

        return clone;
    }

    public static BitMatrix operator ^(BitMatrix firstMatrix, BitMatrix secondMatrix)
    {
        if (firstMatrix == null || secondMatrix == null) throw new ArgumentNullException();
        BitMatrix clone = (BitMatrix)firstMatrix.Clone();
        clone.Xor(secondMatrix);

        return clone;
    }

    public static BitMatrix operator !(BitMatrix matrix)
    {
        if (matrix == null) throw new ArgumentNullException();
        return (BitMatrix)matrix.Not().Clone();
    }

}