namespace SimpsonsApi.Paging;
public class PagingDescriptor
{
    public int ActualPageSize { get; private set; }
    public int NumberOfPages { get; private set; }
    public PageBoundary[] PagesBoundries { get; private set; }
    public PagingDescriptor(
        int actualPageSize,
        int numberOfPages,
        PageBoundary[] pagesBoundries)
    {
        ActualPageSize = actualPageSize;
        NumberOfPages = numberOfPages;
        PagesBoundries = pagesBoundries;
    }
}