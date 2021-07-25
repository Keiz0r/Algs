namespace SortingLib
{
  public static class BubbleSort
  {
    public static uint Step { get { return _step; } }
    private static uint _step = 0;

    public static void SortStep(int[] array)
    {
      for (var i = 0; i < array.Length - 1; i++)
      {
        if(array[i] > array[i + 1])
        {
          Swap(ref array[i], ref array[i+1]);
        }
      }
      _step++;
    }

    public static void Sort(int[] array)
    {
      for (var i = 0; i < array.Length - 1; i++)
      {
        bool isSorted = false;
        for (var j = 0; j < array.Length - 1 - i; j++)
        {
          if (array[j] > array[j + 1])
          {
            Swap(ref array[j], ref array[j + 1]);
            isSorted = true;
          }
        }
        if (!isSorted)
        {
          break;
        }
        _step++;
      }
    }

    public static void ResetStep()
    {
      _step = 0;
    }

    public static bool IsSorted(int[] array)
    {
      for(var i = 0; i < array.Length - 1; i++)
      {
        if(array[i] > array[i + 1])
        {
          return false;
        }
      }
      return true;
    }

    private static void  Swap(ref int i, ref int j)
    {
      int temp;
      temp = i;
      i = j;
      j = temp;
    }
  }
}
