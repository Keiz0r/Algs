using System;
using Algs.Core;

namespace Algs.MVVM.ViewModel
{
  public class MainViewModel : ObservableObject
  {
    public RelayCommand BubbleViewCommand { get; set; }
    public RelayCommand InsertionViewCommand { get; set; }
    public RelayCommand QuickViewCommand { get; set; }
    public RelayCommand RadixViewCommand { get; set; }
    public BubbleViewModel BubbleVM { get; set; }
    public InsertionViewModel InsertionVM { get; set; }
    public QuickViewModel QuickVM { get; set; }
    public RadixViewModel RadixVM { get; set; }
    public RelayCommand QuitProgramCommand { get; set; }
    public RelayCommand MinimizeProgramCommand { get; set; }

    public object CurrentView
    {
      get { return _currentView; }
      set
      {
        _currentView = value;
        OnPropertyChanged();
      }
    }

    private object _currentView;

    public MainViewModel()
    {
      BubbleVM = new BubbleViewModel();
      InsertionVM = new InsertionViewModel();
      QuickVM = new QuickViewModel();
      RadixVM = new RadixViewModel();

      CurrentView = BubbleVM;

      BubbleViewCommand = new RelayCommand(o => { CurrentView = BubbleVM; });
      InsertionViewCommand = new RelayCommand(o => { CurrentView = InsertionVM; });
      QuickViewCommand = new RelayCommand(o => { CurrentView = QuickVM; });
      RadixViewCommand = new RelayCommand(o => { CurrentView = RadixVM; });
      QuitProgramCommand = new RelayCommand(o => { App.Current.MainWindow.Close(); });
      MinimizeProgramCommand = new RelayCommand(o => { App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized; });
    }
  }
}
