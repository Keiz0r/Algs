namespace SortingLib
{
  public static class BubbleSort
  {
    public static uint SortStep(int[] array, ref int lastIndex)
    {
      uint stepCounter = 0;
      for (var i = 0; i < array.Length - 1 - lastIndex; i++)
      {
        if(array[i] > array[i + 1])
        {
          Swap(ref array[i], ref array[i+1]);
          stepCounter++;
        }
      }
      lastIndex++;
      return stepCounter;
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
