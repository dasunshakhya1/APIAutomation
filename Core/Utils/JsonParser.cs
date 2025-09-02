using System.Text.Json;

namespace Core.Utils
{
    public class JsonParser
    {


        public static T ParseJson<T>( string json)
        {
            return JsonSerializer.Deserialize<T>(json);

        }
    }
}