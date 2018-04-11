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
    class Models
    {
        public string[] model = new string[99];

        public static async Task<ModelRootObject> GetModels(string y, string mk)
        {
            var url = "https://one.nhtsa.gov/webapi/api/SafetyRatings/modelyear/";
            var format = "?format=json";
            var make = "/make/";

            url = string.Concat(url, y, make, mk, format);

            //url = string.Concat(url, mk, format);
            Debug.WriteLine("URL: " + url);

            var http = new HttpClient();
            var response = await http.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ModelRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (ModelRootObject)serializer.ReadObject(ms);

            // int[] model = new int[data.Results.Count()];
            Debug.WriteLine("testing " + data.Results.Count());
            // loop over, return Model
            //for (int i = 0; i <= data.Results.Count(); i++)
            //{
            //    model[i] = data.Results[i].model;
            //    Debug.WriteLine("Model: " + model[i]);
            //}
            return data;
        }
    }

    [DataContract]
    public class ModelResult
    {
        [DataMember]
        public int ModelYear { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
    }

    [DataContract]
    public class ModelRootObject
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<ModelResult> Results { get; set; }
    }
}
