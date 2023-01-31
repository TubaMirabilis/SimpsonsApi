namespace SimpsonsApi.Exceptions;
public class PropertyValueMismatchException : Exception
{
    public PropertyValueMismatchException(string propertyName)
        : base($"The value of property {propertyName} cannot be modified.")
    {
    }
}