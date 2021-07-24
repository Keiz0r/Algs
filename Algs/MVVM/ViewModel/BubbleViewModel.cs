using System.Collections.ObjectModel;
using Algs.Core;
using Algs.MVVM.Model;

namespace Algs.MVVM.ViewModel
{
  public class BubbleViewModel : ObservableObject
  {
    public RelayCommand UpdateButton { get; set; }
    public ObservableCollection<Column> ColumnsToDraw { get; set; }
    private static DisplayData DispData;

    private static string ColumnColor { get; set; }
    private static double _canvasSize;

    public BubbleViewModel()
    {
      ColumnColor = "#FFFFFF";
      _canvasSize = App.Current.MainWindow.Width * (4.0 / 5.0);
      UpdateButton = new RelayCommand(o => { SortGraph(); });
      ColumnsToDraw = new ObservableCollection<Column>();
      DispData = new DisplayData(5);
      DataToDrawable();
    }

    private static void DefineColumns()
    {
      Column.Scalar = (Column.GraphBottomLevel - Column.GraphTopLevel) / DisplayData.LargestNum;
      Column.Width = (_canvasSize / DisplayData.ArraySize) * 0.8;
      Column.Spacing = Column.Width * 1.1;
    }

    private void DataToDrawable(string columnColor = "#FFFFFF")
    {
      DefineColumns();
      for (var i = 0; i < DisplayData.ArraySize; i++)
      {
        ColumnsToDraw.Add(new Column(i, DispData.Data[i], columnColor));
      }
    }

    private void SortGraph()
    {
      var lastIndex = 0;
      for (var i = 0; i < DisplayData.ArraySize - 1; i++)
      {
        SortingLib.BubbleSort.SortStep(DispData.Data, ref lastIndex);
      //  System.Threading.Thread.Sleep(100);
      //  ColumnsToDraw.Clear();
      //  DataToDrawable(ColumnColor);
      }
      ColumnColor = "#EA1515";

        //if (SortingLib.BubbleSort.SortStep(DispData.Data, ref lastIndex) == 0)
        //{
        //  ColumnColor = "#EA1515";
        //}

      ColumnsToDraw.Clear();
      DataToDrawable(ColumnColor);

    }
  } 
}
