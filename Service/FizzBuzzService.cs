using BestBuySampleAPI.Model;
using System.Text;
using System.Text.Json;

namespace BestBuySampleAPI.Service
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public string GetFizzBuzz(List<object> values)
        {
            

            List<KeyValuePair<string, string>> results = new List<KeyValuePair<string, string>>();

            if (values == null || values.Count == null)
            {
           
                results.Add(new KeyValuePair<string, string>("Value", "Invalid Item"));
            }


            foreach (var item in values)
            {
                string fizzBuzzResult = "";

                
                if (item is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.String)
                {
                    fizzBuzzResult = "Invalid item";
                    results.Add(new KeyValuePair<string, string>(item.ToString(), "Invalid Item"));
                }

                if (item is JsonElement jsonElement1 && jsonElement1.ValueKind == JsonValueKind.Number)
                {
                    int intValue = jsonElement1.GetInt32();

                    if (intValue % 3 == 0 && intValue % 5 == 0)
                    {
                         

                        results.Add(new KeyValuePair<string, string>(intValue.ToString(), "FizzBuzz"));
                    }
                    else if (intValue % 3 == 0)
                    {
                       
                        results.Add(new KeyValuePair<string, string>(intValue.ToString(), "Fizz"));

                    }
                    else if (intValue % 5 == 0)
                    {
                        
                        results.Add(new KeyValuePair<string, string>(intValue.ToString(), "Buzz"));

                    }
                    else
                    {
                        //fizzBuzzResult = intValue.ToString();
                        results.Add(new KeyValuePair<string, string>(intValue.ToString(), "Divided " + intValue + " by 3"));
                        results.Add(new KeyValuePair<string, string>(intValue.ToString(), "Divided " + intValue + " by 5"));

                    }
                }

            }
            //return Ok(new { Results = results });

            string htmlTable = ConvertToHtmlTable(results);

            //return Content(htmlTable, "text/html");

            return htmlTable;


        }

        private string ConvertToHtmlTable(List<KeyValuePair<string, string>> results)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<table border='1'>");
            htmlBuilder.Append("<tr><th>Input</th><th>Result</th></tr>");

            foreach (var kvp in results)
            {
                htmlBuilder.Append("<tr>");
                htmlBuilder.Append($"<td>{kvp.Key}</td>");
                htmlBuilder.Append($"<td>{kvp.Value}</td>");
                htmlBuilder.Append("</tr>");
            }

            htmlBuilder.Append("</table>");

            return htmlBuilder.ToString();
        }

    }
    
}
