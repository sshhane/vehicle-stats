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
    class VehicleResult
    {
        public string[] result = new string[99];

        public static async Task<VehicleRootObject> GetVehicleResult(string y)
        {
            var url = "https://one.nhtsa.gov/webapi/api/SafetyRatings/vehicleid/";
            var format = "?format=json";

            url = string.Concat(url, y);
            url = string.Concat(url, format);

            Debug.WriteLine("VehicleDetails, URL: " + url);

            var http = new HttpClient();
            var response = await http.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(VehicleRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (VehicleRootObject)serializer.ReadObject(ms);

            Debug.WriteLine("data.Results[0]: " + data.Results[0].Make);

            return data;
        }
    }
}

[DataContract]
public class VehicleResult
{
    public string OverallRating { get; set; }
    public string OverallFrontCrashRating { get; set; }
    [DataMember]
    public string FrontCrashDriversideRating { get; set; }
    [DataMember]
    public string FrontCrashPassengersideRating { get; set; }
    public string OverallSideCrashRating { get; set; }
    [DataMember]
    public string SideCrashDriversideRating { get; set; }
    [DataMember]
    public string SideCrashPassengersideRating { get; set; }
    public string SideCrashPicture { get; set; }
    public string RolloverRating { get; set; }
    [DataMember]
    public string RolloverRating2 { get; set; }
    public int RolloverPossibility { get; set; }
    public int RolloverPossibility2 { get; set; }
    public string SidePoleCrashRating { get; set; }
    public string NHTSAElectronicStabilityControl { get; set; }
    public string NHTSAForwardCollisionWarning { get; set; }
    public string NHTSALaneDepartureWarning { get; set; }
    [DataMember]
    public int ComplaintsCount { get; set; }
    public int RecallsCount { get; set; }
    public int InvestigationCount { get; set; }
    public int ModelYear { get; set; }
    [DataMember]
    public string Make { get; set; }
    [DataMember]
    public string Model { get; set; }
    [DataMember]
    public string VehicleDescription { get; set; }
    public int VehicleId { get; set; }
}

[DataContract]
public class VehicleRootObject
{
    [DataMember]
    public int Count { get; set; }
    [DataMember]
    public string Message { get; set; }
    [DataMember]
    public List<VehicleResult> Results { get; set; }
}


public class RatingViewModel
{
    public double RatingValue
    {
        get;
        set;
    }
}
