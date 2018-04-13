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
    class Variation
    {
        public static async Task<VariationRootObject> GetVariations(string y)
        {
            var url = "https://one.nhtsa.gov/webapi/api/SafetyRatings/modelyear/";
            var format = "?format=json";

            url = string.Concat(url, y);
            url = string.Concat(url, format);

            Debug.WriteLine("Variations URL: " + url);

            var http = new HttpClient();
            var response = await http.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(VariationRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (VariationRootObject)serializer.ReadObject(ms);

            Debug.WriteLine("data.Results.Count: " + data.Results.Count());

            return data;
        }
    }

    [DataContract]
    public class VariationResult
    {
        [DataMember]
        public string VehicleDescription { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
    }

    [DataContract]
    public class VariationRootObject
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<VariationResult> Results { get; set; }
    }
}
