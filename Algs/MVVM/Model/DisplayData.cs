using System;

namespace Algs.MVVM.Model
{
  public class DisplayData
  {
    public static int ArraySize { get { return _arraySize; } }
    public static int LargestNum { get { return _largest; } }
    public int[] Data { get; set; }
    private static int _arraySize;
    private static int _largest;

    public DisplayData(int size = 1000)
    {
      _arraySize = size;
      MakeArray();
    }

    private void MakeArray()
    {
      Data = new int[ArraySize];
      var rnd = new Random();
      for (var i = 0; i < ArraySize; i++)
      {
        Data[i] = rnd.Next(0, 10000);
      }
      _largest = GetBiggest(Data);
    }

    public static int GetBiggest(int[] data)
    {
      int biggest = data[0];
      for (var i = 1; i < ArraySize; i++)
      {
        if (data[i] > biggest) biggest = data[i];
      }
      return biggest;
    }

  }
}
