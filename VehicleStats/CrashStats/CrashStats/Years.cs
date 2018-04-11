using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CrashStats
{
    class Years
    {
        public static async Task<YearRootObject> GetYears(string y)
        {
            var url = "https://one.nhtsa.gov/webapi/api/SafetyRatings/modelyear/";
            var format = "?format=json";

            url = string.Concat(url, y, format);
            Debug.WriteLine("URL: " + url);

            var http = new HttpClient();
            var response = await http.GetAsync("https://one.nhtsa.gov/webapi/api/SafetyRatings/?format=json");

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (YearRootObject)serializer.ReadObject(ms);

            int modelYear = data.Results[0].ModelYear;
            Debug.WriteLine("modelYear: " + modelYear);

            // loop over, return ModelYear
            for (int i = 0; i < data.Results.Count(); i++)
            {
                Debug.WriteLine("loop " + i);

            }

            return data;
        }
    }

    [DataContract]
    public class YearResult
    {
        [DataMember]
        public int ModelYear { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
    }

    [DataContract]
    public class YearRootObject
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<Result> Results { get; set; }
    }
}
