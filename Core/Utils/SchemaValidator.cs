using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;

namespace Core.Utils
{
    public class SchemaValidator
    {

        public static bool isValidSchema(string schemaJson, string payload)
        {
            JSchema schema = JSchema.Parse(schemaJson);
            JObject person = JObject.Parse(payload);
            IList<string> messages;
            bool valid = person.IsValid(schema, out messages);

            if (valid)
            {
                Console.WriteLine("JSON is valid.");
                return true;
            }
            else
            {
                Console.WriteLine("JSON is NOT valid. Errors:");
                foreach (string message in messages)
                {
                    Console.WriteLine($"- {message}");
                }
            }
            return false;

        }
    }
}
