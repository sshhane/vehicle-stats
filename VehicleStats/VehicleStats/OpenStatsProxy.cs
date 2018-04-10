using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace VehicleStats
{
    class OpenStatsProxy
    {
        public static async Task<RootObject> GetStatsAsync(string make, string model, string year)
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

        public async static Task<RootObject> GetWeather(double lat, double lon)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://api.openweathermap.org/data/2.5/weather?lat=32.77&lon=-96.79&units=imperial");
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

    //[DataContract]
    //public class RootObject
    //{
    //    [DataMember]
    //    public int Count { get; set; }
    //    [DataMember]
    //    public string Message { get; set; }
    //    [DataMember]
    //    public List<Result> Results { get; set; }
    //    [DataMember]
    //    public Result result { get; set; }
    //    [DataMember]
    //    public string Model { get; set; }
    //}

    [DataContract]
    public class Coord
    {
        [DataMember]
        public double lon { get; set; }

        [DataMember]
        public double lat { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string main { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string icon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember]
        public double temp { get; set; }

        [DataMember]
        public int pressure { get; set; }

        [DataMember]
        public int humidity { get; set; }

        [DataMember]
        public double temp_min { get; set; }

        [DataMember]
        public double temp_max { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }

        [DataMember]
        public int deg { get; set; }
    }

    /*
    [DataContract]
    public class Rain
    {
        [DataMember]
        public double __invalid_name__1h { get; set; }
    }
    */

    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }

    [DataContract]
    public class Sys
    {

        [DataMember]
        public int type { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public double message { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public int sunrise { get; set; }

        [DataMember]
        public int sunset { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Coord coord { get; set; }

        [DataMember]
        public List<Weather> weather { get; set; }

        [DataMember]
        public string @base { get; set; }

        [DataMember]
        public Main main { get; set; }

        [DataMember]
        public Wind wind { get; set; }
        /*
        [DataMember]
        public Rain rain { get; set; }
        */

        [DataMember]
        public Clouds clouds { get; set; }

        [DataMember]
        public int dt { get; set; }

        [DataMember]
        public Sys sys { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int cod { get; set; }
    }
}
