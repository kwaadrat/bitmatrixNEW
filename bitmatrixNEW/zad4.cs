// file: BitMatrixPartial.cs
using System;
using System.Collections;
using System.Collections.Generic;

public partial class BitMatrix:IEnumerable<int> 
{
     public IEnumerator<int> GetEnumerator()
     {
         foreach (var b in data)
         {
             yield return BoolToBit((bool)b);
         }
     }
     IEnumerator IEnumerable.GetEnumerator()
     {
         return GetEnumerator();
     }
     public int this[int i, int j ]
     {
         get
         {
             if( i>= NumberOfRows || i < 0 || j < 0) throw new IndexOutOfRangeException();
             return BoolToBit(data[i*NumberOfColumns+j]);
             
         }
         set
         {
              if (j >= NumberOfColumns || i >= NumberOfRows || i < 0  || j < 0) throw new IndexOutOfRangeException();
              data[i * NumberOfColumns + j] = BitToBool(value);
         }
     }
}
