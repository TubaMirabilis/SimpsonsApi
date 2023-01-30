namespace SimpsonsApi.Paging;
public class PageBoundary
{
    public int FirstItemZeroIndex { get; private set; }
    public int LastItemZeroIndex { get; private set; }
    public PageBoundary(int firstItemZeroIndex, int lastItemZeroIndex)
    {
        FirstItemZeroIndex = firstItemZeroIndex;
        LastItemZeroIndex = lastItemZeroIndex;
    }
}