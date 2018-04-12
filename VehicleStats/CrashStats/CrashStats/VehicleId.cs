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
    class VehicleId
    {
        public string[] model = new string[99];

        public static async Task<ModelRootObject> GetModels(string y, string mk, string mdl)
        {
            var url = "https://one.nhtsa.gov/webapi/api/SafetyRatings/modelyear/";
            var format = "?format=json";
            var make = "/make/";
            var model = "/model/";

            url = string.Concat(url, y, make, mk);
            url = string.Concat(url, model, mdl);
            url = string.Concat(format);

            //url = string.Concat(url, mk, format);
            Debug.WriteLine("URL: " + url);

            var http = new HttpClient();
            var response = await http.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ModelRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (ModelRootObject)serializer.ReadObject(ms);

            Debug.WriteLine("testing " + data.Results.Count());

            return data;
        }
    }

    [DataContract]
    public class IdResult
    {
        public int ModelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
    }

    [DataContract]
    public class IdRootObject
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<IdResult> Results { get; set; }
    }
}
