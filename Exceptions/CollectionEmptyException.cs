namespace SimpsonsApi.Exceptions;
public class CollectionEmptyException : Exception
{
    public CollectionEmptyException()
        : base("Collection is empty")
    {
    }
}