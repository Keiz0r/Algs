namespace Algs.MVVM.Model
{
  public class Column
  {
    public double Left { get; set; }
    public double Top { get; set; }
    public double Height { get; set; }
    public static double Width { get; set; } = 10.0;
    public static double Scalar { get; set; } = 1.0;
    public static double GraphBottomLevel { get; set; } = 350.0;
    public static double GraphTopLevel { get; set; } = 10.0;
    public static double Spacing { get; set; }
    public static double LeftPadding { get; set; } = 40.0;

    public Column(double Left, double Height)
    {
      this.Left = LeftPadding + Spacing * Left;
      this.Height = Height * Scalar;
      Top = GraphBottomLevel - this.Height;
    }
  }
}
