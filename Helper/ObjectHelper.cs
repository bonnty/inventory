
using System.Text.Json;
public static class ObjectHelper
{
    // Make a deep copy of an object
    public static T? DeepCopy<T>(T obj)
    {
        if(obj==null)
        {
            return default;
        }
        string json = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(json);
    }
}