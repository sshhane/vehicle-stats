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
    class OpenStatsProxy
    {
        public static async Task<RootObject> GetStats(string make, string model, string year)
        {
            var http = new HttpClient();
            //var response = await http.GetAsync("https://one.nhtsa.gov/webapi/api/SafetyRatings//modelyear/2007/make/honda/model/civic?format=json");
            var response = await http.GetAsync("https://one.nhtsa.gov/webapi/api/SafetyRatings/vehicleid/2131?format=json");

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }

        public static async Task<RootObject> GetYear(string year)
        {
            var url = "https://one.nhtsa.gov/webapi/api/SafetyRatings/modelyear/";
            var format = "?format=json";

            url =string.Concat(url, year, format);
            Debug.WriteLine("URL: " + url);

            var http = new HttpClient();
            var response = await http.GetAsync("https://one.nhtsa.gov/webapi/api/SafetyRatings//modelyear/2007?format=json");

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }

    }

    //[DataContract]
    //public class Result
    //{
    //    [DataMember]
    //    public string VehicleDescription { get; set; }
    //    [DataMember]
    //    public int VehicleId { get; set; }
    //}

    //[DataContract]
    //public class RootObject
    //{
    //    [DataMember]
    //    public int Count { get; set; }
    //    [DataMember]
    //    public string Message { get; set; }
    //    [DataMember]
    //    public List<Result> Results { get; set; }
    //}

    [DataContract]
    public class Result
    {
        [DataMember]
        public string VehiclePicture { get; set; }
        [DataMember]
        public string OverallRating { get; set; }
        //public string OverallFrontCrashRating { get; set; }
        //public string FrontCrashDriversideRating { get; set; }
        //public string FrontCrashPassengersideRating { get; set; }
        //public string FrontCrashPicture { get; set; }
        //public string FrontCrashVideo { get; set; }
        //public string OverallSideCrashRating { get; set; }
        //public string SideCrashDriversideRating { get; set; }
        //public string SideCrashPassengersideRating { get; set; }
        //public string SideCrashPicture { get; set; }
        //public string SideCrashVideo { get; set; }
        //public string RolloverRating { get; set; }
        //public string RolloverRating2 { get; set; }
        //public int RolloverPossibility { get; set; }
        //public double RolloverPossibility2 { get; set; }
        //public string SidePoleCrashRating { get; set; }
        //public string NHTSAElectronicStabilityControl { get; set; }
        //public string NHTSAForwardCollisionWarning { get; set; }
        //public string NHTSALaneDepartureWarning { get; set; }
        //public int ComplaintsCount { get; set; }
        //public int RecallsCount { get; set; }
        //public int InvestigationCount { get; set; }
        [DataMember]
        public int ModelYear { get; set; }
        [DataMember]
        public string make { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string VehicleDescription { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<Result> Results { get; set; }
        [DataMember]
        public Result result { get; set; }
        [DataMember]
        public string Model { get; set; }
    }







}