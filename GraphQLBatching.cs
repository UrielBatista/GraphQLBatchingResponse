using System;
using System.Collections.Generic;
using System.Text.Json;

namespace GraphQLBatchingResponse
{
    public class GraphQLBatching
    {
        public static T[] GraphQLBatchingMapper<T>(string data, string key)
        {
            List<T> arrayElement = new List<T>();
            var treatedElements = data.Replace("event: next", "")
                .Trim().Replace("data:", "")
                .Trim().Replace("event: complete", "")
                .Trim().Split(new string[] { "\n\n\n " }, StringSplitOptions.None);

            foreach (var element in treatedElements)
            {
                try
                {
                    var elementParsed = JsonDocument.Parse(element);
                    var rootElement = elementParsed.RootElement
                    .GetProperty("data")
                    .GetProperty(key).ToString();

                    var elementDeserialized = JsonSerializer.Deserialize<List<T>>(rootElement);
                    arrayElement.AddRange(elementDeserialized);

                }
                catch (Exception ex)
                {
                    _ = ex;
                    continue;
                }
            }

            return arrayElement.ToArray();
        }
    }
}
