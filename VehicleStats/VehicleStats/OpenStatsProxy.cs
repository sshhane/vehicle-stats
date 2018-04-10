using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleStats
{
    class OpenStatsProxy
    {
        public static RootObject GetStats(string make, string model, string year)
        {

        }
    }

    public class Result
    {
        public string VehicleDescription { get; set; }
        public int VehicleId { get; set; }
    }

    public class RootObject
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public List<Result> Results { get; set; }
    }
}
