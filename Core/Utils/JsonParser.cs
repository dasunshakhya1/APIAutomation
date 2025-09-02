using Core.Endpoints.Product.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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