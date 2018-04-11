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
        public static int[] modelYear = new int[999];

        public static async Task<YearRootObject> GetYears()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://one.nhtsa.gov/webapi/api/SafetyRatings/?format=json");

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(YearRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (YearRootObject)serializer.ReadObject(ms);

            // int[] modelYear = new int[data.Results.Count()];
            Debug.WriteLine("test")
 ;
            // loop over, return ModelYear
            for (int i = 0; i < data.Results.Count(); i++)
            {
                modelYear[i] = data.Results[i].ModelYear;
                Debug.WriteLine("Year: " + modelYear[i]);
            }

            //modelYear = modelYear.Where(c => c != null).ToArray();

            //modelYear = modelYear.Where(s => !String.IsNullOrEmpty(s)).ToArray();
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
