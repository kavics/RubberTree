namespace Numbers;

public class Number
{
    public int Value { get; set; }
    public Number Child { get; set; }
    public NumberCollection Parents { get; set; }
    public bool IsCircleMember { get; set; }
    public NumberTree RootObject { get; set; }

    public float X { get; set; }
    public float Y { get; set; }
    public double Aperture { get; set; }
    public double Angle { get; set; }
    public int Level { get; set; }

    public PointF F1 { get; set; }
    public PointF F2 { get; set; }
    public PointF NextPosition { get; set; }


    public Number(NumberTree root) : this(root, 0)
    {
    }

    public Number(NumberTree root, int value)
    {
        RootObject = root;
        Value = value;
        Parents = new NumberCollection();
        IsCircleMember = false;
        F1 = PointF.Empty;
        F2 = PointF.Empty;
        NextPosition = PointF.Empty;
    }

    public override string ToString()
    {
        int a = Value;
        int m;
        string s = "";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        while (a > 0)
        {
            m = a % RootObject.NumberSystem;
            a /= RootObject.NumberSystem;
            s = (char)(m > 9 ? 'A' + m - 10 : '0' + m) + s;
        }
        s = "00000000000000000000000000000000000000000000000000" + s;
        return s.Substring(s.Length - RootObject.Digits);
    }

}