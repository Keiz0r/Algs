using System.Collections.ObjectModel;
using Algs.Core;
using Algs.MVVM.Model;
using SortingLib;

namespace Algs.MVVM.ViewModel
{
  public class BubbleViewModel : ObservableObject
  {
    public static RelayCommand StepButton { get; set; }
    public static RelayCommand FinishButton { get; set; }
    public static RelayCommand RefreshButton { get; set; }
    public string StepCounter { 
      get { return "Current Step = [" + _stepCounter + "]"; }
      set {
        _stepCounter = value;
        OnPropertyChanged();
      }
    }
    public static ObservableCollection<Column> ColumnsToDraw { get; set; }
    private static DisplayData DispData;

    private static string _stepCounter = "0";
    private static string ColumnColor { get; set; }
    private static double _canvasSize;

    public BubbleViewModel()
    {
      ColumnColor = "#FFFFFF";
      _canvasSize = App.Current.MainWindow.Width * (4.0 / 5.0);
      StepButton = new RelayCommand(o => { StepSortGraph((bool)o); });
      FinishButton = new RelayCommand(o => { StepSortGraph((bool)o); });
      RefreshButton = new RelayCommand(o => { RefreshArray(); });

      ColumnsToDraw = new ObservableCollection<Column>();
      RefreshArray();
      DataToDrawable();
    }


    private void DataToDrawable(string columnColor = "#FFFFFF")
    {
      ColumnsToDraw.Clear();
      DefineColumns();
      if (BubbleSort.IsSorted(DispData.Data))
      {
        columnColor = "#00cc00";
      }
      for (var i = 0; i < DisplayData.ArraySize; i++)
      {
        ColumnsToDraw.Add(new Column(i, DispData.Data[i], columnColor));
      }
    }

    private void StepSortGraph(bool finalize)
    {
      if (!BubbleSort.IsSorted(DispData.Data))
      {
        if (finalize)
        {
          BubbleSort.Sort(DispData.Data);
        }
        else
        {
          BubbleSort.SortStep(DispData.Data);
        }
        
        DataToDrawable(ColumnColor);
        StepCounter = BubbleSort.Step.ToString();
      }
    }

    private void RefreshArray()
    {
      DispData = new DisplayData(40);
      ColumnColor = "#FFFFFF";
      ColumnsToDraw.Clear();
      DataToDrawable(ColumnColor);
      BubbleSort.ResetStep();
      StepCounter = BubbleSort.Step.ToString();
    }

    private static void DefineColumns()
    {
      Column.Scalar = (Column.GraphBottomLevel - Column.GraphTopLevel) / DisplayData.LargestNum;
      Column.Width = (_canvasSize / DisplayData.ArraySize) * 0.8;
      Column.Spacing = Column.Width * 1.1;
    }
  } 
}
