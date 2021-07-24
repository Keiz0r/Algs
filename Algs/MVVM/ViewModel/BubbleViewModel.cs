using System.Collections.ObjectModel;
using Algs.Core;
using Algs.MVVM.Model;

namespace Algs.MVVM.ViewModel
{
  public class BubbleViewModel : ObservableObject
  {
    public RelayCommand UpdateButton { get; set; }
    public ObservableCollection<Column> ColumnsToDraw { get; set; }
    private DisplayData DispData;

    public BubbleViewModel()
    {
      UpdateButton = new RelayCommand(o => { SortGraph(); });
      ColumnsToDraw = new ObservableCollection<Column>();
      
      DispData = new DisplayData(10000);
      DataToDrawable();
    }

    private void DefineColumns()
    {
      Column.Scalar = (Column.GraphBottomLevel - Column.GraphTopLevel) / DisplayData.LargestNum;
      var canvasSize = App.Current.MainWindow.Width * (4.0 / 5.0);
      Column.Width = (canvasSize / DisplayData.ArraySize) * 0.8;
      Column.Spacing = Column.Width * 1.1;
    }

    private void DataToDrawable()
    {
      DefineColumns();
      for (var i = 0; i < DisplayData.ArraySize; i++)
      {
        ColumnsToDraw.Add(new Column(i, DispData.Data[i]));
      }
    }

    private void SortGraph()
    {
      System.Array.Sort(DispData.Data);
    //  DispData = new DisplayData();
      ColumnsToDraw.Clear();
      DataToDrawable();
    }
  } 
}
