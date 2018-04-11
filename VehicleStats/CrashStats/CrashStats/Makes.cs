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
    class Makes
    {
        //public static async Task<MakeRootObject> GetMakes(string y){}
        public string[] make = new string[99];

        public static async Task<MakeRootObject> GetMakes(string y)
        {
            Debug.WriteLine("string: " + y);
            var url = "https://one.nhtsa.gov/webapi/api/SafetyRatings/modelyear/";
            var format = "?format=json";

            url = string.Concat(url, y, format);
            Debug.WriteLine("URL: " + url);

            var http = new HttpClient();
            var response = await http.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(MakeRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (MakeRootObject)serializer.ReadObject(ms);

            // int[] make = new int[data.Results.Count()];
            Debug.WriteLine("testing "+ data.Results.Count());
            // loop over, return Make
            //for (int i = 0; i <= data.Results.Count(); i++)
            //{
            //    make[i] = data.Results[i].Make;
            //    Debug.WriteLine("Make: " + make[i]);
            //}
            return data;
        }
    }

    [DataContract]
    public class MakeResult
    {
        [DataMember]
        public int ModelYear { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
    }

    [DataContract]
    public class MakeRootObject
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<MakeResult> Results { get; set; }
    }
}
