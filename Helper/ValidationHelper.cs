using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static class ValidationHelper
{
    // Use reflection to retrieve max range from [Range] data annotation
    public static int GetMaxRange<T>(string propertyName)
    {
        var property = typeof(T).GetProperty(propertyName);
        var rangeAttribute = property?.GetCustomAttribute<RangeAttribute>();

        return rangeAttribute?.Maximum is int max ? max : 0; // Default to 0 if not found
    }

    // Use reflection to retrieve min range from [Range] data annotation
    public static int GetMinRange<T>(string propertyName)
    {
        var property = typeof(T).GetProperty(propertyName);
        var rangeAttribute = property?.GetCustomAttribute<RangeAttribute>();

        return rangeAttribute?.Minimum is int min ? min : 0; // Default to 0 if not found
    }
}
