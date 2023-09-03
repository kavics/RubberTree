namespace Numbers;

public class NumberCircle : NumberCollection
{
    public Size SpaceSize { get; set; }

    public NumberCircle(Size spaceSize)
    {
        SpaceSize = spaceSize;
    }
}